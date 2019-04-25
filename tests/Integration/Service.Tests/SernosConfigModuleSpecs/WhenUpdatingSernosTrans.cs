namespace Linn.Products.Service.Tests.SernosConfigModuleSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.SernosTransactions;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenUpdatingSernosTrans : ContextBase
    {
        private SernosTransactionResource requestResource;

        [SetUp]
        public void SetUp()
        {
            this.requestResource = new SernosTransactionResource { TransDescription = "d" };
            var sernosTrans = new SernosTrans { TransCode = "t", TransDescription = "d" };
            this.SernosTransactionService.Update("t", Arg.Any<SernosTransactionResource>())
                .Returns(new SuccessResult<SernosTrans>(sernosTrans)
                             {
                                 Data = sernosTrans
                             });

            this.Response = this.Browser.Put(
                "/products/maint/serial-number-transactions/t",
                with =>
                {
                    with.Header("Accept", "application/json");
                    with.Header("Content-Type", "application/json");
                    with.JsonBody(this.requestResource);
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
            this.SernosTransactionService.Received()
                .Update(
                    "t",
                    Arg.Is<SernosTransactionResource>(r => r.TransDescription == this.requestResource.TransDescription));
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<SernosTransactionResource>();
            resource.TransCode.Should().Be("t");
            resource.TransDescription.Should().Be("d");
        }
    }
}