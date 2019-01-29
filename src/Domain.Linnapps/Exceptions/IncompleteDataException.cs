namespace Linn.Products.Domain.Linnapps.Exceptions
{
    using System;

    using Linn.Common.Domain.Exceptions;

    public class IncompleteDataException : DomainException
    {
        public IncompleteDataException(string message)
            : base(message)
        {
        }

        public IncompleteDataException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
