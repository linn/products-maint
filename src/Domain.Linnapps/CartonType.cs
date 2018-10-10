﻿namespace Linn.Products.Domain.Linnapps
{
    public class CartonType
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Height { get; set; }

        public decimal Width { get; set; }

        public decimal Depth { get; set; }

        public int NumberOfSmallLabels { get; set; }

        public int NumberOfLargeLabels { get; set; }
    }
}
