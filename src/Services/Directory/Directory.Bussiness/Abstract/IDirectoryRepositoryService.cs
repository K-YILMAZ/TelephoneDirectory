using Directory.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace Directory.Bussiness.Abstract
{
    public interface IDirectoryRepositoryService<T> where T : class, IEntity, new()
    {
        List<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
