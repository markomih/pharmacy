using FluentNHibernate.Mapping;
using Core.Entities.Component;

namespace Data.Mappings.Component
{
    public class LokacijaMap : ComponentMap<Lokacija>
    {
        public LokacijaMap()
        {
            Map(x => x.Adresa, "ADRESA").Nullable();
            Map(x => x.Mesto, "MESTO").Nullable();
        }
    }
}