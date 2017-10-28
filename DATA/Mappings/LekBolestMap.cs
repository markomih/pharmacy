using Core.Entities;
using FluentNHibernate.Mapping;

namespace Data.Mappings
{
    public class LekBolestMap : ClassMap<LekBolest>
    {
        public LekBolestMap()
        {
            Table("LEK_BOLEST");
            CompositeId()
                .KeyReference(x => x.Lek, "LEK_ID")
                .KeyReference(x => x.Bolest, "BOLEST_ID");
        }
    }
}