namespace Linn.Products.Service.Tests.SernosTransModuleSpecs
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

    public class WhenGettingAllSernosTrans : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var sernosTrans1 = new SernosTrans { TransCode = "code1", TransDescription = "desc1", Comments = "comments1" };
            var sernosTrans2 = new SernosTrans { TransCode = "code2", TransDescription = "desc2", Comments = "comments2" };

            this.SernosTransService.GetAll().Returns(
                new SuccessResult<IEnumerable<SernosTrans>>(new List<SernosTrans> { sernosTrans1, sernosTrans2 }));

            this.Response = this.Browser.Get(
                "/products/maint/sernos-trans",
                with => { with.Header("Accept", "application/json"); }).Result;
        }

        [Test]
        public void ShouldCallService()
        {
            this.SernosTransService.Received().GetAll();
        }

        [Test]
        public void ShouldReturnOk()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resources = this.Response.Body.DeserializeJson<IEnumerable<SernosTransResource>>().ToList();
            resources.Should().HaveCount(2);
            resources.Should().Contain(s => s.TransCode == "code1");
            resources.Should().Contain(s => s.TransCode == "code2");
        }
    }
}
