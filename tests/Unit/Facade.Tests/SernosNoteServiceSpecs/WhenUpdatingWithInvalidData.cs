namespace Linn.Products.Facade.Tests.SernosNoteServiceSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenUpdatingWithInvalidData : ContextBase
    {
        private IResult<SernosNote> result;

        private SernosNoteResource resource;

        private SernosNote sernosNote;

        [SetUp]
        public void SetUp()
        {
            this.sernosNote = new SernosNote("note")
                                  {
                                      SernosNoteId = 1
                                  };

            this.resource = new SernosNoteResource
                                {
                                    SernosGroup = "group",
                                    SernosNoteId = 1,
                                    SernosNumber = 1,
                                    SernosTRef = 1,
                                    TransCode = "code"
                                };

            this.SernosNoteRepository.FindById(1).Returns(this.sernosNote);
            this.result = this.Sut.Update(1, this.resource);
        }

        [Test]
        public void ShouldGetSernosNote()
        {
            this.SernosNoteRepository.Received().FindById(1);
        }

        [Test]
        public void ShouldReturnSuccess()
        {
            this.result.Should().BeOfType<BadRequestResult<SernosNote>>();
        }
    }
}
