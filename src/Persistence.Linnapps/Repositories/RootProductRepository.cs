﻿namespace Linn.Products.Persistence.Linnapps.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;

    using Microsoft.EntityFrameworkCore;

    public class RootProductRepository : IRepository<RootProduct, string>
    {
        private readonly ServiceDbContext serviceDbContext;

        public RootProductRepository(ServiceDbContext serviceDbContext)
        {
            this.serviceDbContext = serviceDbContext;
        }

        public RootProduct FindById(string key)
        {
            return this.serviceDbContext.RootProducts.Where(b => b.Name == key).Include(s => s.HoldStories).ToList()
                .FirstOrDefault();
        }

        public IQueryable<RootProduct> FindAll()
        {
            return this.serviceDbContext.RootProducts;
        }

        public void Add(RootProduct entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(RootProduct entity)
        {
            throw new NotImplementedException();
        }

        public RootProduct FindBy(Expression<Func<RootProduct, bool>> expression)
        {
            return this.serviceDbContext.RootProducts.Where(expression).ToList().FirstOrDefault();
        }

        public IQueryable<RootProduct> FilterBy(Expression<Func<RootProduct, bool>> expression)
        {
            return this.serviceDbContext.RootProducts.Where(expression).Include(s => s.HoldStories);
        }
    }
}