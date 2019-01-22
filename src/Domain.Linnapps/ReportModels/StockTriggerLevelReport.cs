namespace Linn.Products.Domain.Linnapps.ReportModels
{
    using System;

    public class StockTriggerLevelReport
    {
        public string PartNumber { get; set; }

        public int? TriggerLevel { get; set; }

        public int? MaxCapacity { get; set; }

        public int? QtyAtLocation { get; set; }

        public int? PalletNumber { get; set; }

        public string LocationCode { get; set; }

        public int? QtyAvailable { get; set; }

        public int? QtyAllocated { get; set; }

        public DateTime? StockRotationDate { get; set; }
    }
}