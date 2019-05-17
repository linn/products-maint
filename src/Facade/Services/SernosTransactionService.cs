namespace Linn.Products.Facade.Services
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Linn.Common.Facade;
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps.SernosTransactions;
    using Linn.Products.Resources;

    public class SernosTransactionService : FacadeService<SernosTrans, string, SernosTransactionResource, SernosTransactionResource>
    {
        public SernosTransactionService(IRepository<SernosTrans, string> repository, ITransactionManager transactionManager)
            : base(repository, transactionManager)
        {
        }

        protected override SernosTrans CreateFromResource(SernosTransactionResource resource)
        {
            return new SernosTrans
                       {
                           TransCode = resource.TransCode,
                           ManualPost = resource.ManualPost,
                           TransDescription = resource.TransDescription,
                           Comments = resource.Comments,
                           SernosTransCounts = resource.SernosTransCounts.Select(
                               item => new SernosTransCount
                                           {
                                               TransCode = item.TransCode,
                                               SernosCount = item.SernosCount,
                                               CheckError = item.CheckError,
                                               CorrectValue = item.CorrectValue,
                                               CountIncrement = item.CountIncrement,
                                               CheckErrorMess = item.CheckErrorMess
                                           }).ToList()
                       };
        }

        protected override void UpdateFromResource(SernosTrans sernosConfig, SernosTransactionResource updateResource)
        {
            sernosConfig.Comments = updateResource.Comments;
            sernosConfig.TransDescription = updateResource.TransDescription;
            sernosConfig.ManualPost = updateResource.ManualPost;
            sernosConfig.SernosTransCounts = updateResource.SernosTransCounts.Select(
                item => new SernosTransCount
                            {
                                TransCode = item.TransCode,
                                SernosCount = item.SernosCount,
                                CheckError = item.CheckError,
                                CorrectValue = item.CorrectValue,
                                CountIncrement = item.CountIncrement,
                                CheckErrorMess = item.CheckErrorMess
                            }).ToList();
        }

        protected override Expression<Func<SernosTrans, bool>> SearchExpression(string searchTerm)
        {
            return a => a.TransCode.ToLower().Contains(searchTerm.ToLower())
                        || a.TransDescription.ToLower().Contains(searchTerm.ToLower());
        }
    }
}
