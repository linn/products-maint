namespace Linn.Products.Domain.Linnapps
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    using Linn.Products.Domain.Linnapps.Exceptions;

    [Table("SERNOS_CONFIG")]
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

        [Key]
        [Column("NAME")]
        public string Name { get; private set; }

        [Column("DESCRIPTION")]
        public string Description { get; set; }

        [Column("SERIAL_NUMBERED")]
        public string SerialNumbered { get; private set; }

        [Column("NUM_OF_SERNOS")]
        public int? NumberOfSernos { get; private set; }

        [Column("NUM_OF_BOXES")]
        public int? NumberOfBoxes { get; private set; }

        [Column("START_ON")]
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
