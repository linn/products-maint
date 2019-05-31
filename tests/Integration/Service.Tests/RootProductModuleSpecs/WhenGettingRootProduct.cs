namespace Linn.Products.Service.Tests.RootProductModuleSpecs
{
    using System.Collections.Generic;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingRootProductById : ContextBase
    {
        private ResponseModel<RootProduct> rootProductResponseModel;

        [SetUp]
        public void SetUp()
        {
            var rootProduct = new RootProduct { Name = "rp" };
            this.rootProductResponseModel = new ResponseModel<RootProduct>(rootProduct, null);
            this.RootProductService.GetById("rp", Arg.Any<IEnumerable<string>>()).Returns(new SuccessResult<ResponseModel<RootProduct>>(this.rootProductResponseModel));
            this.Response = this.Browser.Get(
                "/products/maint/root-products/rp",
                with =>
                    {
                        with.Header("Accept", "application/json");
                    }).Result;
        }

        [Test]
        public void ShouldReturnOk()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void ShouldCallService()
        {
            this.RootProductService.Received().GetById("rp", Arg.Any<IEnumerable<string>>());
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<RootProductResource>();
            resource.Name.Should().Be("rp");
        }
    }
}