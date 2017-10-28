using System.Collections.Generic;
using System.Data;
using System.Linq;
using Core;
using Core.Entities;
using Core.Services;
using NHibernate.Linq;

namespace Data.Services
{
    public class ZaposleniService : Service<Zaposleni>, IZaposleniService
    {
        public ZaposleniService(NewDataLayer dataLayer) : base(dataLayer)
        {
        }

        public override Zaposleni Get(int id)
        {
            using (var session = DataLayer.GetSession())
            {
                var obj = session.Get<Zaposleni>(id);
                if (obj == null) return null;

                obj.ReceptList = session.Query<Recept>().Where(x => x.Deleted == false).ToList();
                return obj;
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

            //dataTable.Columns.Add(Constants.ConcatenatedField, typeof(string), "Id + ' : ' +LIme");

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