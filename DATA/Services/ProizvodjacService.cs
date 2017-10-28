using System.Collections.Generic;
using System.Data;
using System.Linq;
using Core.Entities;
using Core.Services;
using NHibernate.Linq;

namespace Data.Services
{
    public class ProizvodjacService : Service<Proizvodjac>, IProizvodjacService
    {
        public ProizvodjacService(NewDataLayer dataLayer) : base(dataLayer)
        {
        }

        public override Proizvodjac Get(int id)
        {
            using (var session = DataLayer.GetSession())
            {
                var obj = session.Get<Proizvodjac>(id);

                if (obj == null) return null;

                obj.LekList = session.Query<Lek>().Where(x => x.Deleted == false).ToList();
                return obj;
            }
        }

        public DataTable GetDataTable()
        {
            var dataTable = new DataTable("Proizvodjac");

            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Naziv");

            //dataTable.Columns.Add(Constants.ConcatenatedField, typeof(string), "Id + ' : ' +Naziv");

            List<Proizvodjac> objList;
            using (var session = DataLayer.GetSession())
                objList =
                    session.QueryOver<Proizvodjac>().Where(x => x.Deleted == false)?.List<Proizvodjac>() as
                        List<Proizvodjac>;


            if (objList == null) return dataTable;
            objList.ForEach(x => dataTable.Rows.Add(x.Id, x.Naziv));

            return dataTable;
        }
    }
}