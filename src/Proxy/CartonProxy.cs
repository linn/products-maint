namespace Linn.Products.Proxy
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading;

    using Linn.Common.Proxy;
    using Linn.Common.Serialization.Json;
    using Linn.Products.Domain;
    using Linn.Products.Domain.Repositories;
    using Linn.Products.Proxy.Exceptions;

    public class CartonProxy : ICartonRepository
    {
        private readonly IRestClient restClient;

        private readonly string rootUri;

        public CartonProxy(IRestClient restClient, string rootUri)
        {
            this.restClient = restClient;
            this.rootUri = rootUri;
        }

        public IEnumerable<Carton> GetCartons()
        {
            var uri = new Uri($"{this.rootUri}/products/cartons", UriKind.RelativeOrAbsolute);
            var response = this.restClient.Get(
                CancellationToken.None,
                uri,
                new Dictionary<string, string>(),
                DefaultHeaders.JsonGetHeaders()).Result;

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ProxyException($"Error trying to get cartons");
            }

            var json = new JsonSerializer();
            return json.Deserialize<IEnumerable<Carton>>(response.Value);
        }
    }
}
