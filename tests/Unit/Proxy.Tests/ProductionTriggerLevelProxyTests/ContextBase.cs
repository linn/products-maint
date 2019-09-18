namespace Linn.Products.Proxy.Tests.ProductionTriggerLevelProxyTests
{
    using Linn.Common.Proxy;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected ProductionTriggerLevelsProxyService Sut { get; private set; }

        protected IRestClient RestClient { get; private set; }

        protected string ProxyRoot { get; private set; }

        [SetUp]
        public void EstablishContext()
        {
            this.ProxyRoot = "http://app.linn.co.uk";
            this.RestClient = Substitute.For<IRestClient>();
            this.Sut = new ProductionTriggerLevelsProxyService(this.RestClient, this.ProxyRoot);
        }
    }
}
