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

        public void Update(string name, string description, string nominal, string department, string realSale)
        {
            this.ValidateTypeOfSale(name, description, nominal, department, realSale);

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

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new DomainException("You must supply a description");
            }

            if (string.IsNullOrWhiteSpace(nominal))
            {
                throw new DomainException("You must supply a nominal");
            }

            if (string.IsNullOrWhiteSpace(department))
            {
                throw new DomainException("You must supply a department");
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new DomainException("You must supply a description");
            }

            if (string.IsNullOrWhiteSpace(realSale))
            {
                throw new DomainException("You must supply a real sale");
            }
        }
    }
}
