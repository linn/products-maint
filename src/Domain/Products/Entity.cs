namespace Linn.Products.Domain.Products
{
    public abstract class ProductEntity
    {
        private int? id;

        protected ProductEntity()
        {
        }

        protected ProductEntity(int id)
        {
            this.id = id;
        }

        public virtual int? Id
        {
            get
            {
                return this.id;
            }

            set
            {
                this.id = value;
            }
        }
    }
}