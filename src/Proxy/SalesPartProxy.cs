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
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Domain.Repositories;
    using Linn.Products.Proxy.Exceptions;
    using Linn.Products.Resources;
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

        public IEnumerable<SalesPart> GetWEEESalesParts()
        {
            var uri = new Uri($"{this.rootUri}/products/sales-parts/weee-parts", UriKind.RelativeOrAbsolute);

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
                             DimensionOver50Cm = p.DimensionOver50Cm,
                             MainsCablesPerProduct = p.MainsCablesPerProduct,
                             NettWeight = p.NettWeight,
                             PackagingFoamNettWeight = p.PackagingFoamNettWeight,
                             PackagingNettWeight = p.PackagingNettWeight,
                             WeeeCategory = p.WeeeCategory,
                             WeeeProduct = p.WeeeProduct,
                             RootProduct = p.RootProduct == null
                                               ? null
                                               : new RootProduct
                                                     {
                                                         Name = p.RootProduct.Name,
                                                         Description = p.RootProduct.Description
                                                     }
                         });
        }

        public TariffsReallocator ReallocateSalesParts(int oldTariff, int newTariff)
        {
            var uri = new Uri($"{this.rootUri}/products/tariffs/reallocate", UriKind.RelativeOrAbsolute);
     
            var resource = new TariffReallocatorResource { NewTariffId = newTariff, OldTariffId = oldTariff };

            var response = this.restClient.Post<TariffReallocatorResource>(CancellationToken.None, uri, resource);

            if (response.Result.StatusCode != HttpStatusCode.OK)
            {
                throw new ProxyException($"status code {response.Result.StatusCode}");
            }

            var returnedResource = response.Result.Value;
            var reallocatorToReturn = new TariffsReallocator { Count = returnedResource.Count, NewTariffId = returnedResource.NewTariffId, OldTariffId = returnedResource.OldTariffId };

            return reallocatorToReturn;
        }
    }
}
