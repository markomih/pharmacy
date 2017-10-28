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
    public class LekService : Service<Lek>, ILekService
    {
        public LekService(NewDataLayer dataLayer) : base(dataLayer)
        {
        }

        public override void Update(Lek entity)
        {
            using (var session = DataLayer.GetSession())
            {
                try
                {
                    var proizvodjacs = new List<Proizvodjac>();
                    var prodajnoMestos = new List<ProdajnoMesto>();
                    var kontraindikacijas = new List<Kontraindikacija>();
                    var recepts = new List<Recept>();
                    var bolests = new List<Bolest>();

                    if (entity.ProizvodjacList != null)
                        proizvodjacs.AddRange(entity.ProizvodjacList.Select(x => session.Get<Proizvodjac>(x.Id)));
                    if (entity.ProdajnoMestoList != null)
                        prodajnoMestos.AddRange(entity.ProdajnoMestoList.Select(x => session.Get<ProdajnoMesto>(x.Id)));

                    if (entity.KontraindikacijaList != null)
                        kontraindikacijas.AddRange(
                            entity.KontraindikacijaList.Select(x => session.Get<Kontraindikacija>(x.Id)));


                    recepts.AddRange(entity.ReceptList.Select(x => session.Get<Recept>(x.Id)));
                    bolests.AddRange(entity.BolestList.Select(x => session.Get<Bolest>(x.Id)));

                    entity.ProizvodjacList = proizvodjacs;
                    entity.ProdajnoMestoList = prodajnoMestos;
                    entity.KontraindikacijaList = kontraindikacijas;
                    entity.ReceptList = recepts;
                    entity.BolestList = bolests;

                    session.SaveOrUpdate(entity);
                    kontraindikacijas.ForEach(x => x.Lek = entity);
                    kontraindikacijas.ForEach(x => session.SaveOrUpdate(x));
                    session.Flush();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public override void Update(int id, Lek entity)
        {
            using (var session = DataLayer.GetSession())
            {
                try
                {
                    var obj = Get(id);

                    obj.ReceptList = entity.ReceptList;
                    obj.KontraindikacijaList = entity.KontraindikacijaList;
                    obj.ProdajnoMestoList = entity.ProdajnoMestoList;
                    obj.ProizvodjacList = entity.ProizvodjacList;
                    obj.BolestList = entity.BolestList;
                    obj.Cena = entity.Cena;
                    obj.Dejstvo = entity.Dejstvo;
                    obj.NaRecept = entity.NaRecept;
                    obj.NacinDoziranja = entity.NacinDoziranja;
                    obj.NezeljeniEfekti = entity.NezeljeniEfekti;
                    obj.NazivLeka = entity.NazivLeka;
                    obj.Pakovanje = entity.Pakovanje;
                    obj.ProcenatParticipacije = entity.ProcenatParticipacije;

                    session.Update(obj);
                    session.BeginTransaction().Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public override void Create(Lek entity)
        {
            using (var session = DataLayer.GetSession())
            {
                try
                {
                    var proizvodjacs = new List<Proizvodjac>();
                    var prodajnoMestos = new List<ProdajnoMesto>();
                    var kontraindikacijas = new List<Kontraindikacija>();
                    var recepts = new List<Recept>();
                    var bolests = new List<Bolest>();

                    proizvodjacs.AddRange(entity.ProizvodjacList.Select(x => session.Get<Proizvodjac>(x.Id)));
                    prodajnoMestos.AddRange(entity.ProdajnoMestoList.Select(x => session.Get<ProdajnoMesto>(x.Id)));

                    if (entity.ProizvodjacList != null)
                        proizvodjacs.AddRange(entity.ProizvodjacList.Select(x => session.Get<Proizvodjac>(x.Id)));
                    if (entity.ProdajnoMestoList != null)
                        prodajnoMestos.AddRange(entity.ProdajnoMestoList.Select(x => session.Get<ProdajnoMesto>(x.Id)));

                    if (entity.KontraindikacijaList != null)
                        kontraindikacijas.AddRange(
                            entity.KontraindikacijaList.Select(x => session.Get<Kontraindikacija>(x.Id)));

                    entity.ProizvodjacList = proizvodjacs;
                    entity.ProdajnoMestoList = prodajnoMestos;
                    entity.KontraindikacijaList = kontraindikacijas;
                    entity.ReceptList = recepts;
                    entity.BolestList = bolests;

                    session.SaveOrUpdate(entity);
                    kontraindikacijas.ForEach(x => x.Lek = entity);
                    kontraindikacijas.ForEach(x => session.SaveOrUpdate(x));
                    session.BeginTransaction().Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public override Lek Get(int id)
        {
            using (var session = DataLayer.GetSession())
            {
                var obj = session.Get<Lek>(id);

                if (obj == null) return null;

                if (obj.Pakovanje != null)
                    obj.Pakovanje = session.Get<Pakovanje>(obj.Pakovanje?.Id);

                obj.BolestList =
                    session.Query<LekBolest>().Where(x => x.Lek.Id == obj.Id).Select(x => x.Bolest).ToList();
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
                    var entity = session.Get<Lek>(id);

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
            var dataTable = new DataTable("Lek");

            dataTable.Columns.Add("id");
            dataTable.Columns.Add("Tip Leka");
            dataTable.Columns.Add("Participacija");
            dataTable.Columns.Add("Cena");
            dataTable.Columns.Add("HemijskiNazivLeka");
            dataTable.Columns.Add("NacainDoziranja");
            dataTable.Columns.Add("Recept");
            dataTable.Columns.Add(Constants.ConcatenatedField, typeof (string), "Id + ' : ' +HemijskiNazivLeka");

            List<Lek> leks;
            using (var session = DataLayer.GetSession())
            {
                leks = session.QueryOver<Lek>()
                    .Where(x => x.NaRecept == naRecept && x.Deleted == false).List<Lek>() as List<Lek>;
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
                    lek.NaRecept.ToString()
                    );
            }
            return dataTable;
        }

        public DataTable GetDataTable()
        {
            var dataTable = new DataTable("Lek");

            dataTable.Columns.Add("id");
            dataTable.Columns.Add("Tip Leka");
            dataTable.Columns.Add("Participacija");
            dataTable.Columns.Add("Cena");
            dataTable.Columns.Add("HemijskiNazivLeka");
            dataTable.Columns.Add("NacainDoziranja");
            dataTable.Columns.Add("Recept");

            dataTable.Columns.Add(Constants.ConcatenatedField, typeof (string), "Id + ' : ' +HemijskiNazivLeka");

            List<Lek> leks;
            using (var session = DataLayer.GetSession())
                leks = session.QueryOver<Lek>().Where(x => x.Deleted == false).List<Lek>() as List<Lek>;

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
                    lek.NaRecept.ToString()
                    );
            }
            return dataTable;
        }
    }
}