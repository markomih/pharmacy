using System.Collections.Generic;
using Core.Entities;

namespace Core.Services
{
    public interface IService<TEntity> where TEntity : IEntity
    {
        TEntity Get(int id);
        IList<TEntity> GetAll();
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int id);
    }
}