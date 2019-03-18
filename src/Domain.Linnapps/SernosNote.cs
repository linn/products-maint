namespace Linn.Products.Domain.Linnapps
{
    using System.ComponentModel.DataAnnotations.Schema;

    using Linn.Common.Domain.Exceptions;

    public class SernosNote
    {
        // TODO check that the ID is being set from oracle correctly
        public SernosNote(string sernosNotes)
        {
            this.ValidateSernosNote(sernosNotes);

            this.SernosNotes = sernosNotes;
        }

        public string SernosGroup { get; set; }

        public int SernosNoteId { get; set; }

        public string SernosNotes { get; private set; }

        public int? SernosNumber { get; set; }

        // TODO do i take this out?
//        public int? SernosTref { get; set; }

        public string TransCode { get; set; }

        [ForeignKey("SERNOS_TREF")]
        public SerialNumber SerialNumber { get; set; }

        public void Update(string sernosNotes, string sernosGroup, int? sernosNumber, int? sernosTref, string transCode)
        {
            this.ValidateSernosNote(sernosNotes);

            this.SernosNotes = sernosNotes;
            this.SernosGroup = sernosGroup;
            this.SernosNumber = sernosNumber;
//            this.SernosTref = sernosTref;
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