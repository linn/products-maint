namespace Linn.Products.Facade.Tests.SernosNoteServiceSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingSernosNoteByIdButNoMatchingNote : ContextBase
    {
        private SernosNote sernosNote;

        private IResult<SernosNote> result;

        [SetUp]
        public void SetUp()
        {
            this.sernosNote = new SernosNote("notes")
                                  {
                                      SernosGroup = "group",
                                      SernosNoteId = 111,
                                      SernosNumber = 222,
                                      SernosTRef = 333,
                                      TransCode = "code"
                                  };

            this.SernosNoteRepository.FindById(555).Returns((SernosNote)null);
            this.result = this.Sut.GetSernosNoteById(111);
        }

        [Test]
        public void ShouldGetSernosNote()
        {
            this.SernosNoteRepository.Received().FindById(111);
        }

        [Test]
        public void ShouldReturnSuccessResult()
        {
            this.result.Should().BeOfType<NotFoundResult<SernosNote>>();
        }
    }
}
