using Core;
using Core.Entities;
using FluentNHibernate.Mapping;

namespace Data.Mappings
{
    public class ApotekarskaUstanovaMap : ClassMap<ApotekarskaUstanova>
    {
        public ApotekarskaUstanovaMap()
        {
            Table("APOTEKARSKA_USTANOVA");
            Id(x => x.Id, "ID").GeneratedBy.SequenceIdentity(Constants.User + ".APOTEKARSKA_USTANOVA_ID_SEQ");

            Map(x => x.Naziv, "NAZIV").Not.Nullable();
            Map(x => x.Sajt, "SAJT");
            Map(x => x.Deleted, "DELETED");

            Component(x => x.Kontakt);
            HasMany(x => x.ProdajnoMestoList).KeyColumn("APOTEKARSKA_USTANOVA_ID").LazyLoad();
        }
    }
}
