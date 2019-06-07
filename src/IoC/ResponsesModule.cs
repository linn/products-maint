namespace Linn.Products.IoC
{
    using System.Collections;
    using System.Collections.Generic;

    using Autofac;
    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Models;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Domain.Linnapps.SalesPackages;
    using Linn.Products.Domain.Linnapps.SernosTransactions;
    using Linn.Products.Facade.ResourceBuilders;

    using PagedList.Core;

    public class ResponsesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // resource builders
            builder.RegisterType<ResultsModelResourceBuilder>().As<IResourceBuilder<ResultsModel>>();
            builder.RegisterType<TariffResourceBuilder>().As<IResourceBuilder<ResponseModel<Tariff>>>();
            builder.RegisterType<TariffsResourceBuilder>().As<IResourceBuilder<ResponseModel<IEnumerable<Tariff>>>>();
            builder.RegisterType<CartonTypeResourceBuilder>().As<IResourceBuilder<CartonType>>();
            builder.RegisterType<SernosConfigResourceBuilder>().As<IResourceBuilder<SernosConfig>>();
            builder.RegisterType<SernosConfigsResourceBuilder>().As<IResourceBuilder<IEnumerable<SernosConfig>>>();
            builder.RegisterType<SernosTransactionResourceBuilder>().As<IResourceBuilder<SernosTrans>>();
            builder.RegisterType<SernosTransactionsResourceBuilder>().As<IResourceBuilder<IEnumerable<SernosTrans>>>();
            builder.RegisterType<SernosTransactionsPaginatedResourceBuilder>().As<IResourceBuilder<IPagedList<SernosTrans>>>();
            builder.RegisterType<SernosCountsResourceBuilder>().As<IResourceBuilder<IEnumerable<SernosCount>>>();
            builder.RegisterType<SernosSequenceResourceBuilder>().As<IResourceBuilder<SernosSequence>>();
            builder.RegisterType<SernosSequencesResourceBuilder>().As<IResourceBuilder<IEnumerable<SernosSequence>>>();
            builder.RegisterType<SaCoreTypeResourceBuilder>().As<IResourceBuilder<SaCoreType>>();
            builder.RegisterType<SaCoreTypesResourceBuilder>().As<IResourceBuilder<IEnumerable<SaCoreType>>>();
            builder.RegisterType<SalesArticleResourceBuilder>().As<IResourceBuilder<ResponseModel<SalesArticle>>>();
            builder.RegisterType<SalesArticlesResourceBuilder>().As<IResourceBuilder<IEnumerable<SalesArticle>>>();
            builder.RegisterType<TypeOfSaleResourceBuilder>().As<IResourceBuilder<TypeOfSale>>();
            builder.RegisterType<TypesOfSaleResourceBuilder>().As<IResourceBuilder<IEnumerable<TypeOfSale>>>();
            builder.RegisterType<RootProductResourceBuilder>().As<IResourceBuilder<ResponseModel<RootProduct>>>();
            builder.RegisterType<RootProductsResourceBuilder>().As<IResourceBuilder<IEnumerable<RootProduct>>>();
            builder.RegisterType<SaHoldStoryResourceBuilder>().As<IResourceBuilder<SaHoldStory>>();
            builder.RegisterType<SaHoldStoriesResourceBuilder>().As<IResourceBuilder<IEnumerable<SaHoldStory>>>();
            builder.RegisterType<VatCodeResourceBuilder>().As<IResourceBuilder<ResponseModel<VatCode>>>();
            builder.RegisterType<VatCodesResourceBuilder>().As<IResourceBuilder<ResponseModel<IEnumerable<VatCode>>>>();
            builder.RegisterType<ProductRangeResourceBuilder>().As<IResourceBuilder<ProductRange>>();
            builder.RegisterType<ProductRangesResourceBuilder>().As<IResourceBuilder<IEnumerable<ProductRange>>>();
            builder.RegisterType<SalesPackageResourceBuilder>().As<IResourceBuilder<SalesPackage>>();
            builder.RegisterType<SalesPackagesResourceBuilder>().As<IResourceBuilder<IEnumerable<SalesPackage>>>();
            builder.RegisterType<SerialNumberResourceBuilder>().As<IResourceBuilder<ResponseModel<SerialNumber>>>();
            builder.RegisterType<SerialNumbersResourceBuilder>().As<IResourceBuilder<ResponseModel<IEnumerable<SerialNumber>>>>();
            builder.RegisterType<SernosNoteResourceBuilder>().As<IResourceBuilder<SernosNote>>();
            builder.RegisterType<SernosNotesResourceBuilder>().As<IResourceBuilder<IEnumerable<SernosNote>>>();
            builder.RegisterType<SalesPackagesPaginatedResourceBuilder>()
                .As<IResourceBuilder<IPagedList<SalesPackage>>>();
            builder.RegisterType<SalesArticleCompositeDiscountResourceBuilder>().As<IResourceBuilder<SalesArticleCompositeDiscount>>();
            builder.RegisterType<SalesArticleSerialNumberDetailsResourceBuilder>().As<IResourceBuilder<SalesArticleSerialNumberDetails>>();
        }
    }
}
