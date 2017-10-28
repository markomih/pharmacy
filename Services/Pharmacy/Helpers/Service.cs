using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using Core.Services;
using Data;
using NHibernate.Linq;

namespace Services
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
                    return session.Query<TEntity>().Where(x => x.Deleted == false).Select(x => x).ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }

        public virtual void Create(TEntity entity)
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
            }
        }

        public virtual void Update(TEntity entity)
        {
            using (var session = DataLayer.GetSession())
            {
                try
                {
                    //session.Evict(entity);
                    session.Update(entity);
                    session.BeginTransaction().Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public abstract void Update(int id, TEntity entity);

        public void Delete(TEntity entity)
        {
            using (var session = DataLayer.GetSession())
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
                }
            }
        }

        public abstract void Delete(int id);
    }
}