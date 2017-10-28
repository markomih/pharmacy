using System.Collections.Generic;
using System.Data;
using System.Linq;
using Core.Entities;
using Core.Services;
using NHibernate.Linq;

namespace Data.Services
{
    public class LekService : Service<Lek>, ILekService
    {
        public LekService(NewDataLayer dataLayer) : base(dataLayer)
        {
        }

        public override Lek Get(int id)
        {
            using (var session = DataLayer.GetSession())
            {
                var obj = session.Get<Lek>(id);

                if (obj == null) return null;

                obj.Pakovanje = session.Get<Pakovanje>(obj.Pakovanje?.Id);

                obj.BolestList = session.Query<Bolest>().Where(x => x.Deleted == false).ToList();
                obj.KontraindikacijaList =
                    session.Query<Kontraindikacija>().Where(x => x.Deleted == false).ToList();
                obj.ProdajnoMestoList = session.Query<ProdajnoMesto>().Where(x => x.Deleted == false).ToList();
                obj.ReceptList = session.Query<Recept>().Where(x => x.Deleted == false).ToList();
                obj.ProizvodjacList = session.Query<Proizvodjac>().Where(x => x.Deleted == false).ToList();

                return obj;
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
            //dataTable.Columns.Add(Constants.ConcatenatedField, typeof(string), "Id + ' : ' +HemijskiNazivLeka");

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

            //dataTable.Columns.Add(Constants.ConcatenatedField, typeof(string), "Id + ' : ' +HemijskiNazivLeka");

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