using System;
using System.Data;
using Core.Entities;
using Core.Services;
using Data;

namespace Services
{
    public class OsobaService : Service<Osoba>, IOsobaService
    {
        public OsobaService(NewDataLayer dataLayer) : base(dataLayer)
        {
        }

        public override Osoba Get(int id)
        {
            using (var session = DataLayer.GetSession())
            {
                var obj = session.Get<Osoba>(id);

                return obj;
            }
        }

        public override void Update(int id, Osoba entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            using (var session = DataLayer.GetSession())
            {
                try
                {
                    var entity = session.Get<Osoba>(id);

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
            throw new NotImplementedException(); // TODO: implement
        }
    }
}