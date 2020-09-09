namespace Linn.Products.Service.Extensions
{
    using System.Collections.Generic;
    using Linn.Products.Domain.Products;
    using Linn.Products.Resources.MessageResources;
    using Linn.Products.Resources.ProductsResources;

    public static class SalesPartExtensions
    {
        public static SalesPartResource ToResource(this ProductSalesPart salesPart)
        {
            var resource = new SalesPartResource
            {
                id = salesPart.Id,
                ean = salesPart.Ean,
                weightInKg = salesPart.WeightInKg,
                createdOn = salesPart.CreatedOn,
                phasedInOn = salesPart.PhasedInOn,
                phasedOutOn = salesPart.PhasedOutOn,
                description = salesPart.Description,
                shortDescription = salesPart.ShortDescription,
                barcodePrefix = salesPart.BarcodePrefix,
                minimumOrderQuantity = salesPart.MinimumOrderQuantity,
                orderMultiple = salesPart.OrderMultiple,
                name = salesPart.Name,
                usTariffCode = salesPart.UnitedStatesTariffCode,
                exDem = salesPart.ExDem,
                notes = salesPart.Notes,
                orderInformation = salesPart.OrderInformation,
                productType = "Sales Part",
                extraBuildWeeks = salesPart.ExtraBuildWeeks,
                attributes = salesPart.Attributes.ToResource(),
                maximumOrderQuantity = salesPart.MaximumOrderQuantity,
                weeeProduct = salesPart.WeeeProduct,
                nettWeight = salesPart.NettWeight,
                dimensionOver50Cm = salesPart.DimensionOver50Cm,
                weeeCategory = salesPart.WeeeCategory,
                mainsCablesPerProduct = salesPart.MainsCablesPerProduct,
                packagingNettWeight = salesPart.PackagingNettWeight,
                packagingFoamNettWeight = salesPart.PackagingFoamNettWeight
            };

            resource.links = new List<LinkResource>
                                 {
                                     new LinkResource
                                         {
                                             rel = "self",
                                             href = resource.href
                                         },
                                     new LinkResource
                                         {
                                             rel = "phase-in",
                                             href = resource.href + "/phase-in"
                                         },
                                     new LinkResource
                                         {
                                             rel = "phase-out",
                                             href = resource.href + "/phase-out"
                                         }
                                 };

            if (salesPart.TypeOfSerialNumber != null)
            {
                var typeOfSerialNumberResource = salesPart.TypeOfSerialNumber.ToResource();
                resource.typeOfSerialNumber = typeOfSerialNumberResource;
                resource.links.Add(new LinkResource { rel = "type-of-serial-number", href = typeOfSerialNumberResource.href });
            }

            if (salesPart.Tariff != null)
            {
                var tariffResource = salesPart.Tariff.ToResource();
                resource.tariff = tariffResource;
                resource.links.Add(new LinkResource { rel = "tariff", href = tariffResource.href });
            }

            if (salesPart.OrderType != null)
            {
                var orderTyperesource = salesPart.OrderType.ToResource();
                resource.orderType = orderTyperesource;
                resource.links.Add(new LinkResource { rel = "order-type", href = orderTyperesource.href });
            }

            if (salesPart.SerialNumberSource != null)
            {
                var serialNumberSourceResource = salesPart.SerialNumberSource.ToResource();
                resource.serialNumberSource = serialNumberSourceResource;
                resource.links.Add(new LinkResource { rel = "serial-number-source", href = serialNumberSourceResource.href });
            }

            if (salesPart.Carton != null)
            {
                var cartonResource = salesPart.Carton.ToResource();
                resource.carton = cartonResource;
                resource.links.Add(new LinkResource { rel = "carton", href = cartonResource.href });
            }

            if (salesPart.AccountingCompany != null)
            {
                var accountingCompanyResource = salesPart.AccountingCompany.ToResource();
                resource.accountingCompany = accountingCompanyResource;
                resource.links.Add(new LinkResource { rel = "accounting-company", href = accountingCompanyResource.href });
            }

            if (salesPart.Cit != null)
            {
                var citResource = salesPart.Cit.ToResource();
                resource.cit = citResource;
                resource.links.Add(new LinkResource { rel = "cit", href = citResource.href });
            }

            if (salesPart.TypeOfSale != null)
            {
                var typeOfSaleResource = salesPart.TypeOfSale.ToResource();
                resource.typeOfSale = typeOfSaleResource;
                resource.links.Add(new LinkResource { rel = "type-of-sale", href = typeOfSaleResource.href });
            }

            if (salesPart.RootProduct != null)
            {
                var rootProductResource = salesPart.RootProduct.ToResource();
                resource.rootProduct = rootProductResource;
                resource.links.Add(new LinkResource { rel = "root-product", href = rootProductResource.href });
            }

            if (salesPart.VatCode != null)
            {
                var vatCodeResource = salesPart.VatCode.ToResource();
                resource.vatCode = vatCodeResource;
                resource.links.Add(new LinkResource { rel = "vat-code", href = vatCodeResource.href });
            }

            if (salesPart.CountryOfOrigin != null)
            {
                resource.links.Add(new LinkResource { rel = "country", href = salesPart.CountryOfOrigin.ToString() });
            }

            if (salesPart.CreatedBy != null)
            {
                var createdByResource = new LinkResource("created-by", salesPart.CreatedBy.ToString());
                resource.createdBy = createdByResource;
                resource.links.Add(new LinkResource { rel = "created-by", href = createdByResource.href });
            }

            if (salesPart.PhasedOutBy != null)
            {
                var phasedOutByResource = new LinkResource("phased-out-by", salesPart.PhasedOutBy.ToString());
                resource.phasedOutBy = phasedOutByResource;
                resource.links.Add(new LinkResource { rel = "phased-out-by", href = phasedOutByResource.href });
            }

            if (salesPart.Labels != null)
            {
                var labelsResource = salesPart.Labels.ToResource(salesPart.Id.Value);
                resource.labels = labelsResource;
            }

            if (salesPart.HasLabel("box"))
            {
                resource.links.Add(new LinkResource { rel = "box-label", href = $"{resource.href}/labels/box" });
            }

            if (salesPart.HasLabel("product"))
            {
                resource.links.Add(new LinkResource { rel = "product-label", href = $"{resource.href}/labels/product" });
            }

            if (salesPart.HasLabel("cartridge"))
            {
                resource.links.Add(new LinkResource { rel = "cartridge-label", href = $"{resource.href}/labels/cartridge" });
            }

            if (salesPart.ReplacedByPart != null)
            {
                resource.links.Add(new LinkResource { rel = "replaced-by", href = salesPart.ReplacedByPart.ToResource().href });
            }

            return resource;
        }

        public static SalesPartMessageResource ToMessageResource(this ProductSalesPart salesPart)
        {
            var resource = new SalesPartMessageResource
            {
                id = salesPart.Id.Value,
                ean = salesPart.Ean,
                weightInKg = salesPart.WeightInKg,
                createdOn = salesPart.CreatedOn,
                phasedInOn = salesPart.PhasedInOn,
                phasedOutOn = salesPart.PhasedOutOn,
                description = salesPart.Description,
                shortDescription = salesPart.ShortDescription,
                barcodePrefix = salesPart.BarcodePrefix,
                minimumOrderQuantity = salesPart.MinimumOrderQuantity,
                orderMultiple = salesPart.OrderMultiple,
                name = salesPart.Name,
                usTariffCode = salesPart.UnitedStatesTariffCode,
                exDem = salesPart.ExDem,
                notes = salesPart.Notes,
                orderInformation = salesPart.OrderInformation,
                productType = "Sales Part",
                extraBuildWeeks = salesPart.ExtraBuildWeeks,
                attributes = salesPart.Attributes.ToResource(),
                maximumOrderQuantity = salesPart.MaximumOrderQuantity
            };

            resource.links = new List<LinkResource>
                                 {
                                     new LinkResource
                                         {
                                             rel = "self",
                                             href = resource.href
                                         },
                                     new LinkResource
                                         {
                                             rel = "phase-in",
                                             href = resource.href + "/phase-in"
                                         },
                                     new LinkResource
                                         {
                                             rel = "phase-out",
                                             href = resource.href + "/phase-out"
                                         }
                                 };

            if (salesPart.TypeOfSerialNumber != null)
            {
                var typeOfSerialNumberResource = salesPart.TypeOfSerialNumber.ToResource();
                resource.typeOfSerialNumber = typeOfSerialNumberResource;
                resource.links.Add(new LinkResource { rel = "type-of-serial-number", href = typeOfSerialNumberResource.href });
            }

            if (salesPart.Tariff != null)
            {
                var tariffResource = salesPart.Tariff.ToResource();
                resource.tariff = tariffResource;
                resource.links.Add(new LinkResource { rel = "tariff", href = tariffResource.href });
            }

            if (salesPart.OrderType != null)
            {
                var orderTyperesource = salesPart.OrderType.ToResource();
                resource.orderType = orderTyperesource;
                resource.links.Add(new LinkResource { rel = "order-type", href = orderTyperesource.href });
            }

            if (salesPart.SerialNumberSource != null)
            {
                var serialNumberSourceResource = salesPart.SerialNumberSource.ToResource();
                resource.serialNumberSource = serialNumberSourceResource;
                resource.links.Add(new LinkResource { rel = "serial-number-source", href = serialNumberSourceResource.href });
            }

            if (salesPart.Carton != null)
            {
                var cartonResource = salesPart.Carton.ToResource();
                resource.carton = cartonResource;
                resource.links.Add(new LinkResource { rel = "carton", href = cartonResource.href });
            }

            if (salesPart.AccountingCompany != null)
            {
                var accountingCompanyResource = salesPart.AccountingCompany.ToResource();
                resource.accountingCompany = accountingCompanyResource;
                resource.links.Add(new LinkResource { rel = "accounting-company", href = accountingCompanyResource.href });
            }

            if (salesPart.Cit != null)
            {
                var citResource = salesPart.Cit.ToResource();
                resource.cit = citResource;
                resource.links.Add(new LinkResource { rel = "cit", href = citResource.href });
            }

            if (salesPart.TypeOfSale != null)
            {
                var typeOfSaleResource = salesPart.TypeOfSale.ToResource();
                resource.typeOfSale = typeOfSaleResource;
                resource.links.Add(new LinkResource { rel = "type-of-sale", href = typeOfSaleResource.href });
            }

            if (salesPart.RootProduct != null)
            {
                var rootProductResource = salesPart.RootProduct.ToMessageResource();
                resource.rootProduct = rootProductResource;
                resource.links.Add(new LinkResource { rel = "root-product", href = rootProductResource.href });
            }

            if (salesPart.VatCode != null)
            {
                var vatCodeResource = salesPart.VatCode.ToResource();
                resource.vatCode = vatCodeResource;
                resource.links.Add(new LinkResource { rel = "vat-code", href = vatCodeResource.href });
            }

            if (salesPart.CountryOfOrigin != null)
            {
                resource.links.Add(new LinkResource { rel = "country", href = salesPart.CountryOfOrigin.ToString() });
            }

            if (salesPart.CreatedBy != null)
            {
                var createdByResource = new LinkResource("created-by", salesPart.CreatedBy.ToString());
                resource.createdBy = createdByResource;
                resource.links.Add(new LinkResource { rel = "created-by", href = createdByResource.href });
            }

            if (salesPart.PhasedOutBy != null)
            {
                var phasedOutByResource = new LinkResource("phased-out-by", salesPart.PhasedOutBy.ToString());
                resource.phasedOutBy = phasedOutByResource;
                resource.links.Add(new LinkResource { rel = "phased-out-by", href = phasedOutByResource.href });
            }

            if (salesPart.Labels != null)
            {
                var labelsResource = salesPart.Labels.ToResource(salesPart.Id.Value);
                resource.labels = labelsResource;
            }

            if (salesPart.HasLabel("box"))
            {
                resource.links.Add(new LinkResource { rel = "box-label", href = $"{resource.href}/labels/box" });
            }

            if (salesPart.HasLabel("product"))
            {
                resource.links.Add(new LinkResource { rel = "product-label", href = $"{resource.href}/labels/product" });
            }

            if (salesPart.HasLabel("cartridge"))
            {
                resource.links.Add(new LinkResource { rel = "cartridge-label", href = $"{resource.href}/labels/cartridge" });
            }

            if (salesPart.ReplacedByPart != null)
            {
                resource.links.Add(new LinkResource { rel = "replaced-by", href = salesPart.ReplacedByPart.ToResource().href });
            }

            return resource;
        }
    }
}
