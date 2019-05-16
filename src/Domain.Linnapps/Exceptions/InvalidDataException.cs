namespace Linn.Products.Domain.Linnapps.Exceptions
{
    using System;

    using Linn.Common.Domain.Exceptions;

    public class InvalidDataException : DomainException
    {
        public InvalidDataException(string message)
            : base(message)
        {
        }

        public InvalidDataException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
