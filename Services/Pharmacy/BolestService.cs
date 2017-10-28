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
    public class BolestService : Service<Bolest>, IBolestService
    {
        public BolestService(NewDataLayer dataLayer) : base(dataLayer)
        {
        }

        public override Bolest Get(int id)
        {
            using (var session = DataLayer.GetSession())
            {
                var obj = session.Get<Bolest>(id);

                if (obj == null) return null;

                obj.KontraindikacijaList =
                    session.Query<Kontraindikacija>().Where(x => x.Deleted == false && x.Bolest.Id == obj.Id).ToList();
                obj.LekList = session.Query<LekBolest>().Where(x => x.Bolest.Id == obj.Id).Select(x => x.Lek).ToList();
                return obj;
            }
        }

        public override void Update(Bolest entity)
        {
            using (var session = DataLayer.GetSession())
            {
                try
                {
                    var leks = new List<Lek>(entity.LekList.Count);
                    if (entity.LekList != null)
                        leks.AddRange(entity.LekList.Select(lek => session.Get<Lek>(lek.Id)));

                    var kontraindikacijas = new List<Kontraindikacija>(entity.KontraindikacijaList.Count);
                    if (entity.KontraindikacijaList != null)
                        kontraindikacijas.AddRange(
                            entity.KontraindikacijaList.Select(x => session.Get<Kontraindikacija>(x.Id)));

                    entity.LekList = leks;
                    entity.KontraindikacijaList = kontraindikacijas;

                    session.Update(entity);
                    session.BeginTransaction().Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        public override void Update(int id, Bolest entity)
        {
            using (var session = DataLayer.GetSession())
            {
                try
                {
                    var obj = Get(id);

                    obj.KontraindikacijaList = entity.KontraindikacijaList;
                    obj.LekList = entity.LekList;
                    obj.NazivBolesti = entity.NazivBolesti;
                    obj.Opis = entity.Opis;
                    
                    session.Update(obj);
                    session.BeginTransaction().Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        public override void Create(Bolest entity)
        {
            using (var session = DataLayer.GetSession())
            {
                try
                {
                    var leks = new List<Lek>(entity.LekList.Count);
                    if (entity.LekList != null)
                        leks.AddRange(entity.LekList.Select(lek => session.Get<Lek>(lek.Id)));
                    var kontraindikacijas = new List<Kontraindikacija>(entity.KontraindikacijaList.Count);
                    if (entity.KontraindikacijaList != null)
                        kontraindikacijas.AddRange(
                            entity.KontraindikacijaList.Select(x => session.Get<Kontraindikacija>(x.Id)));

                    entity.LekList = leks;
                    entity.KontraindikacijaList = kontraindikacijas;

                    session.SaveOrUpdate(entity);
                    session.Flush();
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
                    var entity = session.Get<Bolest>(id);

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
            var dataTable = new DataTable("Bolesti");

            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("NarodniNaziv");
            dataTable.Columns.Add("LatinskiNaziv");
            dataTable.Columns.Add("Opis");

            dataTable.Columns.Add(Constants.ConcatenatedField, typeof (string), "Id + ' : ' +LatinskiNaziv");

            List<Bolest> objList;
            using (var session = DataLayer.GetSession())
                objList = session.QueryOver<Bolest>().Where(x => x.Deleted == false)?.List<Bolest>() as List<Bolest>;


            if (objList == null) return dataTable;
            objList.ForEach(
                x => dataTable.Rows.Add(x.Id, x.NazivBolesti.NarodniNaziv, x.NazivBolesti.LatinskiNaziv, x.Opis));

            return dataTable;
        }
    }
}