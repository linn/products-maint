namespace Linn.Products.Proxy.Tests.SalesPartProxyTests
{
    using Linn.Common.Proxy;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected SalesPartProxy Sut { get; private set; }

        protected IRestClient RestClient { get; private set; }

        protected string ProxyRoot { get; private set; }

        [SetUp]
        public void EstablishContext()
        {
            this.ProxyRoot = "http://app.linn.co.uk";
            this.RestClient = Substitute.For<IRestClient>();
            this.Sut = new SalesPartProxy(this.RestClient, this.ProxyRoot);
        }
    }
}
