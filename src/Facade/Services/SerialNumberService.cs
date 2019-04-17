namespace Linn.Products.Facade.Services
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Linn.Common.Facade;
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Facade.Extensions;
    using Linn.Products.Resources;

    public class SerialNumberService : FacadeService<SerialNumber, int, SerialNumberResource, SerialNumberResource>
    {
        public SerialNumberService(IRepository<SerialNumber, int> repository, ITransactionManager transactionManager)
            : base(repository, transactionManager)
        {
        }

        protected override SerialNumber CreateFromResource(SerialNumberResource resource)
        {
            return new SerialNumber(
                    resource.SernosTRef,
                    resource.SernosGroup,
                    resource.TransCode,
                    resource.ArticleNumber,
                    resource.Links.FirstOrDefault(a => a.Rel == "entered-by").Href.ParseId())
                    {
                        DocumentType = resource.DocumentType,
                        DocumentNumber = resource.DocumentNumber,
                        PrevSernosNumber = resource.PrevSernosNumber,
                        SernosDate = string.IsNullOrEmpty(resource.SernosDate)
                                ? (DateTime?)null
                                : DateTime.Parse(resource.SernosDate)
                    };
        }

        protected override void UpdateFromResource(SerialNumber entity, SerialNumberResource updateResource)
        {
            throw new NotImplementedException();
        }

        protected override Expression<Func<SerialNumber, bool>> SearchExpression(string searchTerm)
        {
            return serialNumber => serialNumber.SernosNumber.ToString().Equals(searchTerm);
        }
    }
}