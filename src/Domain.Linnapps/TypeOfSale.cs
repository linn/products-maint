namespace Linn.Products.Domain.Linnapps
{
    using Linn.Common.Domain.Exceptions;

    public class TypeOfSale
    {
        public TypeOfSale(string name, string description, string nominal, string department, string realSale)
        {
            this.ValidateTypeOfSale(name, description, nominal, department, realSale);

            this.Name = name;
            this.Description = description;
            this.Nominal = nominal;
            this.Department = department;
            this.RealSale = realSale;
        }

        public string Name { get; set; }

        public string Department { get; set; }

        public string Description { get; set; }

        public string Nominal { get; set; }

        public string RealSale { get; set; }

        public void Update(string description, string nominal, string department, string realSale)
        {
            this.ValidateTypeOfSale(this.Name, description, nominal, department, realSale);

            this.Description = description;
            this.Nominal = nominal;
            this.Department = department;
            this.RealSale = realSale;
        }

        private void ValidateTypeOfSale(
            string name,
            string description,
            string nominal,
            string department,
            string realSale)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new DomainException("You must supply a name");
            }
        }
    }
}
