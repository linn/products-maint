namespace Linn.Products.Facade.Tests.SerialNumberServiceSpecs
{
    using System.Collections.Generic;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using NUnit.Framework;

    public class WhenCreatingWithoutEmployee : ContextBase
    {
        private SerialNumberCreateResource resource;

        private IResult<IEnumerable<SerialNumber>> result;

        [SetUp]
        public void SetUp()
        {
            this.resource = new SerialNumberCreateResource() { Links = new List<LinkResource>().ToArray() };
            this.result = this.Sut.CreateSerialNumbers(this.resource);
        }

        [Test]
        public void ShouldReturnBadRequest()
        {
            this.result.Should().BeOfType<BadRequestResult<IEnumerable<SerialNumber>>>();
        }
    }
}
