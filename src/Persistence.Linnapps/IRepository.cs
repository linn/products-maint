namespace Linn.Products.Persistence.Linnapps
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository<T, in TKey>
    {
        T FindById(TKey key);

        IQueryable<T> FindAll();

        void Add(T entity);

        void Remove(T entity);

        T FindBy(Expression<Func<T, bool>> expression);

        IQueryable<T> FilterBy(Expression<Func<T, bool>> expression);
    }
}