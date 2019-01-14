namespace Linn.Products.Persistence.Linnapps.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Linn.Products.Domain.Linnapps;

    public class TypeOfSaleRepository : IRepository<TypeOfSale, string>
    {
        private readonly List<TypeOfSale> typesOfSale;

        public TypeOfSaleRepository()
        {
            this.typesOfSale = this.MakeTypesOfSale();
        }

        public TypeOfSale FindById(string key)
        {
            return this.typesOfSale.Find(a => a.Name == key);
        }

        public IQueryable<TypeOfSale> FindAll()
        {
            return this.typesOfSale.AsQueryable();
        }

        public void Add(TypeOfSale typeOfSale)
        {
            this.typesOfSale.Add(typeOfSale);
        }

        public void Remove(TypeOfSale entity)
        {
            throw new NotImplementedException();
        }

        public TypeOfSale FindBy(Expression<Func<TypeOfSale, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TypeOfSale> FilterBy(Expression<Func<TypeOfSale, bool>> expression)
        {
            throw new NotImplementedException();
        }

        private List<TypeOfSale> MakeTypesOfSale()
        {
            return new List<TypeOfSale>
                       {
                           new TypeOfSale("LSLPL", "LINNSIGHT SALE OF LINN PRODUCTS", "DUMMY", "DUMMY", "Y"),
                           new TypeOfSale("DL", "SALES OF LINN RECORDS DOWNLOADS", "DUMMY", "DUMMY", "Y"),
                           new TypeOfSale("TS SUNDRY", "THEMESCENE SUNDRY", "0417", "2106", "Y"),
                           new TypeOfSale("SOURCE", "SOURCE PRODUCTS", "DUMMY", "DUMMY", "Y"),
                           new TypeOfSale("DUFFER", "BIG DUFFER", "1", "2", "N"),
                           new TypeOfSale("SUPP", "LINN SALES TO SUPPLIERS", "DUMMY", "DUMMY", "N"),
                           new TypeOfSale("DIR", "LINN SALES/SERVICES DIRECT TO CUSTOMERS", "DUMMY", "DUMMY", "Y"),
                           new TypeOfSale("HIFI", "LINN HI-FI SALES", "DUMMY", "DUMMY", "Y")
                       };
        }
    }
}
