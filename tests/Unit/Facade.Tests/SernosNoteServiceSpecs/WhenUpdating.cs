using System;
using System.Collections.Generic;
using System.Text;

namespace Linn.Products.Facade.Tests.SernosNoteServiceSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenUpdating : ContextBase
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
                                    SernosNotes = "new notes",
                                    SernosNumber = 1,
                                    SernosTref = 1,
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
            this.result.Should().BeOfType<SuccessResult<SernosNote>>();
            var dataResult = ((SuccessResult<SernosNote>)this.result).Data;
            dataResult.SernosGroup.Should().Be("group");
            dataResult.SernosNoteId.Should().Be(1);
            dataResult.SernosNotes.Should().Be("new notes");
            dataResult.SernosNumber.Should().Be(1);
//            dataResult.SernosTRef.Should().Be(1);
            dataResult.TransCode.Should().Be("code");
        }
    }
}
