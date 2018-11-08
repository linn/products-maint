namespace Linn.Products.Facade.Tests.FacadeServiceSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGetting : ContextBase
    {
        private IResult<TestEntity> result;

        private int id;

        [SetUp]
        public void SetUp()
        {
            this.id = 12345;
            this.Repository.FindById(this.id).Returns(new TestEntity { Id =  12345, Name = "name" });
            this.result = this.Sut.GetById(this.id);
        }

        [Test]
        public void ShouldGetEntity()
        {
            this.Repository.Received().FindById(this.id);
        }

        [Test]
        public void ShouldReturnSuccess()
        {
            this.result.Should().BeOfType<SuccessResult<TestEntity>>();
            var dataResult = ((SuccessResult<TestEntity>)this.result).Data;
            dataResult.Id.Should().Be(this.id);
        }
    }
}
