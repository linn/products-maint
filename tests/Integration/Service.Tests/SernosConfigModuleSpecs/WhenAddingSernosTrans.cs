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

    public class WhenAddingSernosTrans : ContextBase
    {
        private SernosTransactionResource requestResource;

        [SetUp]
        public void SetUp()
        {
            this.requestResource = new SernosTransactionResource { TransCode = "a" };
            var sernosTrans = new SernosTrans { TransCode = "a" };
            this.SernosTransactionService.Add(Arg.Any<SernosTransactionResource>())
                .Returns(new CreatedResult<SernosTrans>(sernosTrans)
                             {
                                 Data = sernosTrans
                             });

            this.Response = this.Browser.Post(
                "/products/maint/serial-number-transactions",
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
            this.SernosTransactionService
                .Received().Add(Arg.Is<SernosTransactionResource>(r => r.TransCode == this.requestResource.TransCode));
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<SernosTransactionResource>();
            resource.TransCode.Should().Be("a");
        }
    }
}