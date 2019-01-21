namespace Linn.Products.Facade.Services
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps.Exceptions;

    public abstract class FacadeService<T, TKey, TResource> : IFacadeService<T, TKey, TResource>
    {
        private readonly IRepository<T, TKey> repository;

        protected FacadeService(IRepository<T, TKey> repository)
        {
            this.repository = repository;
        }

        public IResult<T> GetById(TKey id)
        {
            var entity = this.repository.FindById(id);
            if (entity == null)
            {
                return new NotFoundResult<T>();
            }

            return new SuccessResult<T>(entity);
        }

        public IResult<IEnumerable<T>> GetAll()
        {
            return new SuccessResult<IEnumerable<T>>(this.repository.FindAll());
        }

        public IResult<T> Add(TResource resource)
        {
            T entity;

            try
            {
                entity  = this.CreateFromResource(resource);
            }
            catch (DomainException exception)
            {
                return new BadRequestResult<T>(exception.Message);
            }

            this.repository.Add(entity);

            return new CreatedResult<T>(entity);
        }

        public IResult<T> Update(TKey id, TResource updateResource)
        {
            var entity = this.repository.FindById(id);
            if (entity == null)
            {
                return new NotFoundResult<T>();
            }

            try
            {
                this.UpdateFromResource(entity, updateResource);
            }
            catch (DomainException exception)
            {
                return new BadRequestResult<T>($"Error updating {id} - {exception.Message}");
            }

            return new SuccessResult<T>(entity);
        }

        protected abstract T CreateFromResource(TResource resource);

        protected abstract void UpdateFromResource(T entity, TResource updateResource);
    }
}
