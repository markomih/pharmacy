using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Core;
using Core.Entities;
using Core.Services;
using Data;
using NHibernate.Linq;

namespace Services
{
    public class ProizvodjacService : Service<Proizvodjac>, IProizvodjacService
    {
        public ProizvodjacService(NewDataLayer dataLayer) : base(dataLayer)
        {
        }

        public override Proizvodjac Get(int id)
        {
            using (var session = DataLayer.GetSession())
            {
                var obj = session.Get<Proizvodjac>(id);

                if (obj == null) return null;
                
                obj.LekList = session.Query<LekProizvodjac>().Where(x => x.Proizvodjac.Id == obj.Id).Select(x => x.Lek).ToList();
                return obj;
            }
        }

        public override void Update(Proizvodjac entity)
        {
            using (var session = DataLayer.GetSession())
            {
                try
                {
                    var leks = new List<Lek>();

                    if (entity.LekList != null)
                        leks.AddRange(entity.LekList.Select(x => session.Get<Lek>(x.Id)));

                    entity.LekList = leks;

                    session.SaveOrUpdate(entity);
                    session.Flush();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        public override void Update(int id, Proizvodjac entity)
        {
            using (var session = DataLayer.GetSession())
            {
                try
                {
                    var obj = Get(id);

                    obj.LekList = entity.LekList;
                    obj.Naziv = entity.Naziv;

                    session.Update(obj);
                    session.BeginTransaction().Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        public override void Create(Proizvodjac entity)
        {
            using (var session = DataLayer.GetSession())
            {
                try
                {
                    var leks = new List<Lek>();

                    if (entity.LekList != null)
                        leks.AddRange(entity.LekList.Select(x => session.Get<Lek>(x.Id)));

                    entity.LekList = leks;
                    session.SaveOrUpdate(entity);
                    session.BeginTransaction().Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public override void Delete(int id)
        {
            using (var session = DataLayer.GetSession())
            {
                try
                {
                    var entity = session.Get<Proizvodjac>(id);

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
        public DataTable GetDataTable()
        {
            var dataTable = new DataTable("Proizvodjac");

            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Naziv");

            dataTable.Columns.Add(Constants.ConcatenatedField, typeof(string), "Id + ' : ' +Naziv");

            List<Proizvodjac> objList;
            using (var session = DataLayer.GetSession())
                objList =
                    session.QueryOver<Proizvodjac>().Where(x => x.Deleted == false)?.List<Proizvodjac>() as
                        List<Proizvodjac>;


            if (objList == null) return dataTable;
            objList.ForEach(x => dataTable.Rows.Add(x.Id, x.Naziv));

            return dataTable;
        }
    }
}