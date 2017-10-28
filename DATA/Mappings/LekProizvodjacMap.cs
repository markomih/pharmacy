using Core.Entities;
using FluentNHibernate.Mapping;

namespace Data.Mappings
{
    public class LekProizvodjacMap : ClassMap<LekProizvodjac>
    {
        public LekProizvodjacMap()
        {
            Table("LEK_PROIZVODJAC");
            CompositeId()
                .KeyReference(x => x.Lek, "LEK_ID")
                .KeyReference(x => x.Proizvodjac, "PROIZVODJAC_ID");
            
            Map(x => x.KomercialniNacivLeka, "KOMERCIJALNI_NAZIV_LEKA").Unique();
        }
    }
}