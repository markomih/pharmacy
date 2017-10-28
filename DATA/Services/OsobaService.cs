using Core.Entities;
using Core.Services;

namespace Data.Services
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
    }
}