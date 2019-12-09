namespace Linn.Products.Facade.Tests.ArchiveSerialNumberServiceSpecs
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

    public class WhenGettingByDocumentNumber : ContextBase
    {
        private IResult<ResponseModel<IEnumerable<ArchiveSerialNumber>>> result;

        [SetUp]
        public void SetUp()
        {
            this.ArchiveSerialNumberRepository.FilterBy(Arg.Any<Expression<Func<ArchiveSerialNumber, bool>>>()).Returns(
                new List<ArchiveSerialNumber>
                    {
                        new ArchiveSerialNumber { SernosNumber = 123, DocumentNumber = 444 },
                        new ArchiveSerialNumber { SernosNumber = 321, DocumentNumber = 444 }
                    }.AsQueryable());

            this.result = this.Sut.SearchByDocumentNumber(444, new List<string>());
        }

        [Test]
        public void ShouldReturnSuccess()
        {
            this.result.Should().BeOfType<SuccessResult<ResponseModel<IEnumerable<ArchiveSerialNumber>>>>();
        }

        [Test]
        public void ShouldReturnSerialNumbers()
        {
            var dataResult = ((SuccessResult<ResponseModel<IEnumerable<ArchiveSerialNumber>>>)this.result).Data
                .ResponseData.ToList();
            dataResult.Should().HaveCount(2);
            dataResult.Should().Contain(s => s.SernosNumber == 123);
            dataResult.Should().Contain(s => s.SernosNumber == 321);
        }
    }
}