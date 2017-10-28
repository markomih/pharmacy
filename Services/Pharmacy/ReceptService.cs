using System;
using System.Collections.Generic;
using System.Data;
using Core;
using Core.Entities;
using Core.Services;
using Data;

namespace Services
{
    public class ReceptService : Service<Recept>, IReceptService
    {
        public ReceptService(NewDataLayer dataLayer) : base(dataLayer)
        {
        }

        public override Recept Get(int id)
        {
            using (var session = DataLayer.GetSession())
            {
                var obj = session.Get<Recept>(id);

                if (obj == null) return null;

                if (obj.ProdajnoMesto != null)
                    obj.ProdajnoMesto = session.Get<ProdajnoMesto>(obj.ProdajnoMesto?.Id);
                if (obj.Farmaceut != null)
                    obj.Farmaceut = session.Get<Zaposleni>(obj.Farmaceut.Id);
                if (obj.Kupac != null)
                    obj.Kupac = session.Get<Kupac>(obj.Kupac.Id);
                if (obj.Lek != null)
                    obj.Lek = session.Get<Lek>(obj.Lek.Id);
                if (obj.Lekar != null)
                    obj.Lekar = session.Get<Lekar>(obj.Lekar.Id);

                return obj;
            }
        }
        public override void Update(int id, Recept entity)
        {
            using (var session = DataLayer.GetSession())
            {
                try
                {
                    var obj = Get(id);

                    obj.Lek = entity.Lek;
                    obj.Farmaceut = entity.Farmaceut;
                    obj.ProdajnoMesto = entity.ProdajnoMesto;
                    obj.Kupac = entity.Kupac;
                    obj.Lekar = entity.Lekar;
                    obj.DatumRealizacije = entity.DatumRealizacije;
                    obj.DatumVazenja = entity.DatumVazenja;
                    obj.KolicinaLeka = entity.KolicinaLeka;
                    obj.Doza = entity.Doza;

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
                    var entity = session.Get<Recept>(id);

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
            var dataTable = new DataTable("Recept");

            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("DatumRealizacije");
            dataTable.Columns.Add("DatumVazenja");
            dataTable.Columns.Add("KolicinaLeka");
            dataTable.Columns.Add("Doza");

            dataTable.Columns.Add(Constants.ConcatenatedField, typeof (string), "Id + ' : ' +Doza");

            List<Recept> objList;
            using (var session = DataLayer.GetSession())
                objList = session.QueryOver<Recept>().Where(x => x.Deleted == false)?.List<Recept>() as List<Recept>;


            if (objList == null) return dataTable;
            objList.ForEach(x => dataTable.Rows.Add(x.Id, x.DatumRealizacije, x.DatumVazenja, x.KolicinaLeka, x.Doza));

            return dataTable;
        }
    }
}