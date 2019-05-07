namespace Linn.Products.Facade.Tests.SerialNumberServiceSpecs
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenCreatingSerialNumbersWithSernosNotes : ContextBase
    {
        private SerialNumberCreateResource resource;

        private IResult<IEnumerable<SerialNumber>> result;

        [SetUp]
        public void SetUp()
        {
            this.resource = new SerialNumberCreateResource
                                {
                                    TransCode = "trans",
                                    ArticleNumber = "art",
                                    FromSernosNumber = 555,
                                    ToSernosNumber = 556,
                                    PrevSernosNumber = 321,
                                    SernosNotes = "some notes",
                                    Links = new List<LinkResource>
                                                {
                                                    new LinkResource("entered-by", "/employees/888")
                                                }.ToArray()
                                };

            this.SerialNumberFactory.CreateSerialNumbers("trans", "art", 555, 556, 321, 888).Returns(
                new List<SerialNumber>
                    {
                        new SerialNumber("group", "trans", "art", 888) { SernosNumber = 555 },
                        new SerialNumber("group", "trans", "art", 888) { SernosNumber = 556 }
                    });

            this.result = this.Sut.CreateSerialNumbers(this.resource);
        }

        [Test]
        public void ShouldReturnCreated()
        {
            this.result.Should().BeOfType<CreatedResult<IEnumerable<SerialNumber>>>();
        }

        [Test]
        public void ShouldCallFactory()
        {
            this.SerialNumberFactory.Received().CreateSerialNumbers("trans", "art", 555, 556, 321, 888);
        }

        [Test]
        public void ShouldCallSernosNotesService()
        {
            this.SernosNoteService.Received().Add(Arg.Is<SernosNoteCreateResource>(n => n.SernosNotes == "some notes"));
        }

        [Test]
        public void ShouldAddToDatabase()
        {
            this.SerialNumberRepository.Received().Add(Arg.Is<SerialNumber>(a => a.SernosNumber == 555));
            this.SerialNumberRepository.Received().Add(Arg.Is<SerialNumber>(a => a.SernosNumber == 556));
        }

        [Test]
        public void ShouldCommitTransaction()
        {
            this.TransactionManager.Received().Commit();
        }

        [Test]
        public void ShouldReturnSerialNumbers()
        {
            this.result.Should().BeOfType<CreatedResult<IEnumerable<SerialNumber>>>();
            var dataResult = ((CreatedResult<IEnumerable<SerialNumber>>)this.result).Data.ToList();
            dataResult.Should().HaveCount(2);
            dataResult.Should().Contain(s => s.SernosNumber == 555);
            dataResult.Should().Contain(s => s.SernosNumber == 556);
        }
    }
}
