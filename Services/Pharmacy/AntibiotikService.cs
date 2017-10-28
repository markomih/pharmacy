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
    public class AntibiotikService : Service<Antibiotik>, IAntibiotikService
    {
        public AntibiotikService(NewDataLayer dataLayer) : base(dataLayer)
        {
        }

        public override void Create(Antibiotik entity)
        {
            ServiceProvider.Get<LekService>().Create(entity);
        }

        public override void Update(Antibiotik entity)
        {
            ServiceProvider.Get<LekService>().Update(entity);
        }
        public override void Update(int id, Antibiotik entity)
        {
            ServiceProvider.Get<LekService>().Update(id, entity);
        }
        public override Antibiotik Get(int id)
        {
            using (var session = DataLayer.GetSession())
            {
                var obj = session.Get<Antibiotik>(id);

                if (obj == null) return null;

                if (obj.Pakovanje != null)
                    obj.Pakovanje = session.Get<Pakovanje>(obj.Pakovanje?.Id);

                obj.BolestList = session.Query<Bolest>().Where(x => x.Deleted == false).ToList();
                obj.KontraindikacijaList =
                    session.Query<Kontraindikacija>().Where(x => x.Deleted == false && x.Lek.Id == obj.Id).ToList();
                obj.ProdajnoMestoList =
                    session.Query<ProdajnoMestoLek>()
                        .Where(x => x.Lek.Id == obj.Id)
                        .Select(x => x.ProdajnoMesto)
                        .ToList();
                obj.ReceptList = session.Query<Recept>().Where(x => x.Deleted == false && x.Lek.Id == obj.Id).ToList();
                obj.ProizvodjacList =
                    session.Query<LekProizvodjac>().Where(x => x.Lek.Id == obj.Id).Select(x => x.Proizvodjac).ToList();

                return obj;
            }
        }

        public override void Delete(int id)
        {
            using (var session = DataLayer.GetSession())
            {
                try
                {
                    var entity = session.Get<Antibiotik>(id);

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

        public DataTable GetDataTable(bool naRecept)
        {
            var dataTable = new DataTable("Antibiotici");

            dataTable.Columns.Add("id");
            dataTable.Columns.Add("Tip Leka");
            dataTable.Columns.Add("Participacija");
            dataTable.Columns.Add("Cena");
            dataTable.Columns.Add("HemijskiNazivLeka");
            dataTable.Columns.Add("NacainDoziranja");
            dataTable.Columns.Add("Recept");
            dataTable.Columns.Add(Constants.ConcatenatedField, typeof (string), "Id + ' : ' +HemijskiNazivLeka");

            List<Antibiotik> leks;
            using (var session = DataLayer.GetSession())
            {
                leks = session.QueryOver<Antibiotik>()
                    .Where(x => x.NaRecept == naRecept && x.Deleted == false).List<Antibiotik>() as List<Antibiotik>;
            }


            if (leks == null) return dataTable;
            foreach (var lek in leks)
            {
                dataTable.Rows.Add(
                    lek.Id,
                    lek.TipLeka.ToString(),
                    lek.ProcenatParticipacije,
                    lek.Cena,
                    lek.NazivLeka.HemijskiNaziv,
                    lek.NacinDoziranja.ToString(),
                    lek.NaRecept ? "Da" : "Ne"
                    );
            }
            return dataTable;
        }
    }
}