namespace Linn.Products.Proxy
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading;

    using Linn.Common.Proxy;
    using Linn.Common.Serialization.Json;
    using Linn.Products.Domain.Linnapps.Models;
    using Linn.Products.Domain.Linnapps.RemoteServices;
    using Linn.Products.Proxy.Exceptions;

    public class ProductionTriggerLevelsProxyService : IProductionTriggerLevelsService
    {
        private readonly IRestClient restClient;

        private readonly string rootUri;

        public ProductionTriggerLevelsProxyService(IRestClient restClient, string rootUri)
        {
            this.restClient = restClient;
            this.rootUri = rootUri;
        }

        public IEnumerable<ProductionTriggerLevel> GetAll()
        {
            var uri = new Uri(
                $"{this.rootUri}/production/maintenance/production-trigger-levels",
                UriKind.RelativeOrAbsolute);
            var response = this.restClient.Get(
                CancellationToken.None,
                uri,
                new Dictionary<string, string>(),
                DefaultHeaders.JsonGetHeaders()).Result;

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ProxyException($"Error trying to receive production trigger levels");
            }

            var json = new JsonSerializer();
            return json.Deserialize<IEnumerable<ProductionTriggerLevel>>(response.Value);
        }
    }
}