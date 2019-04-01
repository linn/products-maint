namespace Linn.Products.Facade.ResourceBuilders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class SerialNumberResourceBuilder : IResourceBuilder<SerialNumber>
    {
        public SerialNumberResource Build(SerialNumber serialNumber)
        {
            return new SerialNumberResource
                       {
                           AccountId = serialNumber.AccountId,
                           ArticleNumber = serialNumber.ArticleNumber,
                           CreatedBy = serialNumber.CreatedBy,
                           DatePostedToVax = serialNumber.DatePostedToVax?.ToString("o"),
                           DocumentLine = serialNumber.DocumentLine,
                           DocumentNumber = serialNumber.DocumentNumber,
                           DocumentType = serialNumber.DocumentType,
                           OutletNumber = serialNumber.OutletNumber,
                           PrevSernosNumber = serialNumber.PrevSernosNumber,
                           SernosDate = serialNumber.SernosDate?.ToString("o"),
                           SernosGroup = serialNumber.SernosGroup,
                           SernosNumber = serialNumber.SernosNumber,
                           SernosNote = serialNumber.SernosNote,
                           SernosTref = serialNumber.SernosTRef,
                           TransCode = serialNumber.TransCode,
                           Links = this.BuildLinks(serialNumber).ToArray()
                       };
        }

        public string GetLocation(SerialNumber serialNumber)
        {
            return $"/products/maint/serial-numbers/{serialNumber.SernosTRef}";
        }

        object IResourceBuilder<SerialNumber>.Build(SerialNumber serialNumber) => this.Build(serialNumber);

        private IEnumerable<LinkResource> BuildLinks(SerialNumber serialNumber)
        {
            yield return new LinkResource { Rel = "self", Href = this.GetLocation(serialNumber) };

            yield return new LinkResource
                             {
                                 Rel = "sales-article",
                                 Href = $"/products/maint/sales-articles/{Uri.EscapeDataString(serialNumber.ArticleNumber)}"
                             };

            if (serialNumber.SernosNote != null)
            {
                yield return new LinkResource
                                 {
                                     Rel = "sernos-note",
                                     Href = $"/products/maint/serial-numbers/notes/{serialNumber.SernosNote.SernosNoteId}"
                                 };
            }
        }
    }
}
