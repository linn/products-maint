﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Linnapps.Tests.SaCoreTypeSpecs
{
    using Linn.Products.Domain.Linnapps;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected SaCoreType Sut { get; set; }

        [SetUp]
        public void SetUpContext()
        {
            this.Sut = new SaCoreType(1, "description");
        }
    }
}
