namespace Linn.Products.Persistence.Linnapps
{
    public class TransactionManager : ITransactionManager
    {
        private readonly ServiceDbContext serviceDbContext;

        public TransactionManager(ServiceDbContext serviceDbContext)
        {
            this.serviceDbContext = serviceDbContext;
        }

        public void Commit()
        {
            this.serviceDbContext.SaveChanges();
        }
    }
}
