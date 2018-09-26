namespace Linn.Products.Proxy.Tests.SalesArticleProxyTests
{
    using Linn.Common.Proxy;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected SalesArticleProxy Sut { get; private set; }

        protected IRestClient RestClient { get; private set; }

        protected string ProxyRoot { get; private set; }

        [SetUp]
        public void EstablishContext()
        {
            this.ProxyRoot = "http://app.linn.co.uk";
            this.RestClient = Substitute.For<IRestClient>();
            this.Sut = new SalesArticleProxy(this.RestClient, this.ProxyRoot);
        }
    }
}
