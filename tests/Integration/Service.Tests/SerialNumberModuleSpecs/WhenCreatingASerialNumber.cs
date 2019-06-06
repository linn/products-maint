namespace Linn.Products.Service.Tests.SerialNumberModuleSpecs
{
    using System.Collections.Generic;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenCreatingASerialNumber : ContextBase
    {
        private SerialNumberResource resource;

        [SetUp]
        public void SetUp()
        {
            this.resource = new SerialNumberResource
                               {
                                   ArticleNumber = "art",
                                   PrevSernosNumber = 11,
                                   SernosDate = "12/12/2019",
                                   SernosGroup = "group",
                                   SernosTRef = 33,
                                   TransCode = "trans",
                                   FromSernosNumber = 1,
                                   ToSernosNumber = 2
                               };

            this.SerialNumberService
                .CreateSerialNumbers(Arg.Any<SerialNumberCreateResource>(), Arg.Any<IEnumerable<string>>())
                .Returns(new CreatedResult<ResponseModel<IEnumerable<SerialNumber>>>(
                    new ResponseModel<IEnumerable<SerialNumber>>(
                        new List<SerialNumber>
                            {
                                new SerialNumber("group", "trans", "art", 800) { SernosNumber = 1 },
                                new SerialNumber("group", "trans", "art", 800) { SernosNumber = 2 }
                            }, 
                        new List<string>())));

            this.Response = this.Browser.Post(
                "/products/maint/serial-numbers",
                with =>
                    {
                        with.Header("Accept", "application/json");
                        with.Header("Content-Type", "application/json");
                        with.JsonBody(this.resource);
                    }).Result;
        }

        [Test]
        public void ShouldCallService()
        {
            this.SerialNumberService.Received().CreateSerialNumbers(Arg.Any<SerialNumberCreateResource>(), Arg.Any<IEnumerable<string>>());
        }


        [Test]
        public void ShouldHaveCreateStatusCode()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.Created);
        }
    }
}
