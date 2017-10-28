using Core;
using Core.Entities;
using FluentNHibernate.Mapping;

namespace Data.Mappings
{
    public class KontraindikacijaMap : ClassMap<Kontraindikacija>
    {
        public KontraindikacijaMap()
        {
            Table("KONTRAINDIKACIJA");

            Id(x => x.Id, "ID").GeneratedBy.SequenceIdentity(Constants.User + ".KONTRAINDIKACIJA_ID_SEQ");

            Map(x => x.Opis, "OPIS").Not.Nullable();
            Map(x => x.Deleted, "DELETED");

            References(x => x.Lek).Column("LEK_ID").LazyLoad();
            References(x => x.Bolest).Column("BOLEST_ID").LazyLoad();
            References(x => x.Pakovanje).Column("PAKOVANJE_ID").LazyLoad();
        }
    }
}