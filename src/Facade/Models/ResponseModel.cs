namespace Linn.Products.Facade.Models
{
    using System.Collections.Generic;

    public class ResponseModel<T>
    {
        public ResponseModel(T entity, IEnumerable<string> privileges)
        {
            this.Entity = entity;
            this.Privileges = privileges;
        }

        public T Entity { get; set; }

        public IEnumerable<string> Privileges { get; set; }
    }
}