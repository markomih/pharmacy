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
    public class ZaposleniService : Service<Zaposleni>, IZaposleniService
    {
        public ZaposleniService(NewDataLayer dataLayer) : base(dataLayer)
        {
        }

        public override void Update(Zaposleni entity)
        {
            using (var session = DataLayer.GetSession())
            {
                try
                {
                    var recepts = new List<Recept>();

                    if (entity.ReceptList != null)
                        recepts.AddRange(entity.ReceptList.Select(x => session.Get<Recept>(x.Id)));

                    entity.ReceptList = recepts;

                    session.SaveOrUpdate(entity);
                    session.Flush();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        public override void Update(int id, Zaposleni entity)
        {
            using (var session = DataLayer.GetSession())
            {
                try
                {
                    var obj = Get(id);

                    obj.ReceptList = entity.ReceptList;
                    obj.Ime = entity.Ime;
                    obj.Kontakt = entity.Kontakt;
                    obj.ProdajnoMesto = entity.ProdajnoMesto;
                    obj.DatumDiplomiranja = entity.DatumDiplomiranja;
                    obj.DatumObnoveLicence = entity.DatumObnoveLicence;
                    obj.DatumRodjenja = entity.DatumRodjenja;
                    obj.DatumZaposljavanja = entity.DatumZaposljavanja;
                    obj.FFarmaceut = entity.FFarmaceut;
                    obj.Jmbg = entity.Jmbg;
                    obj.Lokacija = entity.Lokacija;

                    session.Update(obj);
                    session.BeginTransaction().Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        public override void Create(Zaposleni entity)
        {
            using (var session = DataLayer.GetSession())
            {
                try
                {
                    if (entity.ProdajnoMesto != null)
                        entity.ProdajnoMesto = session.Get<ProdajnoMesto>(entity.ProdajnoMesto.Id);

                    var recepts = new List<Recept>();

                    if (entity.ReceptList != null)
                        recepts.AddRange(entity.ReceptList.Select(x => session.Get<Recept>(x.Id)));

                    entity.ReceptList = recepts;

                    session.SaveOrUpdate(entity);
                    session.BeginTransaction().Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public override Zaposleni Get(int id)
        {
            using (var session = DataLayer.GetSession())
            {
                var obj = session.Get<Zaposleni>(id);
                if (obj == null) return null;

                if (obj.ProdajnoMesto != null)
                    obj.ProdajnoMesto = session.Get<ProdajnoMesto>(obj.ProdajnoMesto.Id);
                obj.ReceptList =
                    session.Query<Recept>().Where(x => x.Deleted == false && x.Farmaceut.Id == obj.Id).ToList();
                return obj;
            }
        }

        public override void Delete(int id)
        {
            using (var session = DataLayer.GetSession())
            {
                try
                {
                    var entity = session.Get<Zaposleni>(id);

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
            var dataTable = new DataTable("Zaposleni");

            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("LIme");
            dataTable.Columns.Add("Prezime");
            dataTable.Columns.Add("Email");
            dataTable.Columns.Add("Broj Telefona");
            dataTable.Columns.Add("Farmaceut");

            dataTable.Columns.Add(Constants.ConcatenatedField, typeof (string), "Id + ' : ' +LIme");

            List<Zaposleni> objList;
            using (var session = DataLayer.GetSession())
                objList =
                    session.QueryOver<Zaposleni>().Where(x => x.Deleted == false)?.List<Zaposleni>() as List<Zaposleni>;

            if (objList == null) return dataTable;
            objList.ForEach(
                x =>
                    dataTable.Rows.Add(x.Id, x.Ime.LIme, x.Ime.Prezime, x.Kontakt.Email, x.Kontakt.BrojTelefona,
                        x.FFarmaceut ? "Da" : "Ne"));

            return dataTable;
        }

        public DataTable GetFarmaceutDataTable()
        {
            var dataTable = new DataTable("Zaposleni");

            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("LIme");
            dataTable.Columns.Add("Prezime");
            dataTable.Columns.Add("Email");
            dataTable.Columns.Add("Broj Telefona");
            dataTable.Columns.Add("Farmaceut");

            dataTable.Columns.Add(Constants.ConcatenatedField, typeof (string), "Id + ' : ' +LIme");

            List<Zaposleni> objList;
            using (var session = DataLayer.GetSession())
                objList =
                    session.QueryOver<Zaposleni>().Where(x => x.Deleted == false && x.FFarmaceut)?.List<Zaposleni>() as
                        List<Zaposleni>;


            if (objList == null) return dataTable;
            objList.ForEach(
                x => dataTable.Rows.Add(x.Id, x.Ime.LIme, x.Ime.Prezime, x.Kontakt.Email, x.Kontakt.BrojTelefona));

            return dataTable;
        }
    }
}