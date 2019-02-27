namespace Linn.Products.Facade.Services
{
    using System;

    using Linn.Common.Facade;
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class SernosSequenceService : FacadeService<SernosSequence, string, SernosSequenceResource, SernosSequenceResource>
    {
        public SernosSequenceService(IRepository<SernosSequence, string> repository, ITransactionManager transactionManager)
            : base(repository, transactionManager)
        {
        }

        protected override SernosSequence CreateFromResource(SernosSequenceResource resource)
        {
            var sequence = new SernosSequence(
                             resource.SequenceName,
                             resource.Description,
                             resource.NextSerialNumber,
                             string.IsNullOrEmpty(resource.DateClosed) ? (DateTime?)null : DateTime.Parse(resource.DateClosed));

            return sequence;
        }

        protected override void UpdateFromResource(SernosSequence sernosSequence, SernosSequenceResource updateResource)
        {
            sernosSequence.Update(
                updateResource.SequenceName,
                updateResource.Description,
                updateResource.NextSerialNumber,
                string.IsNullOrEmpty(updateResource.DateClosed) ? (DateTime?)null : DateTime.Parse(updateResource.DateClosed));
        }
    }
}