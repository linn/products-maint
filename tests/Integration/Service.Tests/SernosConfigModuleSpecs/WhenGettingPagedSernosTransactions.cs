namespace Linn.Products.Service.Tests.SernosConfigModuleSpecs
{
    using System.Linq;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.SernosTransactions;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    using PagedList.Core;

    public class WhenGettingPagedSernosTransactions : ContextBase
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
            this.SernosTransactionService.GetAll(1, 2).Returns(
                new SuccessResult<IPagedList<SernosTrans>>(
                    new PagedList<SernosTrans>(new[] { sernosTrans1, sernosTrans2 }.AsQueryable(), 1, 2)));

            this.Response = this.Browser.Get(
                "/products/maint/serial-number-transactions/1/2",
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
            this.SernosTransactionService.Received().GetAll(1, 2);
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<PaginatedResource<SernosTransactionResource>>();
            resource.Elements.Should().HaveCount(2);
            resource.Elements.Should().Contain(a => a.TransCode == "1");
            resource.Elements.Should().Contain(a => a.TransCode == "2");
            resource.PageSize.Should().Be(2);
            resource.PageNumber.Should().Be(1);
        }
    }
}