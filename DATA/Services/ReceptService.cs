using System.Collections.Generic;
using System.Data;
using Core.Entities;
using Core.Services;

namespace Data.Services
{
    public class ReceptService : Service<Recept>, IReceptService
    {
        public ReceptService(NewDataLayer dataLayer) : base(dataLayer)
        {
        }

        public override Recept Get(int id)
        {
            using (var session = DataLayer.GetSession())
            {
                var obj = session.Get<Recept>(id);

                return obj;
            }
        }

        public DataTable GetDataTable()
        {
            var dataTable = new DataTable("Recept");

            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("DatumRealizacije");
            dataTable.Columns.Add("DatumVazenja");
            dataTable.Columns.Add("KolicinaLeka");
            dataTable.Columns.Add("Doza");

            //dataTable.Columns.Add(Constants.ConcatenatedField, typeof(string), "Id + ' : ' +Doza");

            List<Recept> objList;
            using (var session = Data.DataLayer.GetSession())
                objList = session.QueryOver<Recept>().Where(x => x.Deleted == false)?.List<Recept>() as List<Recept>;


            if (objList == null) return dataTable;
            objList.ForEach(x => dataTable.Rows.Add(x.Id, x.DatumRealizacije, x.DatumVazenja, x.KolicinaLeka, x.Doza));

            return dataTable;
        }
    }
}