namespace Linn.Products.Facade.ResourceBuilders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class SerialNumberResourceBuilder : IResourceBuilder<ResponseModel<SerialNumber>>
    {
        public SerialNumberResource Build(ResponseModel<SerialNumber> serialNumberModel)
        {
            return new SerialNumberResource
                       {
                           ArticleNumber = serialNumberModel.Entity.ArticleNumber,
                           DocumentNumber = serialNumberModel.Entity.DocumentNumber,
                           DocumentType = serialNumberModel.Entity.DocumentType,
                           PrevSernosNumber = serialNumberModel.Entity.PrevSernosNumber,
                           SernosDate = serialNumberModel.Entity.SernosDate?.ToString("o"),
                           SernosGroup = serialNumberModel.Entity.SernosGroup,
                           SernosNumber = serialNumberModel.Entity.SernosNumber,
                           SernosTRef = serialNumberModel.Entity.SernosTRef,
                           TransCode = serialNumberModel.Entity.TransCode,
                           Links = this.BuildLinks(serialNumberModel).ToArray()
                       };
        }

        public string GetLocation(ResponseModel<SerialNumber> serialNumberModel)
        {
            return $"/products/maint/serial-numbers/{serialNumberModel.Entity.SernosTRef}";
        }

        object IResourceBuilder<ResponseModel<SerialNumber>>.Build(ResponseModel<SerialNumber> serialNumberModel) => this.Build(serialNumberModel);

        private IEnumerable<LinkResource> BuildLinks(ResponseModel<SerialNumber> serialNumberModel)
        {
            yield return new LinkResource { Rel = "self", Href = this.GetLocation(serialNumberModel) };

            yield return new LinkResource
                             {
                                 Rel = "sales-article",
                                 Href = $"/products/maint/sales-articles/{Uri.EscapeDataString(serialNumberModel.Entity.ArticleNumber)}"
                             };

            yield return new LinkResource { Rel = "entered-by", Href = $"/employees/{serialNumberModel.Entity.CreatedBy}" };
        }
    }
}
