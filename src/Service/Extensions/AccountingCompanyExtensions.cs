namespace Linn.Products.Service.Extensions
{
    using Linn.Products.Domain.Products;
    using Linn.Products.Resources.ProductsResources;

    public static class AccountingCompanyExtensions
    {
        public static AccountingCompanyResource ToResource(this AccountingCompany accountingCompany)
        {
            return new AccountingCompanyResource
                {
                    createdBy = accountingCompany.CreatedBy == null ? null : new LinkResource("created-by", accountingCompany.CreatedBy),
                    createdOn = accountingCompany.CreatedOn,
                    description = accountingCompany.Description,
                    phasedOutBy = accountingCompany.PhasedOutBy == null ? null : new LinkResource("phased-out-by", accountingCompany.PhasedOutBy),
                    id = accountingCompany.Id,
                    phasedOutOn = accountingCompany.PhasedOutOn,
                    name = accountingCompany.Name
                };
        }
    }
}
