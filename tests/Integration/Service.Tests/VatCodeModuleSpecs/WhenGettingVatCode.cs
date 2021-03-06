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

    public class WhenGettingVatCode : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var vatCode = new VatCode("A", "STD UK VAT RATE.", 20, null, 1, "N");
            this.VatCodeService.GetById("A", Arg.Any<IEnumerable<string>>())
                .Returns(new SuccessResult<ResponseModel<VatCode>>(new ResponseModel<VatCode>(vatCode, new List<string>())));

            this.Response = this.Browser.Get(
                "/products/maint/vat-codes/A",
                with => { with.Header("Accept", "application/json"); }).Result;
        }

        [Test]
        public void ShouldCallService()
        {
            this.VatCodeService.Received().GetById("A", Arg.Any<IEnumerable<string>>());
        }

        [Test]
        public void ShouldReturnOk()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<VatCodeResource>();
            resource.Code.Should().Be("A");
        }
    }
}