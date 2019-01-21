namespace Linn.Products.Domain.Linnapps
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    using Linn.Products.Domain.Linnapps.Exceptions;

    public class SernosConfig
    {
        private readonly string[] startOnOptions = { "ANY", "ODD", "EVEN" };

        public SernosConfig(string name, string serialNumbered, int? numberOfSernos = null, int? numberOfBoxes = null)
        {
            this.CheckConfigurationIsValid(name, serialNumbered, numberOfSernos, numberOfBoxes);

            this.Name = name;
            this.SerialNumbered = serialNumbered;
            this.NumberOfSernos = numberOfSernos;
            this.NumberOfBoxes = numberOfBoxes;
        }

        public string Name { get; private set; }

        public string Description { get; set; }

        public string SerialNumbered { get; private set; }

        public int? NumberOfSernos { get; private set; }

        public int? NumberOfBoxes { get; private set; }

        public string StartOn { get; private set; }

        public void Update(string serialNumbered, int? numberOfSernos = null, int? numberOfBoxes = null)
        {
            this.CheckConfigurationIsValid(this.Name, serialNumbered, numberOfSernos, numberOfBoxes);

            this.SerialNumbered = serialNumbered;
            this.NumberOfSernos = numberOfSernos;
            this.NumberOfBoxes = numberOfBoxes;
        }

        public void SetStartOn(string startOn)
        {
            if (string.IsNullOrEmpty(startOn))
            {
                this.StartOn = null;
                return;
            }

            if (!this.startOnOptions.Contains(startOn?.ToUpper()))
            {
                throw new DomainException("Start on must be Any, Odd or Even");
            }

            this.StartOn = startOn?.ToUpper();
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
