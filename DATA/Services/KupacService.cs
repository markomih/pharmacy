using System.Collections.Generic;
using System.Data;
using System.Linq;
using Core.Entities;
using Core.Services;
using NHibernate.Linq;

namespace Data.Services
{
    public class KupacService : Service<Kupac>, IKupacService
    {
        public KupacService(NewDataLayer dataLayer) : base(dataLayer)
        {
        }

        public override Kupac Get(int id)
        {
            using (var session = DataLayer.GetSession())
            {
                var obj = session.Get<Kupac>(id);

                if (obj == null) return null;

                obj.ReceptList = session.Query<Recept>().Where(x => x.Deleted == false).ToList();
                return obj;
            }
        }

        public DataTable GetDataTable()
        {
            var dataTable = new DataTable("Kupac");

            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("LIme");
            dataTable.Columns.Add("Prezime");
            dataTable.Columns.Add("Email");
            dataTable.Columns.Add("BrojTelefona");

            //dataTable.Columns.Add(Constants.ConcatenatedField, typeof(string), "Id + ' : ' +LIme");

            List<Kupac> objList;
            using (var session = DataLayer.GetSession())
                objList = session.QueryOver<Kupac>().Where(x => x.Deleted == false)?.List<Kupac>() as List<Kupac>;

            if (objList == null) return dataTable;
            objList.ForEach(
                x => dataTable.Rows.Add(x.Id, x.Ime.LIme, x.Ime.Prezime, x.Kontakt?.Email, x.Kontakt?.BrojTelefona));

            return dataTable;

        }
    }
}