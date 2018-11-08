﻿namespace Linn.Products.Facade.Services
{
    using System.Collections.Generic;

    using Linn.Common.Facade;

    public interface IFacadeService<T, in TKey, in TResource>
    {
        IResult<T> GetById(TKey id);

        IResult<IEnumerable<T>> GetAll();

        IResult<T> Add(TResource resource);

        IResult<T> Update(TKey id, TResource updateResource);
    }
}