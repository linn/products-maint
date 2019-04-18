namespace Linn.Products.Service.Tests.SernosTransModuleSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingSernosTrans : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var sernosTrans = new SernosTrans { TransCode = "code", TransDescription = "desc", Comments = "comments" };
            this.SernosTransService.GetById("code")
                .Returns(new SuccessResult<SernosTrans>(sernosTrans) { Data = sernosTrans });

            this.Response = this.Browser.Get(
                "/products/maint/sernos-trans/code",
                with => { with.Header("Accept", "application/json"); }).Result;
        }

        [Test]
        public void ShouldCallService()
        {
            this.SernosTransService.Received().GetById("code");
        }

        [Test]
        public void ShouldReturnOk()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<SernosTransResource>();
            resource.TransCode.Should().Be("code");
        }
    }
}
