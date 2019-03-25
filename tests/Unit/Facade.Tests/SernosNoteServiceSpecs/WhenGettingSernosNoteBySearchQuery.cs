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

    public class WhenGettingSernosNoteBySearchQuery : ContextBase
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
            this.result = this.Sut.GetSernosNote("group", 222, "code");
        }

        [Test]
        public void ShouldGetSernosNote()
        {
            this.SernosNoteRepository.Received().FindBy(Arg.Any<Expression<Func<SernosNote, bool>>>());
        }

        [Test]
        public void ShouldReturnSuccessResult()
        {
            this.result.Should().BeOfType<SuccessResult<SernosNote>>();
            var dataResult = ((SuccessResult<SernosNote>)this.result).Data;
            dataResult.SernosNoteId.Should().Be(111);
            dataResult.SernosNotes.Should().Be("notes");
        }
    }
}
