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
        private SernosNoteResource resource;

        private IResult<SernosNote> result;

        [SetUp]
        public void SetUp()
        {
            this.resource = new SernosNoteResource
                                {
                                    SernosGroup = "group",
                                    SernosNoteId = 1,
                                    SernosNotes = "notes",
                                    SernosNumber = 1,
                                    SernosTref = 1,
                                    TransCode = "code"
                                };

            this.result = this.Sut.Add(this.resource);
        }

        // TODO fix this!
        [Test]
        public void ShouldAddSernosNote()
        {
            this.SernosNoteRepository.Received()
                .Add(Arg.Is<SernosNote>(n => n.SernosNoteId == this.resource.SernosNoteId));
        }

        [Test]
        public void ShouldReturnSuccess()
        {
            this.result.Should().BeOfType<CreatedResult<SernosNote>>();
            var dataResult = ((CreatedResult<SernosNote>)this.result).Data;
            dataResult.SernosGroup.Should().Be("group");
            dataResult.SernosNoteId.Should().Be(1);
            dataResult.SernosNotes.Should().Be("notes");
            dataResult.SernosNumber.Should().Be(1);
//            dataResult.SernosTref.Should().Be(1);
            dataResult.TransCode.Should().Be("code");
        }
    }
}