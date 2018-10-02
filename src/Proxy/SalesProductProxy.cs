namespace Linn.Products.Proxy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading;

    using Linn.Common.Proxy;
    using Linn.Common.Serialization.Json;
    using Linn.Products.Domain;
    using Linn.Products.Domain.Repositories;
    using Linn.Products.Proxy.Exceptions;
    using Linn.Products.Resources.External;

    public class SalesProductProxy : ISalesProductRepository
    {
        private readonly IRestClient restClient;

        private readonly string rootUri;

        public SalesProductProxy(IRestClient restClient, string rootUri)
        {
            this.restClient = restClient;
            this.rootUri = rootUri;
        }

        public IEnumerable<SalesProduct> GetSalesProducts()
        {
            var uri = new Uri($"{this.rootUri}/products/sales-products", UriKind.RelativeOrAbsolute);
            var response = this.restClient.Get(
                CancellationToken.None,
                uri,
                new Dictionary<string, string>(),
                DefaultHeaders.JsonGetHeaders()).Result;

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ProxyException($"Error trying to get sales products");
            }

            var json = new JsonSerializer();
            var results = json.Deserialize<IEnumerable<SalesProductResource>>(response.Value);

            return results.Select(p => new SalesProduct(p.Name)
                                           {
                                               Id = p.Id,
                                               Description = p.Description,
                                               ProductRange = p.ProductRange == null ? null : new ProductRange(p.ProductRange.Name) { Id = p.ProductRange.Id },
                                               PhasedOutOn = string.IsNullOrEmpty(p.PhasedOutOn) ? (DateTime?)null : DateTime.Parse(p.PhasedOutOn)
                                           });
        }
    }
}
