namespace Linn.Products.Domain.Linnapps
{
    using Linn.Products.Domain.Linnapps.Exceptions;

    public class SernosConfig
    {
        public SernosConfig(string name, string serialNumbered, int? numberOfSernos = null, int? numberOfBoxes = null)
        {
            this.CheckConfigurationIsValid(name, serialNumbered, numberOfSernos, numberOfBoxes);

            this.Name = name;
            this.SerialNumbered = serialNumbered;
            this.NumberOfSernos = numberOfSernos;
            this.NumberOfBoxes = numberOfBoxes;
        }

        private SernosConfig()
        {
            // ef
        }

        public string Name { get; private set; }

        public string Description { get; set; }

        public string SerialNumbered { get; private set; }

        public int? NumberOfSernos { get; private set; }

        public int? NumberOfBoxes { get; private set; }

        public string StartOn { get; set; }

        public void Update(string serialNumbered, int? numberOfSernos = null, int? numberOfBoxes = null)
        {
            this.CheckConfigurationIsValid(this.Name, serialNumbered, numberOfSernos, numberOfBoxes);

            this.SerialNumbered = serialNumbered;
            this.NumberOfSernos = numberOfSernos;
            this.NumberOfBoxes = numberOfBoxes;
        }

        private void CheckConfigurationIsValid(
            string name,
            string serialNumbered,
            int? numberOfSernos,
            int? numberOfBoxes)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new DomainException("You must supply a name");
            }

            if (serialNumbered == "Y" && (numberOfBoxes == null || numberOfSernos == null))
            {
                throw new DomainException("You must supply serial number details");
            }
        }
    }
}
