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

    public class ProductRangeProxy : IProductRangeRepository
    {
        private readonly IRestClient restClient;

        private readonly string rootUri;

        public ProductRangeProxy(IRestClient restClient, string rootUri)
        {
            this.restClient = restClient;
            this.rootUri = rootUri;
        }

        public IEnumerable<ProductRange> GetProductRanges()
        {
            var uri = new Uri($"{this.rootUri}/products/product-ranges", UriKind.RelativeOrAbsolute);
            var response = this.restClient.Get(
                CancellationToken.None,
                uri,
                new Dictionary<string, string>(),
                DefaultHeaders.JsonGetHeaders()).Result;

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ProxyException($"Error trying to get product ranges");
            }

            var json = new JsonSerializer();
            var results = json.Deserialize<IEnumerable<ProductRangeResource>>(response.Value);

            return results.Select(p => new ProductRange(p.Name) { Id = p.Id, Description = p.Description, PhasedOutOn = p.phasedOutOn });
        }
    }
}
