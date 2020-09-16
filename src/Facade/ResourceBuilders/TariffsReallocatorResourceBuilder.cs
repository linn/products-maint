namespace Linn.Products.Facade.ResourceBuilders
{
    using System.Collections.Generic;
    using System.Linq;
    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class TariffsReallocatorResourceBuilder : IResourceBuilder<ResponseModel<TariffsReallocator>>
    {
        public TariffReallocatorResource Build(ResponseModel<TariffsReallocator> tariffsReallocator)
        {
            return new TariffReallocatorResource
            {
                OldTariffId = tariffsReallocator.ResponseData.OldTariffId,
                NewTariffId = tariffsReallocator.ResponseData.NewTariffId,
                Count = tariffsReallocator.ResponseData.Count,
                Links = this.BuildLinks(tariffsReallocator).ToArray()
            };
        }

        object IResourceBuilder<ResponseModel<TariffsReallocator>>.Build(ResponseModel<TariffsReallocator> tariffReallocatorResponseModel) => this.Build(tariffReallocatorResponseModel);

        public string GetLocation(ResponseModel<TariffsReallocator> tariffReallocatorResponseModel)
        {
            return $"/products/maint/tariffs-reallocate";
        }

        private IEnumerable<LinkResource> BuildLinks(ResponseModel<TariffsReallocator> tariffReallocatorResponseModel)
        {
            yield return new LinkResource("self", GetLocation(tariffReallocatorResponseModel));
        }
    }
}
