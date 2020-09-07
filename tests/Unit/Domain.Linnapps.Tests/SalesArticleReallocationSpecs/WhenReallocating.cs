namespace Linn.Products.Domain.Linnapps.Tests.SalesArticleReallocationSpecs
{
    using System.Linq;

    using FluentAssertions;
    using FluentAssertions.Extensions;

    using Linn.Products.Domain.Linnapps;

    using NUnit.Framework;

    public class WhenReallocating: ContextBase
    {

        [SetUp]
        public void SetUp()
        {
          this.Result = this.SalesArticleReallocationService.Reallocate(118, 59);
        }

        [Test]
        public void ShouldUpdateTariffIdOfArticles()
        {
            this.Result.Count.Should().Be(3);
        }
    }
}
