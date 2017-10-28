using System.Collections.Generic;
using System.Data;
using System.Linq;
using Core.Entities;
using Core.Services;
using NHibernate.Linq;

namespace Data.Services
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

                obj.KontraindikacijaList = session.Query<Kontraindikacija>().Where(x => x.Deleted == false).ToList();
                obj.LekList = session.Query<Lek>().Where(x => x.Deleted == false).ToList();
                return obj;
            }
        }

        public DataTable GetDataTable()
        {
            var dataTable = new DataTable("Bolesti");

            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("NarodniNaziv");
            dataTable.Columns.Add("LatinskiNaziv");
            dataTable.Columns.Add("Opis");

            //dataTable.Columns.Add(Constants.ConcatenatedField, typeof(string), "Id + ' : ' +LatinskiNaziv");

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