using Core.Entities.Component;
using FluentNHibernate.Mapping;

namespace Data.Mappings.Component
{
    public class NazivBolestiMap : ComponentMap<NazivBolesti>
    {
        public NazivBolestiMap()
        {
            Map(x => x.LatinskiNaziv, "LATINSKI_NAZIV");
            Map(x => x.NarodniNaziv, "NARODNI_NAZIV").Nullable();
        }
    }
}