namespace Linn.Products.Proxy
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading;

    using Linn.Common.Proxy;
    using Linn.Common.Serialization.Json;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Repositories;
    using Linn.Products.Proxy.Exceptions;

    public class SaHoldStoriesProxy : ISaHoldStoryRepository
    {
        private readonly IRestClient restClient;

        private readonly string rootUri;

        private readonly Uri saHoldStoriesUri;

        public SaHoldStoriesProxy(IRestClient restClient, string rootUri)
        {
            this.restClient = restClient;
            this.rootUri = "http://localhost:51798"; // rootUri
            this.saHoldStoriesUri = new Uri($"{this.rootUri}/products/sa-hold-stories", UriKind.RelativeOrAbsolute);
        }

        public IEnumerable<SaHoldStory> GetSaHoldStories()
        {
            var response = this.restClient.Get(
                CancellationToken.None,
                this.saHoldStoriesUri,
                new Dictionary<string, string>(),
                DefaultHeaders.JsonGetHeaders()).Result;

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ProxyException($"Error trying to get stories");
            }

            var json = new JsonSerializer();
            return json.Deserialize<IEnumerable<SaHoldStory>>(response.Value);
        }
    }
}
