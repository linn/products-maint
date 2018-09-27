namespace Linn.Products.Proxy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading;

    using Linn.Common.Proxy;
    using Linn.Common.Serialization.Json;
    using Linn.Products.Domain.Products;
    using Linn.Products.Domain.RemoteServices;
    using Linn.Products.Proxy.Exceptions;
    using Linn.Products.Resources.External;

    public class SalesArticleProxy : ISalesArticleService
    {
        private readonly IRestClient restClient;

        private readonly string rootUri;

        public SalesArticleProxy(IRestClient restClient, string rootUri)
        {
            this.restClient = restClient;
            this.rootUri = rootUri;
        }

        public IEnumerable<SalesArticle> Search(string searchTerm)
        {
            var uri = new Uri($"{this.rootUri}/linnapps-api/sales-articles/search?searchTerm={searchTerm}", UriKind.RelativeOrAbsolute);
            var response = this.restClient.Get(
                CancellationToken.None,
                uri,
                new Dictionary<string, string>(),
                DefaultHeaders.JsonGetHeaders()).Result;

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ProxyException($"Error trying to execute search");
            }

            var json = new JsonSerializer();
            return json.Deserialize<IEnumerable<SalesArticle>>(response.Value);
        }

        public IEnumerable<SalesArticle> GetByDiscountFamily(string discountFamily, bool includePhasedOut = false)
        {
            var uri = new Uri($"{this.rootUri}/linnapps-api/sales-articles", UriKind.RelativeOrAbsolute);
            var response = this.restClient.Get(
                CancellationToken.None,
                uri,
                new Dictionary<string, string>(),
                DefaultHeaders.JsonGetHeaders()).Result;

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ProxyException($"Error trying to get sales articles");
            }

            var json = new JsonSerializer();
            var resources = json.Deserialize<IEnumerable<SalesArticleResource>>(response.Value);
            return resources
                .Where(a => a.DiscountFamily == discountFamily && a.PhaseOutDate.HasValue == includePhasedOut)
                .Select(r => new SalesArticle
                                 {
                                     ArticleNumber = r.ArticleNumber,
                                     InvoiceDescription = r.InvoiceDescription,
                                     EanCode = r.EanCode,
                                     CartonType = r.CartonType
                                 });
        }
    }
}
