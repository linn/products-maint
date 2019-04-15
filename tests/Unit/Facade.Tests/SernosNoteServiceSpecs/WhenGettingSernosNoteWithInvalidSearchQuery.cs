namespace Linn.Products.Facade.Tests.SernosNoteServiceSpecs
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingSernosNoteWithInvalidSearchQuery : ContextBase
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

            this.SernosNoteRepository.FindBy(Arg.Any<Expression<Func<SernosNote, bool>>>()).Returns(this.sernosNote);
            this.result = this.Sut.GetSernosNote(string.Empty, 123, "code");
        }        

        [Test]
        public void ShouldReturnBadRequestResult()
        {
            this.result.Should().BeOfType<BadRequestResult<SernosNote>>();
        }
    }
}
