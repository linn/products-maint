namespace Linn.Products.Domain.Linnapps
{
    using Linn.Common.Domain.Exceptions;

    public class SernosNote
    {
        public SernosNote(string sernosNotes)
        {
            this.ValidateSernosNote(sernosNotes);

            this.SernosNotes = sernosNotes;
        }

        public string SernosGroup { get; set; }

        public int SernosNoteId { get; set; }

        public string SernosNotes { get; private set; }

        public int? SernosNumber { get; set; }

        public int? SernosTRef { get; set; }

        public string TransCode { get; set; }

        public void Update(string sernosNotes, string sernosGroup, int? sernosNumber, int? sernosTRef, string transCode)
        {
            this.ValidateSernosNote(sernosNotes);

            this.SernosNotes = sernosNotes;
            this.SernosGroup = sernosGroup;
            this.SernosNumber = sernosNumber;
            this.SernosTRef = sernosTRef;
            this.TransCode = transCode;
        }

        private void ValidateSernosNote(string sernosNotes)
        {
            if (string.IsNullOrEmpty(sernosNotes))
            {
                throw new DomainException("You must supply sernos notes");
            }
        }
    }
}