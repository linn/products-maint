namespace Linn.Products.Domain.Linnapps
{
    using System;

    using Linn.Common.Domain.Exceptions;

    public class SernosSequence
    {
        public SernosSequence(string sequenceName, string description, int nextSerialNumber, DateTime? dateClosed)
        {
            this.ValidateSernosSequence(sequenceName, description);

            this.SequenceName = sequenceName;
            this.Description = description;
            this.NextSerialNumber = nextSerialNumber;
            this.DateClosed = dateClosed;
        }

        public DateTime? DateClosed { get; set; }

        public string Description { get; set; }

        public int NextSerialNumber { get; set; }

        public string SequenceName { get; set; }

        public void Update(string sequenceName, string description, int nextSerialNumber, DateTime? dateClosed)
        {
            this.ValidateSernosSequence(sequenceName, description);

            this.Description = description;
            this.NextSerialNumber = nextSerialNumber;
            this.DateClosed = dateClosed;
        }

        private void ValidateSernosSequence(string sequenceName, string description)
        {
            if (string.IsNullOrEmpty(sequenceName))
            {
                throw new DomainException("You must supply a sequence name");
            }

            if (string.IsNullOrEmpty(description))
            {
                throw new DomainException("You must supply a description");
            }
        }
    }
}