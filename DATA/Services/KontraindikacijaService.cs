using System.Collections.Generic;
using System.Data;
using Core.Entities;
using Core.Services;

namespace Data.Services
{
    public class KontraindikacijaService : Service<Kontraindikacija>, IKontraindikacijaService
    {
        public KontraindikacijaService(NewDataLayer dataLayer) : base(dataLayer)
        {
        }

        public override Kontraindikacija Get(int id)
        {
            using (var session = Data.DataLayer.GetSession())
            {
                var obj = session.Get<Kontraindikacija>(id);

                return obj;
            }
        }

        public DataTable GetDataTable()
        {
            var dataTable = new DataTable("Kontraindikacija");

            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Opis");

            //dataTable.Columns.Add(Constants.ConcatenatedField, typeof(string), "Id + ' : ' +Opis");

            List<Kontraindikacija> objList;
            using (var session = DataLayer.GetSession())
                objList =
                    session.QueryOver<Kontraindikacija>().Where(x => x.Deleted == false)?.List<Kontraindikacija>() as
                        List<Kontraindikacija>;


            if (objList == null) return dataTable;
            objList.ForEach(x => dataTable.Rows.Add(x.Id, x.Opis));

            return dataTable;

        }
    }
}