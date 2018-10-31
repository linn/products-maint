namespace Linn.Products.Facade.Tests.FacadeServiceSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenAdding : ContextBase
    {
        private IResult<TestEntity> result;

        private TestEntity resource;

        [SetUp]
        public void SetUp()
        {
            this.resource = new TestEntity
                                {
                                    Name = "name"
                                };

            this.result = this.Sut.Add(this.resource);
        }

        [Test]
        public void ShouldAddTestEntity()
        {
            this.Repository.Received().Add(Arg.Any<TestEntity>());
        }

        [Test]
        public void ShouldReturnCreated()
        {
            this.result.Should().BeOfType<CreatedResult<TestEntity>>();
            var dataResult = ((CreatedResult<TestEntity>)this.result).Data;
            dataResult.Name.Should().Be(this.resource.Name);
        }
    }
}
