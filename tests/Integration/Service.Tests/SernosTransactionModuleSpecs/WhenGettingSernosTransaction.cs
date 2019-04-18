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

    public class WhenGettingSernosTransaction : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var sernosTrans = new SernosTransaction { TransCode = "code", TransDescription = "desc", Comments = "comments" };
            this.SernosTransactionService.GetById("code")
                .Returns(new SuccessResult<SernosTransaction>(sernosTrans) { Data = sernosTrans });

            this.Response = this.Browser.Get(
                "/products/maint/sernos-transactions/code",
                with => { with.Header("Accept", "application/json"); }).Result;
        }

        [Test]
        public void ShouldCallService()
        {
            this.SernosTransactionService.Received().GetById("code");
        }

        [Test]
        public void ShouldReturnOk()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<SernosTransactionResource>();
            resource.TransCode.Should().Be("code");
        }
    }
}
