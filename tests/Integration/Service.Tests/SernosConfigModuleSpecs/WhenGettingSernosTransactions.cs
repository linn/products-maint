namespace Linn.Products.Service.Tests.SernosConfigModuleSpecs
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.SernosTransactions;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingSernosTransactions : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var sernosTrans1 = new SernosTrans
                                  {
                                      TransCode = "1",
                                      TransDescription = "d1"
                                  };
            var sernosTrans2 = new SernosTrans
                                  {
                                      TransCode = "2",
                                      TransDescription = "d2"
                                  };
            this.SernosTransactionService.GetAll()
                .Returns(new SuccessResult<IEnumerable<SernosTrans>>(new[] { sernosTrans1, sernosTrans2 }));

            this.Response = this.Browser.Get(
                "/products/maint/serial-number-transactions",
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
            this.SernosTransactionService.Received().GetAll();
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<IEnumerable<SernosTransactionResource>>().ToList();
            resource.Should().HaveCount(2);
            resource.Should().Contain(a => a.TransCode == "1");
            resource.Should().Contain(a => a.TransCode == "2");
        }
    }
}