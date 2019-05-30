namespace Linn.Products.Facade
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Products.Facade.Models;

    using PagedList.Core;

    public interface IFacadeServiceLocal<T, in TKey, in TResource, in TUpdateResource>
    {
        IResult<T> GetById(TKey id);

        IResult<IEnumerable<T>> GetAll();

        IResult<IEnumerable<T>> Search(string searchTerm);

        IResult<IPagedList<T>> GetAll(int pageNumber, int pageSize);

        IResult<T> Add(TResource resource);

        IResult<T> Update(TKey id, TUpdateResource updateResource);

        IResult<ResponseModel<T>> GetById(TKey id, IEnumerable<string> privileges);

        IResult<ResponseModel<T>> Add(TResource resource, IEnumerable<string> privileges);

        IResult<ResponseModel<T>> Update(TKey id, TUpdateResource updateResource, IEnumerable<string> privileges);

    }
}
