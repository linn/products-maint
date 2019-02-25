namespace Linn.Products.Facade.Services
{
    using Linn.Common.Facade;
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class VatCodeService : FacadeService<VatCode, string, VatCodeResource, VatCodeResource>
    {
        public VatCodeService(IRepository<VatCode, string> repository, ITransactionManager transactionManager)
            : base(repository, transactionManager)
        {
        }

        protected override VatCode CreateFromResource(VatCodeResource resource)
        {
            var vatCode = new VatCode(
                resource.Code,
                resource.Description,
                resource.Rate,
                resource.Reason,
                resource.VatReturnId,
                resource.VatOnly);

            return vatCode;
        }

        protected override void UpdateFromResource(VatCode vatCode, VatCodeResource updateResource)
        {
            vatCode.Update(
                updateResource.Code,
                updateResource.Description,
                updateResource.Rate,
                updateResource.Reason,
                updateResource.VatReturnId,
                updateResource.VatOnly);
        }
    }
}