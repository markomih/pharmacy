using System.Collections.Generic;
using System.Data;
using System.Linq;
using Core.Entities;
using Core.Services;
using NHibernate.Linq;

namespace Data.Services
{
    public class LekarService : Service<Lekar>, ILekarService
    {
        public LekarService(NewDataLayer dataLayer) : base(dataLayer)
        {
        }

        public override Lekar Get(int id)
        {
            using (var session = DataLayer.GetSession())
            {
                var obj = session.Get<Lekar>(id);

                if (obj == null) return null;

                obj.ReceptList = session.Query<Recept>().Where(x => x.Deleted == false).ToList();
                return obj;
            }
        }

        public DataTable GetDataTable()
        {
            var dataTable = new DataTable("Lekar");

            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("LIme");
            dataTable.Columns.Add("Prezime");
            dataTable.Columns.Add("Email");
            dataTable.Columns.Add("BrojTelefona");

            //dataTable.Columns.Add(Constants.ConcatenatedField, typeof(string), "Id + ' : ' +LIme");

            List<Lekar> objList;
            using (var session = DataLayer.GetSession())
                objList = session.QueryOver<Lekar>().Where(x => x.Deleted == false)?.List<Lekar>() as List<Lekar>;

            if (objList == null) return dataTable;
            objList.ForEach(
                x => dataTable.Rows.Add(x.Id, x.Ime.LIme, x.Ime.Prezime, x.Kontakt.Email, x.Kontakt.BrojTelefona));

            return dataTable;
        }
    }
}