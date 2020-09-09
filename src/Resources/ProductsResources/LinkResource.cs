namespace Linn.Products.Resources.ProductsResources
{
    using System;

    public class LinkResource
    {
        public LinkResource()
        {
        }

        public LinkResource(string rel, string href)
        {
            this.rel = rel;
            this.href = href;
        }

        public LinkResource(string rel, Uri uri)
        {
            this.rel = rel;
            this.href = uri.ToString();
        }

        public string href { get; set; }

        public string rel { get; set; }
    }
}
