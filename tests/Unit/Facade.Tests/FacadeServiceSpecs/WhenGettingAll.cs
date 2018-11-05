namespace Linn.Products.Facade.Tests.FacadeServiceSpecs
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Linn.Common.Facade;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingAll : ContextBase
    {
        private IResult<IEnumerable<TestEntity>> result;

        [SetUp]
        public void SetUp()
        {
            this.Repository.FindAll()
                .Returns(new List<TestEntity>
                             {
                                 new TestEntity { Id = 1 },
                                 new TestEntity { Id = 2 }
                             }.AsQueryable());
            this.result = this.Sut.GetAll();
        }

        [Test]
        public void ShouldGetEntities()
        {
            this.Repository.Received().FindAll();
        }

        [Test]
        public void ShouldReturnSuccess()
        {
            this.result.Should().BeOfType<SuccessResult<IEnumerable<TestEntity>>>();
            var dataResult = ((SuccessResult<IEnumerable<TestEntity>>)this.result).Data.ToList();
            dataResult.Should().HaveCount(2);
            dataResult.Should().Contain(r => r.Id == 1);
            dataResult.Should().Contain(r => r.Id == 2);
        }
    }
}
