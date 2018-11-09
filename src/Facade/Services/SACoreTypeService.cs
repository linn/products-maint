namespace Linn.Products.Facade.Services
{
    using System;
    using System.Collections.Generic;
    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Persistence.Linnapps;
    using Linn.Products.Resources;

    public class SaCoreTypeService : FacadeService<SaCoreType, int, SaCoreTypeResource>
    {
        private readonly IRepository<SaCoreType, int> repository;

        public SaCoreTypeService(IRepository<SaCoreType, int> repository) : base(repository)
        {
            this.repository = repository;
        }
        //
        // public IResult<SaCoreType> GetById(int coreType)
        // {
        //     var result = this.repository.FindById(coreType);
        //     if (result == null)
        //     {
        //         return new NotFoundResult<SaCoreType>();
        //     }
        //
        //     return new SuccessResult<SaCoreType>(result);
        // }
        //
        // public IResult<IEnumerable<SaCoreType>> GetAll()
        // {
        //     var result = this.repository.FindAll();
        //     return new SuccessResult<IEnumerable<SaCoreType>>(result);
        // }
        //
        // public IResult<SaCoreType> Add(SaCoreTypeResource resource)
        // {
        //     var coreType = new SaCoreType(
        //         resource.coreType,
        //         resource.Description,
        //         DateTime.Parse(resource.DateInvalid),
        //         resource.LookAheadDays,
        //         resource.SortOrder,
        //         resource.TriggerLevel);
        //                       
        //     this.repository.Add(coreType);
        //     return new SuccessResult<SaCoreType>(coreType);    
        // }
        //
        // public IResult<SaCoreType> Update(int coreType, SaCoreTypeResource resource)
        // {
        //     var saCoreType = this.repository.FindById(coreType);
        //     if (saCoreType == null)
        //     {
        //         return new NotFoundResult<SaCoreType>();
        //     }
        //
        //     saCoreType.Description = resource.Description;
        //     saCoreType.DateInvalid = DateTime.Parse(resource.DateInvalid);
        //     saCoreType.LookAheadDays = resource.LookAheadDays;
        //     saCoreType.SortOrder = resource.SortOrder;
        //     saCoreType.TriggerLevel = resource.TriggerLevel;
        //
        //     return new SuccessResult<SaCoreType>(saCoreType);
        // }

        protected override SaCoreType CreateFromResource(SaCoreTypeResource resource)
        {
            throw new NotImplementedException();
        }

        protected override void UpdateFromResource(SaCoreType entity, SaCoreTypeResource updateResource)
        {
            throw new NotImplementedException();
        }
    }
}
