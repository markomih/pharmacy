using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using Core.Services;
using NHibernate.Linq;

namespace Data.Services
{
    public abstract class Service<TEntity> : IService<TEntity> where TEntity : IEntity
    {

        protected readonly NewDataLayer DataLayer;

        protected Service(NewDataLayer dataLayer)
        {
            DataLayer = dataLayer;
        }

        public abstract TEntity Get(int id);

        public IList<TEntity> GetAll()
        {
            try
            {
                using (var session = DataLayer.GetSession())
                {
                    return session.Query<TEntity>().Select(x => x).ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Create(TEntity entity)
        {
            try
            {
                using (var session = DataLayer.GetSession())
                {
                    session.Save(entity);
                    session.BeginTransaction().Commit();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Update(TEntity entity)
        {
            using (var session = DataLayer.GetSession())
            {
                try
                {
                    session.Update(entity);
                    session.BeginTransaction().Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public void Delete(TEntity entity)
        {
            using (var session = Data.DataLayer.GetSession())
            {
                try
                {
                    entity.Deleted = true;
                    session.Update(entity);
                    session.BeginTransaction().Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}