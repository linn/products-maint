namespace Linn.Products.Service.Tests.SernosTransactionModuleSpecs
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

    public class WhenGettingAllSernosTransactions : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var sernosTrans1 = new SernosTrans { TransCode = "code1", TransDescription = "desc1", Comments = "comments1" };
            var sernosTrans2 = new SernosTrans { TransCode = "code2", TransDescription = "desc2", Comments = "comments2" };

            this.SernosTransactionService.GetAll().Returns(
                new SuccessResult<IEnumerable<SernosTrans>>(new List<SernosTrans> { sernosTrans1, sernosTrans2 }));

            this.Response = this.Browser.Get(
                "/products/maint/sernos-transactions",
                with => { with.Header("Accept", "application/json"); }).Result;
        }

        [Test]
        public void ShouldCallService()
        {
            this.SernosTransactionService.Received().GetAll();
        }

        [Test]
        public void ShouldReturnOk()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resources = this.Response.Body.DeserializeJson<IEnumerable<SernosTransactionResource>>().ToList();
            resources.Should().HaveCount(2);
            resources.Should().Contain(s => s.TransCode == "code1");
            resources.Should().Contain(s => s.TransCode == "code2");
        }
    }
}
