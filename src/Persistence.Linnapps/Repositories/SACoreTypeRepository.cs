﻿namespace Linn.Products.Persistence.Linnapps.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Linn.Products.Domain.Linnapps;
    using Microsoft.EntityFrameworkCore;

    public class SaCoreTypeRepository : IRepository<SaCoreType, int>
    {
        private readonly ServiceDbContext serviceDbContext;

        public SaCoreTypeRepository(ServiceDbContext serviceDbContext)
        {
            this.serviceDbContext = serviceDbContext;
        }

        public SaCoreType FindById(int key)
        {
            return this.serviceDbContext.SaCoreTypes.Where(b => b.CoreType == key).ToList().First();
        }

        public IQueryable<SaCoreType> FindAll()
        {
            return this.serviceDbContext.SaCoreTypes;
        }

        public void Add(SaCoreType entity)
        {
            this.serviceDbContext.SaCoreTypes.Add(entity);
            this.serviceDbContext.SaveChanges();
        }

        public void Remove(SaCoreType entity)
        {
            throw new NotImplementedException();
        }

        public SaCoreType FindBy(Expression<Func<SaCoreType, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SaCoreType> FilterBy(Expression<Func<SaCoreType, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}