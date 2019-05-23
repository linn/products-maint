namespace Linn.Products.Facade.Tests.SerialNumberServiceSpecs
{
    using System.Collections.Generic;

    using FluentAssertions;

    using Linn.Common.Domain.Exceptions;
    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using NSubstitute.ExceptionExtensions;

    using NUnit.Framework;

    public class WhenCreatingWithInvalidInput : ContextBase
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
                                    Links = new List<LinkResource>
                                                {
                                                    new LinkResource(
                                                        "entered-by",
                                                        "/employees/888")
                                                }.ToArray()
                                };

            this.SerialNumberFactory.CreateSerialNumbers("trans", "art", 555, 556, 321, 888)
                .Throws(new DomainException("message"));

            this.result = this.Sut.CreateSerialNumbers(this.resource);
        }

        [Test]
        public void ShouldReturnBadRequest()
        {
            this.result.Should().BeOfType<BadRequestResult<IEnumerable<SerialNumber>>>();
        }
    }
}
