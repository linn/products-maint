namespace Linn.Products.Facade.Tests.SernosNoteServiceSpecs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingSernosNoteBySernosNumber : ContextBase
    {
        private SernosNote sernosNote;

        private IResult<IEnumerable<SernosNote>> result;

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

            this.SernosNoteRepository.FilterBy(Arg.Any<Expression<Func<SernosNote, bool>>>()).Returns(new List<SernosNote> { this.sernosNote }.AsQueryable());
            this.result = this.Sut.Search("222");
        }

        [Test]
        public void ShouldGetSernosNote()
        {
            this.SernosNoteRepository.Received().FilterBy(Arg.Any<Expression<Func<SernosNote, bool>>>());
        }

        [Test]
        public void ShouldReturnSuccessResult()
        {
            this.result.Should().BeOfType<SuccessResult<IEnumerable<SernosNote>>>();
            var dataResult = ((SuccessResult<IEnumerable<SernosNote>>)this.result).Data;
            dataResult.Should().Contain(s => s.SernosNoteId == 111);
        }
    }
}
