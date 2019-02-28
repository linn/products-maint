namespace Linn.Products.Facade.ResourceBuilders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class SernosSequencesResourceBuilder : IResourceBuilder<IEnumerable<SernosSequence>>
    {
        private readonly SernosSequenceResourceBuilder sernosConfigResourceBuilder = new SernosSequenceResourceBuilder();

        public IEnumerable<SernosSequenceResource> Build(IEnumerable<SernosSequence> sernosSequences)
        {
            return sernosSequences.Select(a => this.sernosConfigResourceBuilder.Build(a));
        }

        object IResourceBuilder<IEnumerable<SernosSequence>>.Build(IEnumerable<SernosSequence> sernosSequences) => this.Build(sernosSequences);

        public string GetLocation(IEnumerable<SernosSequence> sernosSequences)
        {
            throw new NotImplementedException();
        }
    }
}