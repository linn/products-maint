namespace Linn.Products.Facade.Tests.SernosNoteServiceSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenCreating : ContextBase
    {
        private SernosNoteCreateResource resource;

        private IResult<SernosNote> result;

        [SetUp]
        public void SetUp()
        {
            this.resource = new SernosNoteCreateResource
                                {
                                    SernosGroup = "group",
                                    SernosNotes = "notes",
                                    SernosNumber = 1,
                                    SernosTRef = 1,
                                    TransCode = "code"
                                };

            this.result = this.Sut.Add(this.resource);
        }
        
        [Test]
        public void ShouldAddSernosNote()
        {
            this.SernosNoteRepository.Received()
                .Add(Arg.Is<SernosNote>(n => n.SernosNotes == this.resource.SernosNotes));
        }

        [Test]
        public void ShouldReturnSuccess()
        {
            this.result.Should().BeOfType<CreatedResult<SernosNote>>();
            var dataResult = ((CreatedResult<SernosNote>)this.result).Data;
            dataResult.SernosGroup.Should().Be("group");
            dataResult.SernosNotes.Should().Be("notes");
            dataResult.SernosNumber.Should().Be(1);
            dataResult.TransCode.Should().Be("code");
        }
    }
}