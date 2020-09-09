namespace Linn.Products.Domain.Products
{
    public class AccountingCompany : PhaseOutableEntity
    {
        public AccountingCompany(string name)
        {
            this.Name = name;
        }

        public AccountingCompany()
        {
        }

        public string Description { get; set; }

        public string Name { get;  set; }
    }
}