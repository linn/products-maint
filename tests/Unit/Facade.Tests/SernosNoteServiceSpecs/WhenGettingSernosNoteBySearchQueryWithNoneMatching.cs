namespace Linn.Products.Facade.Tests.SernosNoteServiceSpecs
{
    using System;
    using System.Linq.Expressions;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingSernosNoteBySearchQueryWithNoneMatching : ContextBase
    {
        private IResult<SernosNote> result;

        [SetUp]
        public void SetUp()
        {
            this.SernosNoteRepository.FindBy(Arg.Any<Expression<Func<SernosNote, bool>>>()).Returns((SernosNote)null);
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
            this.result.Should().BeOfType<NotFoundResult<SernosNote>>();
        }
    }
}
