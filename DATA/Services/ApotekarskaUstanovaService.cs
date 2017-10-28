using System.Collections.Generic;
using System.Data;
using System.Linq;
using Core.Entities;
using Core.Services;
using NHibernate.Linq;

namespace Data.Services
{
    public class ApotekarskaUstanovaService : Service<ApotekarskaUstanova>, IApotekarskaUstanovaService
    {
        public ApotekarskaUstanovaService(NewDataLayer dataLayer) : base(dataLayer)
        {
        }

        public override ApotekarskaUstanova Get(int id)
        {
            using (var session = DataLayer.GetSession())
            {
                var obj = session.Get<ApotekarskaUstanova>(id);

                if (obj == null) return null;

                obj.ProdajnoMestoList = session.Query<ProdajnoMesto>().Where(x => x.Deleted == false).ToList();
                return obj;
            }
        }

        public DataTable GetDataTable()
        {
            var dataTable = new DataTable("ApotekarskaUstanova");

            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Naziv");
            dataTable.Columns.Add("Email");
            dataTable.Columns.Add("BrojTelefona");
            dataTable.Columns.Add("Sajt");

            //dataTable.Columns.Add(Constants.ConcatenatedField, typeof(string), "Id + ' : ' +Naziv");

            List<ApotekarskaUstanova> objList;
            using (var session = DataLayer.GetSession())
                objList =
                    session.QueryOver<ApotekarskaUstanova>().Where(x => x.Deleted == false)?.List<ApotekarskaUstanova>()
                        as List<ApotekarskaUstanova>;


            if (objList == null) return dataTable;
            objList.ForEach(x => dataTable.Rows.Add(x.Id, x.Naziv, x.Kontakt.Email, x.Kontakt.BrojTelefona, x.Sajt));

            return dataTable;
        }
    }
}