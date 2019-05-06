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

    public class WhenGettingSernosTransaction : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var sernosTrans = new SernosTrans
                                  {
                                      TransCode = "t",
                                      TransDescription = "d"
                                  };
            this.SernosTransactionService.GetById("t")
                .Returns(new SuccessResult<SernosTrans>(sernosTrans)
                             {
                                 Data = sernosTrans
                             });

            this.Response = this.Browser.Get(
                "/products/maint/serial-number-transactions/t",
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
            this.SernosTransactionService.Received().GetById("t");
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