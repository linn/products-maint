namespace Linn.Products.Resources
{
    using Linn.Common.Resources;

    public class ResponseResource<T> : HypermediaResource
    {
        public T ResponseData { get; set; }
    }
}
