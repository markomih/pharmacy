using FluentNHibernate.Mapping;
using Core.Entities.Component;

namespace Data.Mappings.Component
{
    public class KontaktMap : ComponentMap<Kontakt>
    {
        public KontaktMap()
        {
            Map(x => x.Email, "EMAIL").Nullable();
            Map(x => x.BrojTelefona, "BROJ_TELEFONA").Nullable();
        }
    }
}