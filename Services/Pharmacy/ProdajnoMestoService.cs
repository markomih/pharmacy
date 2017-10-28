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
    public class ProdajnoMestoService : Service<ProdajnoMesto>, IProdajnoMestoService
    {
        public ProdajnoMestoService(NewDataLayer dataLayer) : base(dataLayer)
        {
        }

        public override ProdajnoMesto Get(int id)
        {
            using (var session = DataLayer.GetSession())
            {
                var obj = session.Get<ProdajnoMesto>(id);

                if (obj == null) return null;

                if (obj.ApotekarskaUstanova != null)
                    obj.ApotekarskaUstanova = session.Get<ApotekarskaUstanova>(obj.ApotekarskaUstanova.Id);

                obj.LekList =
                    session.Query<ProdajnoMestoLek>()
                        .Where(x => x.ProdajnoMesto.Id == obj.Id)
                        .Select(x => x.Lek)
                        .ToList();
                obj.ReceptList =
                    session.Query<Recept>().Where(x => x.Deleted == false && x.ProdajnoMesto.Id == obj.Id).ToList();
                obj.ZaposleniList =
                    session.Query<Zaposleni>().Where(x => x.Deleted == false && x.ProdajnoMesto.Id == obj.Id).ToList();
                return obj;
            }
        }

        public override void Update(ProdajnoMesto entity)
        {
            using (var session = DataLayer.GetSession())
            {
                try
                {
                    var leks = new List<Lek>();
                    var recepts = new List<Recept>();
                    var zaposlenis = new List<Zaposleni>();

                    if (entity.LekList != null)
                        leks.AddRange(entity.LekList.Select(x => session.Get<Lek>(x.Id)));
                    if (entity.ReceptList != null)
                        recepts.AddRange(entity.ReceptList.Select(x => session.Get<Recept>(x.Id)));
                    if (entity.ZaposleniList != null)
                        zaposlenis.AddRange(entity.ZaposleniList.Select(x => session.Get<Zaposleni>(x.Id)));

                    entity.LekList = leks;
                    entity.ReceptList = recepts;
                    entity.ZaposleniList = zaposlenis;

                    session.SaveOrUpdate(entity);
                    session.Flush();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        public override void Update(int id, ProdajnoMesto entity)
        {
            using (var session = DataLayer.GetSession())
            {
                try
                {
                    var obj = Get(id);

                    obj.ZaposleniList = entity.ZaposleniList;
                    obj.ReceptList = entity.ReceptList;
                    obj.LekList = entity.LekList;
                    obj.ApotekarskaUstanova = entity.ApotekarskaUstanova;
                    obj.Lokacija = entity.Lokacija;
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
        public override void Create(ProdajnoMesto entity)
        {
            using (var session = DataLayer.GetSession())
            {
                try
                {
                    var leks = new List<Lek>();
                    var recepts = new List<Recept>();
                    var zaposlenis = new List<Zaposleni>();

                    if (entity.LekList != null)
                        leks.AddRange(entity.LekList.Select(x => session.Get<Lek>(x.Id)));
                    if (entity.ReceptList != null)
                        recepts.AddRange(entity.ReceptList.Select(x => session.Get<Recept>(x.Id)));
                    if (entity.ZaposleniList != null)
                        zaposlenis.AddRange(entity.ZaposleniList.Select(x => session.Get<Zaposleni>(x.Id)));

                    entity.LekList = leks;
                    entity.ReceptList = recepts;
                    entity.ZaposleniList = zaposlenis;

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
                    var entity = session.Get<ProdajnoMesto>(id);

                    entity.Deleted = true;
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
            var dataTable = new DataTable("ProdajnoMesto");

            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Naziv");
            dataTable.Columns.Add("Adresa");
            dataTable.Columns.Add("Mesto");

            dataTable.Columns.Add(Constants.ConcatenatedField, typeof (string), "Id + ' : ' +Naziv");

            List<ProdajnoMesto> objList;
            using (var session = DataLayer.GetSession())
                objList =
                    session.QueryOver<ProdajnoMesto>().Where(x => x.Deleted == false)?.List<ProdajnoMesto>() as
                        List<ProdajnoMesto>;

            if (objList == null) return dataTable;
            objList.ForEach(x => dataTable.Rows.Add(x.Id, x.Naziv, x.Lokacija.Adresa, x.Lokacija.Mesto));

            return dataTable;
        }
    }
}