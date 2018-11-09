namespace Linn.Products.Facade.Services
{
    using System;
    using System.Collections.Generic;
    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Repositories;
    using Linn.Products.Persistence.Linnapps;
    using Linn.Products.Resources;

    public class SACoreTypeService : ISACoreTypeService
    {
        private readonly IRepository<SACoreType, int> repository;

        public SACoreTypeService(IRepository<SACoreType, int> repository)
        {
            this.repository = repository;
        }

        public IResult<SACoreType> GetSACoreType(int coreType)
        {
            var result = this.repository.FindById(coreType);
            if (result == null)
            {
                return new NotFoundResult<SACoreType>();
            }
            return new SuccessResult<SACoreType>(result);
        }

        public IResult<IEnumerable<SACoreType>> GetAllSACoreTypes()
        {
            var result = this.repository.FindAll();
            return new SuccessResult<IEnumerable<SACoreType>>(result);
        }

        public IResult<SACoreType> AddSACoreType(SACoreTypeResource resource)
        {
            var coreType = new SACoreType
                               {
                                   Description = resource.Description,
                                   DateInvalid = DateTime.Parse(resource.DateInvalid),
                                   LookAheadDays = resource.LookAheadDays,
                                   SortOrder = resource.SortOrder,
                                   TriggerLevel = resource.TriggerLevel
                               };

            this.repository.Add(coreType);
            
            return new SuccessResult<SACoreType>(coreType);    
        }

        public IResult<SACoreType> UpdateSACoreType(int coreType, SACoreTypeResource resource)
        {
            var sACoreType = this.repository.FindById(coreType);
            if (sACoreType == null)
            {
                return new NotFoundResult<SACoreType>();
            }

            sACoreType.Description = resource.Description;
            sACoreType.DateInvalid = DateTime.Parse(resource.DateInvalid);
            sACoreType.LookAheadDays = resource.LookAheadDays;
            sACoreType.SortOrder = resource.SortOrder;
            sACoreType.TriggerLevel = resource.TriggerLevel;

            return new SuccessResult<SACoreType>(sACoreType);
        }
    }
}
