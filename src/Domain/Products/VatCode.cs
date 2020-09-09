// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VatCode.cs" company="Linn Products Ltd.">
//   Copyright © 2012 Linn Products Limited. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Linn.Products.Domain.Products
{
    public class VatCode : Entity
    {
        public string VatDescription { get; set; }

        public bool IsVatOnly { get; set; }

        public double VatRate { get; set; }

        public string LinnAppsKey { get; set; }
    }
}
