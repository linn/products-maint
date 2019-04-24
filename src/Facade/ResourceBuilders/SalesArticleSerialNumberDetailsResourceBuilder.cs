namespace Linn.Products.Facade.ResourceBuilders
{
    using System;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.Models;
    using Linn.Products.Resources;

    public class SalesArticleSerialNumberDetailsResourceBuilder : IResourceBuilder<SalesArticleSerialNumberDetails>
    {
        public SalesArticleSerialNumberDetailsResource Build(SalesArticleSerialNumberDetails salesArticleSerialNumberDetails)
        {
            string serialNumbered;

            switch (salesArticleSerialNumberDetails.SerialNumberType)
            {
                case "S":
                    serialNumbered = "Serial numbered in ones";
                    break;
                case "P1":
                    serialNumbered = "Serial numbered in pairs, one box";
                    break;
                case "P2":
                    serialNumbered = "Serial numbered in pairs, two boxes";
                    break;
                case "N":
                    serialNumbered = "Not serial numbered";
                    break;
                default:
                    serialNumbered = null;
                    break;
            }

            return new SalesArticleSerialNumberDetailsResource
                       {
                           SerialNumbered = serialNumbered,
                           SernosGroup = salesArticleSerialNumberDetails.SernosGroup
                       };
        }

        object IResourceBuilder<SalesArticleSerialNumberDetails>.Build(SalesArticleSerialNumberDetails salesArticleSerialNumberDetails) => this.Build(salesArticleSerialNumberDetails);

        public string GetLocation(SalesArticleSerialNumberDetails model)
        {
            throw new NotImplementedException();
        }
    }
}