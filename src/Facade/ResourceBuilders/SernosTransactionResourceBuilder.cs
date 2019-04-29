namespace Linn.Products.Facade.ResourceBuilders
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain.Linnapps.SernosTransactions;
    using Linn.Products.Resources;

    public class SernosTransactionResourceBuilder : IResourceBuilder<SernosTrans>
    {
        public SernosTransactionResource Build(SernosTrans sernosTrans)
        {
            return new SernosTransactionResource
                       {
                           Comments = sernosTrans.Comments,
                           ManualPost = sernosTrans.ManualPost,
                           TransCode = sernosTrans.TransCode,
                           TransDescription = sernosTrans.TransDescription,
                           UpdateBuiltBy = sernosTrans.UpdateBuiltBy,
                           UpdateLastAccount = sernosTrans.UpdateLastAccount,
                           UpdateLastTransaction = sernosTrans.UpdateLastTransaction,
                           SernosTransCounts = sernosTrans.SernosTransCounts.Select(t => new SernosTransactionCountResource
                                                                                             {
                                                                                                 CheckError = t.CheckError,
                                                                                                 TransCode = t.TransCode,
                                                                                                 SernosCount = t.SernosCount,
                                                                                                 CountIncrement = t.CountIncrement,
                                                                                                 CheckErrorMess = t.CheckErrorMess,
                                                                                                 CorrectValue = t.CorrectValue
                                                                                             }),
                           Links = this.BuildLinks(sernosTrans).ToArray()
                       };
        }

        object IResourceBuilder<SernosTrans>.Build(SernosTrans sernosTrans) => this.Build(sernosTrans);

        public string GetLocation(SernosTrans sernosTrans)
        {
            return $"/products/maint/serial-number-transactions/{sernosTrans.TransCode}";
        }

        private IEnumerable<LinkResource> BuildLinks(SernosTrans sernosTrans)
        {
            yield return new LinkResource
                             {
                                 Rel = "self",
                                 Href = this.GetLocation(sernosTrans)
                             };
        }
    }
}