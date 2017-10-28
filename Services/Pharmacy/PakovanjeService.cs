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
    public class PakovanjeService : Service<Pakovanje>, IPakovanjeService
    {
        public PakovanjeService(NewDataLayer dataLayer) : base(dataLayer)
        {
        }

        public override Pakovanje Get(int id)
        {
            using (var session = DataLayer.GetSession())
            {
                var obj = session.Get<Pakovanje>(id);

                if (obj == null) return null;

                obj.LekList = session.Query<Lek>().Where(x => x.Deleted == false && x.Pakovanje.Id == obj.Id).ToList();
                obj.KontraindikacijaList = session.Query<Kontraindikacija>().Where(x => x.Deleted == false && x.Pakovanje.Id == obj.Id).ToList();
                return obj;
            }
        }

        public override void Create(Pakovanje entity)
        {
            using (var session = DataLayer.GetSession())
            {
                try
                {
                    List<Kontraindikacija> kontraindikacijas = new List<Kontraindikacija>();
                    List<Lek> leks = new List<Lek>();

                    if (entity.KontraindikacijaList != null)
                        kontraindikacijas.AddRange(entity.KontraindikacijaList.Select(x => session.Get<Kontraindikacija>(x.Id)));
                    if (entity.LekList != null)
                        leks.AddRange(entity.LekList.Select(x => session.Get<Lek>(x.Id)));

                    entity.KontraindikacijaList = kontraindikacijas;
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

        public override void Update(Pakovanje entity)
        {
            using (var session = DataLayer.GetSession())
            {
                try
                {
                    List<Kontraindikacija> kontraindikacijas = new List<Kontraindikacija>();
                    List<Lek> leks = new List<Lek>();

                    if (entity.KontraindikacijaList != null)
                        kontraindikacijas.AddRange(entity.KontraindikacijaList.Select(x => session.Get<Kontraindikacija>(x.Id)));
                    if (entity.LekList != null)
                        leks.AddRange(entity.LekList.Select(x => session.Get<Lek>(x.Id)));

                    entity.KontraindikacijaList = kontraindikacijas;
                    entity.LekList = leks;

                    session.Update(entity);
                    session.BeginTransaction().Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        public override void Update(int id, Pakovanje entity)
        {
            using (var session = DataLayer.GetSession())
            {
                try
                {
                    var obj = Get(id);

                    obj.KontraindikacijaList = entity.KontraindikacijaList;
                    obj.Kolicina = entity.Kolicina;
                    obj.LekList = entity.LekList;
                    obj.Sastav = entity.Sastav;

                    session.Update(obj);
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
                    var entity = session.Get<Pakovanje>(id);

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
            var dataTable = new DataTable("Pakovanje");

            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Sastav");
            dataTable.Columns.Add("Kolicina");
            dataTable.Columns.Add("Tip");
            dataTable.Columns.Add(Constants.ConcatenatedField, typeof(string), "Id + ' : ' +Tip");

            List<Pakovanje> objList;
            using (var session = DataLayer.GetSession())
                objList =
                    session.QueryOver<Pakovanje>().Where(x => x.Deleted == false)?.List<Pakovanje>() as List<Pakovanje>;

            if (objList == null) return dataTable;
            objList.ForEach(x => dataTable.Rows.Add(x.Id, x.Sastav, x.Kolicina, x.Tip.ToString()));

            return dataTable;
        }
    }
}