namespace Linn.Products.Domain.Linnapps
{
    using System;

    public class SernosSequence
    {
        public SernosSequence(string sequenceName, string description, int nextSerialNumber, DateTime? dateClosed)
        {
            this.SequenceName = sequenceName;
            this.Description = description;
            this.NextSerialNumber = nextSerialNumber;
            this.DateClosed = dateClosed;
        }

        public DateTime? DateClosed { get; set; }

        public string Description { get; set; }

        public int NextSerialNumber { get; set; }

        public string SequenceName { get; set; }

        public void Update(string description, int nextSerialNumber, DateTime? dateClosed)
        {
            this.Description = description;
            this.NextSerialNumber = nextSerialNumber;
            this.DateClosed = dateClosed;
        }
    }
}