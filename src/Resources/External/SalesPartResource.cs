﻿namespace Linn.Products.Resources.External
{
    public class SalesPartResource
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public RootProductExternalResource RootProduct { get; set; }
    }
}