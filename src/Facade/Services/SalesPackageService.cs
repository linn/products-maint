namespace Linn.Products.Facade.Services
{
    using System;

    using Linn.Common.Facade;
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps.SalesPackages;
    using Linn.Products.Resources;

    public class SalesPackageService : FacadeService<SalesPackage, int, SalesPackageResource, SalesPackageResource>
    {
        public SalesPackageService(IRepository<SalesPackage, int> repository, ITransactionManager transactionManager)
            : base(repository, transactionManager)
        {
        }

        protected override SalesPackage CreateFromResource(SalesPackageResource resource)
        {
            throw new NotImplementedException();
        }

        protected override void UpdateFromResource(SalesPackage salesPackage, SalesPackageResource resource)
        {
            throw new NotImplementedException();
        }
    }
}
