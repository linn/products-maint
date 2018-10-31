namespace Linn.Products.Facade.Tests.FacadeServiceSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingNotFound : ContextBase
    {
        private IResult<TestEntity> result;

        private int id;

        [SetUp]
        public void SetUp()
        {
            this.id = 9;
            this.Repository.FindById(this.id)
                .Returns((TestEntity)null);
            this.result = this.Sut.GetById(this.id);
        }

        [Test]
        public void ShouldTryToGetTestEntity()
        {
            this.Repository.Received().FindById(this.id);
        }

        [Test]
        public void ShouldReturnNotFound()
        {
            this.result.Should().BeOfType<NotFoundResult<TestEntity>>();
        }
    }
}
