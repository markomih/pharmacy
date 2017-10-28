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
    public class SirupService : Service<Sirup>, ISirupService
    {
        public SirupService(NewDataLayer dataLayer) : base(dataLayer)
        {
        }
        public override void Update(Sirup entity)
        {
            ServiceProvider.Get<PakovanjeService>().Update(entity);
        }

        public override void Create(Sirup entity)
        {
            ServiceProvider.Get<PakovanjeService>().Create(entity);
        }
        public override void Update(int id, Sirup entity)
        {
            ServiceProvider.Get<PakovanjeService>().Update(id, entity);
        }

        public override Sirup Get(int id)
        {
            using (var session = DataLayer.GetSession())
            {
                var obj = session.Get<Sirup>(id);

                if (obj == null) return null;

                obj.LekList = session.Query<Lek>().Where(x => x.Deleted == false && x.Pakovanje.Id == obj.Id).ToList();
                obj.KontraindikacijaList = session.Query<Kontraindikacija>().Where(x => x.Deleted == false && x.Pakovanje.Id == obj.Id).ToList();
                return obj;
            }
        }
        public override void Delete(int id)
        {
            using (var session = DataLayer.GetSession())
            {
                try
                {
                    var entity = session.Get<Sirup>(id);

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
            var dataTable = new DataTable("Sirup");

            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Sastav");
            dataTable.Columns.Add("Kolicina");
            dataTable.Columns.Add("Tip");

            dataTable.Columns.Add(Constants.ConcatenatedField, typeof(string), "Id + ' : ' +Tip");

            List<Sirup> objList;
            using (var session = DataLayer.GetSession())
                objList = session.QueryOver<Sirup>().Where(x => x.Deleted == false)?.List<Sirup>() as List<Sirup>;

            if (objList == null) return dataTable;

            objList.ForEach(x => dataTable.Rows.Add(x.Id, x.Sastav, x.Kolicina, x.Tip.ToString()));

            return dataTable;
        }
    }
}