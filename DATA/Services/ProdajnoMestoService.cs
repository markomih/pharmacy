using System.Collections.Generic;
using System.Data;
using System.Linq;
using Core.Entities;
using Core.Services;
using NHibernate.Linq;

namespace Data.Services
{
    public class ProdajnoMestoService : Service<ProdajnoMesto>, IProdajnoMestoService
    {
        public ProdajnoMestoService(NewDataLayer dataLayer) : base(dataLayer)
        {
        }

        public override ProdajnoMesto Get(int id)
        {
            using (var session = DataLayer.GetSession())
            {
                var obj = session.Get<ProdajnoMesto>(id);

                if (obj == null) return null;

                obj.LekList = session.Query<Lek>().Where(x => x.Deleted == false).ToList();
                obj.ReceptList = session.Query<Recept>().Where(x => x.Deleted == false).ToList();
                obj.ZaposleniList = session.Query<Zaposleni>().Where(x => x.Deleted == false).ToList();
                return obj;
            }
        }

        public DataTable GetDataTable()
        {
            var dataTable = new DataTable("ProdajnoMesto");

            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Naziv");
            dataTable.Columns.Add("Adresa");
            dataTable.Columns.Add("Mesto");

            //dataTable.Columns.Add(Constants.ConcatenatedField, typeof(string), "Id + ' : ' +Naziv");

            List<ProdajnoMesto> objList;
            using (var session = DataLayer.GetSession())
                objList =
                    session.QueryOver<ProdajnoMesto>().Where(x => x.Deleted == false)?.List<ProdajnoMesto>() as
                        List<ProdajnoMesto>;

            if (objList == null) return dataTable;
            objList.ForEach(x => dataTable.Rows.Add(x.Id, x.Naziv, x.Lokacija.Adresa, x.Lokacija.Mesto));

            return dataTable;
        }
    }
}