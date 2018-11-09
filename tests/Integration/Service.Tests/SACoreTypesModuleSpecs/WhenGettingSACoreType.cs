namespace Linn.Products.Service.Tests.SACoreTypesModuleSpecs
{


    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;

    using Nancy;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingSACoreType : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var sACoreType = new SACoreType();
            this.SACoreTypeService.GetById(1)
                .Returns(new SuccessResult<SACoreType>(sACoreType)
                             {
                                 Data = sACoreType
                             });

            this.Response = this.Browser.Get(
                "/products/maint/sa-core-types/1",
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
            this.SACoreTypeService.Received().GetById(1);
        }
    }
}
