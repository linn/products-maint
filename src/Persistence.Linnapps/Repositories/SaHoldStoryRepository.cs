﻿namespace Linn.Products.Domain.Linnapps.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Linn.Common.Persistence;
    using Linn.Products.Persistence.Linnapps;

    public class SaHoldStoryRepository : IRepository<SaHoldStory, int>
    {
        private readonly ServiceDbContext serviceDbContext;

        public SaHoldStoryRepository(ServiceDbContext serviceDbContext)
        {
            this.serviceDbContext = serviceDbContext;
        }

        public SaHoldStory FindById(int key)
        {
            return this.serviceDbContext.SaHoldStories.Where(s => s.HoldStoryId == key).ToList().First();
        }

        public IQueryable<SaHoldStory> FindAll()
        {
            return this.serviceDbContext.SaHoldStories;
        }

        public void Add(SaHoldStory entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(SaHoldStory entity)
        {
            throw new NotImplementedException();
        }

        public SaHoldStory FindBy(Expression<Func<SaHoldStory, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SaHoldStory> FilterBy(Expression<Func<SaHoldStory, bool>> expression)
        {
            return this.serviceDbContext.SaHoldStories.Where(expression);
        }
    }
}
