using Core.Entities.Component;
using FluentNHibernate.Mapping;

namespace Data.Mappings.Component
{
    public class ImeMap : ComponentMap<Ime>
    {
        public ImeMap()
        {
            Map(x => x.LIme, "L_IME").Nullable();
            Map(x => x.Prezime, "PREZIME").Nullable();
        }
    }
}