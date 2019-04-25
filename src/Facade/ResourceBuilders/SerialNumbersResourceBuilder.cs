namespace Linn.Products.Facade.ResourceBuilders
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class SerialNumbersResourceBuilder : IResourceBuilder<IEnumerable<SerialNumber>>
    {
        private readonly SerialNumberResourceBuilder serialNumberResourceBuilder = new SerialNumberResourceBuilder();

        public IEnumerable<SerialNumberResource> Build(IEnumerable<SerialNumber> serialNumber)
        {
            return serialNumber.Select(s => this.serialNumberResourceBuilder.Build(s));
        }

        object IResourceBuilder<IEnumerable<SerialNumber>>.Build(IEnumerable<SerialNumber> serialNumber) => this.Build(serialNumber);

        public string GetLocation(IEnumerable<SerialNumber> model)
        {
            return "/products/maint/serial-numbers";
        }
    }
}
