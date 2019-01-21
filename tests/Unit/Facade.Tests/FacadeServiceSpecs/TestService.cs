﻿namespace Linn.Products.Facade.Tests.FacadeServiceSpecs
{
    using Linn.Common.Persistence;
    using Linn.Products.Facade.Services;

    public class TestService : FacadeService<TestEntity, int, TestEntity>
    {
        public TestService(IRepository<TestEntity, int> repository)
            : base(repository)
        {
        }

        protected override TestEntity CreateFromResource(TestEntity resource)
        {
           return new TestEntity { Name = resource.Name };
        }

        protected override void UpdateFromResource(TestEntity entity, TestEntity updateResource)
        {
            entity.Name = updateResource.Name;
        }
    }
}
