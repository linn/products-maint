﻿namespace Linn.Products.Proxy
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

    public class SalesPartProxy : ISalesPartRepository
    {
        private readonly IRestClient restClient;

        private readonly string rootUri;

        public SalesPartProxy(IRestClient restClient, string rootUri)
        {
            this.restClient = restClient;
            this.rootUri = rootUri;
        }

        public IEnumerable<SalesPart> GetWEEESalesProducts()
        {
            var uri = new Uri($"http://localhost:51620/products/sales-parts/weee-parts", UriKind.RelativeOrAbsolute);

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
            var results = json.Deserialize<IEnumerable<SalesPartResource>>(response.Value);

            return results.Select(
                p => new SalesPart()
                         {
                             Description = p.Description,
                             Name = p.Name,
                             WEEEPart = p.WEEEPart,
                             NettWeight = p.NettWeight
                         });
        }
    }
}
