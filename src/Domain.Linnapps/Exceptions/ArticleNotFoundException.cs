namespace Linn.Products.Domain.Linnapps.Exceptions
{
    using System;

    using Linn.Common.Domain.Exceptions;

    public class ArticleNotFoundException : DomainException
    {
        public ArticleNotFoundException(string message)
            : base(message)
        {
        }

        public ArticleNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
