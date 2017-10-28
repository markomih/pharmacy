using System.Collections.Generic;
using System.Data;
using System.Linq;
using Core.Entities;
using Core.Services;
using NHibernate.Linq;

namespace Data.Services
{
    public class TabletaService : Service<Tableta>, ITabletaService
    {
        public TabletaService(NewDataLayer dataLayer) : base(dataLayer)
        {
        }

        public override Tableta Get(int id)
        {
            using (var session = DataLayer.GetSession())
            {
                var obj = session.Get<Tableta>(id);

                if (obj == null) return null;

                obj.LekList = session.Query<Lek>().Where(x => x.Deleted == false).ToList();
                obj.KontraindikacijaList = session.Query<Kontraindikacija>().Where(x => x.Deleted == false).ToList();
                return obj;
            }
        }

        public DataTable GetDataTable()
        {
            var dataTable = new DataTable("Tableta");

            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Sastav");
            dataTable.Columns.Add("Kolicina");
            dataTable.Columns.Add("Tip");

            //dataTable.Columns.Add(Constants.ConcatenatedField, typeof(string), "Id + ' : ' +Tip");

            List<Tableta> objList;
            using (var session = Data.DataLayer.GetSession())
                objList = session.QueryOver<Tableta>().Where(x => x.Deleted == false)?.List<Tableta>() as List<Tableta>;

            if (objList == null) return dataTable;
            objList.ForEach(x => dataTable.Rows.Add(x.Id, x.Sastav, x.Kolicina, x.Tip.ToString()));

            return dataTable;
        }
    }
}