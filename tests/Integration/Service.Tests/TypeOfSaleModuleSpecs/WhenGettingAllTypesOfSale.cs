namespace Linn.Products.Service.Tests.TypeOfSaleModuleSpecs
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingAllTypesOfSale : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var typeOfSale1 = new TypeOfSale("name1", "desc", "nom", "dept", "Y");
            var typeOfSale2 = new TypeOfSale("name2", "desc", "nom", "dept", "Y");
            this.TypeOfSaleService.GetAll().Returns(
                new SuccessResult<IEnumerable<TypeOfSale>>(new List<TypeOfSale> { typeOfSale1, typeOfSale2 }));

            this.Response = this.Browser.Get(
                "/products/maint/types-of-sale",
                with => { with.Header("Accept", "application/json"); }).Result;
        }

        [Test]
        public void ShouldReturnOk()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void ShouldCallService()
        {
            this.TypeOfSaleService.Received().GetAll();
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resources = this.Response.Body.DeserializeJson<IEnumerable<TypeOfSaleResource>>().ToList();
            resources.Should().HaveCount(2);
            resources.Should().Contain(a => a.Name == "name1");
            resources.Should().Contain(a => a.Name == "name2");
        }
    }
}
