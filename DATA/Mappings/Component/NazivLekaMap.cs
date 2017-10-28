using Core.Entities.Component;
using FluentNHibernate.Mapping;

namespace Data.Mappings.Component
{
    public class NazivLekaMap : ComponentMap<NazivLeka>
    {
        public NazivLekaMap()
        {
            Map(x => x.HemijskiNaziv, "HEMIJSKI_NAZIV").Nullable();
        }
    }
}