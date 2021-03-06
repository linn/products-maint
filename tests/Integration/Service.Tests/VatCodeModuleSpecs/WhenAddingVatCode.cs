﻿namespace Linn.Products.Service.Tests.VatCodeModuleSpecs
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

    public class WhenAddingVatCode : ContextBase
    {
        private VatCodeResource requestResource;

        [SetUp]
        public void SetUp()
        {
            this.requestResource = new VatCodeResource { Code = "A" };
            var vatCode = new VatCode("A", "STD UK VAT RATE.", 20, null, 1, "N");
            this.VatCodeService.Add(Arg.Any<VatCodeResource>(), Arg.Any<IEnumerable<string>>())
                .Returns(new CreatedResult<ResponseModel<VatCode>>(new ResponseModel<VatCode>(vatCode, new List<string>())));
            this.Response = this.Browser.Post(
                "/products/maint/vat-codes",
                with =>
                {
                    with.Header("Accept", "application/json");
                    with.Header("Content-Type", "application/json");
                    with.JsonBody(this.requestResource);
                }).Result;
        }

        [Test]
        public void ShouldReturnCreated()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Test]
        public void ShouldCallService()
        {
            this.VatCodeService.Received().Add(
                Arg.Is<VatCodeResource>(r => r.Code == this.requestResource.Code),
                Arg.Any<IEnumerable<string>>());
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<VatCodeResource>();
            resource.Code.Should().Be("A");
        }
    }
}