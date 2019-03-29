namespace Linn.Products.Facade.Services
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Linn.Common.Facade;
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps.SalesPackages;
    using Linn.Products.Proxy;
    using Linn.Products.Resources;

    public class SalesPackageService : FacadeService<SalesPackage, int, SalesPackageResource, SalesPackageResource>
    {
        private readonly IDatabaseService linnappsDatabaseService;

        public SalesPackageService(
            IRepository<SalesPackage, int> repository,
            ITransactionManager transactionManager,
            IDatabaseService linnappsDatabaseService)
            : base(repository, transactionManager)
        {
            this.linnappsDatabaseService = linnappsDatabaseService;
        }

        protected override SalesPackage CreateFromResource(SalesPackageResource resource)
        {
            var salesPackage = new SalesPackage
                                   {
                                       Description = resource.Description,
                                       SalesPackageId = resource.SalesPackageId
                                   };
            foreach (var salesPackageElementResource in resource.Elements)
            {
                var newElement = new SalesPackageElement
                                     {
                                         ElementType = salesPackageElementResource.ElementType,
                                         Quantity = salesPackageElementResource.Quantity,
                                         SalesPackageId = salesPackage.SalesPackageId,
                                         Sequence = salesPackageElementResource.Sequence
                                     };
                salesPackage.Elements.Add(new SalesPackageElementJoin
                                              {
                                                  BridgeId = salesPackage.Id,
                                                  Id = this.linnappsDatabaseService.GetIdSequence("SPEJ_SEQ"),
                                                  SalesPackageId = salesPackage.SalesPackageId,
                                                  ElementType = salesPackageElementResource.ElementType,
                                                  SalesPackage = salesPackage,
                                                  SalesPackageElement = newElement
                                              });
            }

            return salesPackage;
        }

        protected override void UpdateFromResource(SalesPackage salesPackage, SalesPackageResource resource)
        {
            salesPackage.Description = resource.Description;
            foreach (var salesPackageElementResource in resource.Elements)
            {
                var element = salesPackage.Elements.FirstOrDefault(a => a.ElementType == salesPackageElementResource.ElementType);
                if (element != null)
                {
                    element.SalesPackageElement.Quantity = salesPackageElementResource.Quantity;
                    element.SalesPackageElement.Sequence = salesPackageElementResource.Sequence;
                }
                else
                {
                    var newElement = new SalesPackageElement
                                         {
                                             ElementType = salesPackageElementResource.ElementType,
                                             Quantity = salesPackageElementResource.Quantity,
                                             SalesPackageId = salesPackage.SalesPackageId,
                                             Sequence = salesPackageElementResource.Sequence
                                         };
                    salesPackage.Elements.Add(new SalesPackageElementJoin
                                                  {
                                                      BridgeId = salesPackage.Id,
                                                      Id = this.linnappsDatabaseService.GetIdSequence("SPEJ_SEQ"),
                                                      SalesPackageId = salesPackage.SalesPackageId,
                                                      ElementType = salesPackageElementResource.ElementType,
                                                      SalesPackage = salesPackage,
                                                      SalesPackageElement = newElement
                                                  });
                }
            }

            var toBeRemoved = salesPackage.Elements
                .Except(salesPackage.Elements.Where(e => resource.Elements.Select(r => r.ElementType).Contains(e.ElementType))).ToList();

            foreach (var salesPackageElementJoin in toBeRemoved)
            {
                salesPackage.Elements.Remove(salesPackageElementJoin);
            }
        }

        protected override Expression<Func<SalesPackage, bool>> SearchExpression(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}
