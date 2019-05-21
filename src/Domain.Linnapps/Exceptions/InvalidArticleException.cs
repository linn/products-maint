namespace Linn.Products.Domain.Linnapps.Exceptions
{
    using System;

    using Linn.Common.Domain.Exceptions;

    public class InvalidArticleException : DomainException
    {
        public InvalidArticleException(string message)
            : base(message)
        {
        }

        public InvalidArticleException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
