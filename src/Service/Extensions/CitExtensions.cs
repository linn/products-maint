namespace Linn.Products.Service.Extensions
{
    using Linn.Products.Domain.Products;
    using Linn.Products.Resources.ProductsResources;

    public static class CitExtensions
    {
        public static CitResource ToResource(this Cit cit)
        {
            var resource = new CitResource
                {
                    id = cit.Id,
                    createdBy = cit.CreatedBy == null ? null : new LinkResource("created-by", cit.CreatedBy.ToString()),
                    createdOn = cit.CreatedOn,
                    phasedOutBy = cit.PhasedOutBy == null ? null : new LinkResource("created-by", cit.PhasedOutBy.ToString()),
                    phasedOutOn = cit.PhasedOutOn,
                    code = cit.Code,
                    description = cit.Description
                };
            return resource;
        }
    }
}
