namespace Linn.Products.Domain.Linnapps.Exceptions
{
    using System;

    using Linn.Common.Domain.Exceptions;

    public class InvalidSerialNumberTransactionException : DomainException
    {
        public InvalidSerialNumberTransactionException(string message)
            : base(message)
        {
        }

        public InvalidSerialNumberTransactionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
