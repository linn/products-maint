namespace Linn.Products.Service.Tests.SerialNumberModuleSpecs
{
    using System;

    using FluentAssertions;

    using FluentValidation.Results;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;
    using Linn.Products.Resources.Validators;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;
    using NSubstitute.Core.Arguments;

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
                                   DocumentNumber = 22,
                                   DocumentType = "doc",
                                   PrevSernosNumber = 11,
                                   SernosDate = "12/12/2019",
                                   SernosGroup = "group",
                                   SernosTRef = 33,
                                   TransCode = "trans"
                               };

            this.SerialNumberService.Add(Arg.Any<SerialNumberResource>())
                .Returns(new CreatedResult<SerialNumber>(new SerialNumber(33, "group", "trans", "art", 1234)));

            this.Response = this.Browser.Post(
                "/products/maint/serial-numbers/create",
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

            this.SerialNumberService.Received().Add(Arg.Any<SerialNumberResource>());
        }


        [Test]
        public void ShouldHaveCreateStatusCode()
        {

            this.Response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

    }
}
