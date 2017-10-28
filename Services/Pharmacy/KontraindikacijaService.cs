using System;
using System.Collections.Generic;
using System.Data;
using Core;
using Core.Entities;
using Core.Services;
using Data;

namespace Services
{
    public class KontraindikacijaService : Service<Kontraindikacija>, IKontraindikacijaService
    {
        public KontraindikacijaService(NewDataLayer dataLayer) : base(dataLayer)
        {
        }

        public override Kontraindikacija Get(int id)
        {
            using (var session = DataLayer.GetSession())
            {
                var obj = session.Get<Kontraindikacija>(id);

                if (obj == null) return null;

                if (obj.Bolest != null)
                    obj.Bolest = session.Get<Bolest>(obj.Bolest.Id);
                if (obj.Lek != null)
                    obj.Lek = session.Get<Lek>(obj.Lek.Id);
                if (obj.Pakovanje != null)
                    obj.Pakovanje = session.Get<Pakovanje>(obj.Pakovanje.Id);
                return obj;
            }
        }

        public override void Update(int id, Kontraindikacija entity)
        {
            using (var session = DataLayer.GetSession())
            {
                try
                {
                    var obj = Get(id);

                    obj.Bolest = entity.Bolest;
                    obj.Lek = entity.Lek;
                    obj.Pakovanje = entity.Pakovanje;
                    obj.Opis = entity.Opis;

                    session.Update(obj);
                    session.BeginTransaction().Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public override void Delete(int id)
        {
            using (var session = DataLayer.GetSession())
            {
                try
                {
                    var entity = session.Get<Kontraindikacija>(id);

                    entity.Deleted = true;
                    session.Update(entity);
                    session.BeginTransaction().Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public DataTable GetDataTable()
        {
            var dataTable = new DataTable("Kontraindikacija");

            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Opis");

            dataTable.Columns.Add(Constants.ConcatenatedField, typeof (string), "Id + ' : ' +Opis");

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