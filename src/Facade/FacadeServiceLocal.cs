namespace Linn.Products.Facade
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using Linn.Common.Domain.Exceptions;
    using Linn.Common.Facade;
    using Linn.Common.Persistence;
    using Linn.Products.Facade.Models;

    using PagedList.Core;

    public abstract class FacadeServiceLocal<T, TKey, TResource, TUpdateResource> : IFacadeServiceLocal<T, TKey, TResource, TUpdateResource>
    {
        private readonly IRepository<T, TKey> repository;
        private readonly ITransactionManager transactionManager;

        protected FacadeServiceLocal(IRepository<T, TKey> repository, ITransactionManager transactionManager)
        {
            this.repository = repository;
            this.transactionManager = transactionManager;
        }

        public IResult<T> GetById(TKey id)
        {
            T byId = this.repository.FindById(id);
            if ((object)byId == null)
                return (IResult<T>)new NotFoundResult<T>("");
            return (IResult<T>)new SuccessResult<T>(byId);
        }

        public IResult<IEnumerable<T>> GetAll()
        {
            return (IResult<IEnumerable<T>>)new SuccessResult<IEnumerable<T>>((IEnumerable<T>)this.repository.FindAll());
        }

        public IResult<IPagedList<T>> GetAll(int pageNumber, int pageSize)
        {
            return (IResult<IPagedList<T>>)new SuccessResult<IPagedList<T>>((IPagedList<T>)new PagedList.Core.PagedList<T>(this.repository.FindAll(), pageNumber, pageSize));
        }

        public IResult<IEnumerable<T>> Search(string searchTerm)
        {
            try
            {
                return (IResult<IEnumerable<T>>)new SuccessResult<IEnumerable<T>>((IEnumerable<T>)this.repository.FilterBy(this.SearchExpression(searchTerm)));
            }
            catch (NotImplementedException ex)
            {
                return (IResult<IEnumerable<T>>)new BadRequestResult<IEnumerable<T>>("Search is not implemented");
            }
        }

        public IResult<T> Add(TResource resource)
        {
            T fromResource;
            try
            {
                fromResource = this.CreateFromResource(resource);
            }
            catch (DomainException ex)
            {
                return (IResult<T>)new BadRequestResult<T>(ex.Message);
            }
            this.repository.Add(fromResource);
            this.transactionManager.Commit();
            return (IResult<T>)new CreatedResult<T>(fromResource);
        }

        public IResult<T> Update(TKey id, TUpdateResource updateResource)
        {
            T byId = this.repository.FindById(id);
            if ((object)byId == null)
                return (IResult<T>)new NotFoundResult<T>("");
            try
            {
                this.UpdateFromResource(byId, updateResource);
            }
            catch (DomainException ex)
            {
                return (IResult<T>)new BadRequestResult<T>(string.Format("Error updating {0} - {1}", (object)id, (object)ex.Message));
            }
            this.transactionManager.Commit();
            return (IResult<T>)new SuccessResult<T>(byId);
        }

        public IResult<ResponseModel<T>> GetById(TKey id, IEnumerable<string> privileges)
        {
            T entity = this.repository.FindById(id);
            if (entity == null)
            {
                return new NotFoundResult<ResponseModel<T>>(string.Empty);
            }

            return new SuccessResult<ResponseModel<T>>(new ResponseModel<T>(entity, privileges));
        }

        public IResult<ResponseModel<T>> Add(TResource resource, IEnumerable<string> privileges)
        {
            T fromResource;
            try
            {
                fromResource = this.CreateFromResource(resource);
            }
            catch (DomainException ex)
            {
                return new BadRequestResult<ResponseModel<T>>(ex.Message);
            }
            this.repository.Add(fromResource);
            this.transactionManager.Commit();
            return new CreatedResult<ResponseModel<T>>(new ResponseModel<T>(fromResource, privileges));
        }

        public IResult<ResponseModel<T>> Update(TKey id, TUpdateResource updateResource, IEnumerable<string> privileges)
        {
            T entity = this.repository.FindById(id);
            if (entity == null)
            {
                return new NotFoundResult<ResponseModel<T>>(string.Empty);
            }

            try
            {
                this.UpdateFromResource(entity, updateResource);
            }
            catch (DomainException ex)
            {
                return new BadRequestResult<ResponseModel<T>>($"Error updating {(object)id} - {(object)ex.Message}");
            }

            this.transactionManager.Commit();
            return new SuccessResult<ResponseModel<T>>(new ResponseModel<T>(entity, privileges));
        }

        protected abstract T CreateFromResource(TResource resource);

        protected abstract void UpdateFromResource(T entity, TUpdateResource updateResource);

        protected abstract Expression<Func<T, bool>> SearchExpression(string searchTerm);
    }
}
