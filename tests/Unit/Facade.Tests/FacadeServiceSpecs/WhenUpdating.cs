namespace Linn.Products.Facade.Tests.FacadeServiceSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenUpdating : ContextBase
    {
        private IResult<TestEntity> result;

        private TestEntity resource;

        private int id;

        [SetUp]
        public void SetUp()
        {
            this.id = 808;
            this.resource = new TestEntity
                                {
                                    Name = "new name"
                                };
            this.Repository.FindById(this.id).Returns(new TestEntity { Id = this.id, Name = "old name" });
            this.result = this.Sut.Update(this.id, this.resource);
        }

        [Test]
        public void ShouldGetTestEntity()
        {
            this.Repository.Received().FindById(this.id);
        }

        [Test]
        public void ShouldReturnSuccess()
        {
            this.result.Should().BeOfType<SuccessResult<TestEntity>>();
            var dataResult = ((SuccessResult<TestEntity>)this.result).Data;
            dataResult.Id.Should().Be(this.id);
            dataResult.Name.Should().Be("new name");
        }
    }
}
