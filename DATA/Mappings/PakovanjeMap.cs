using Core;
using Core.Entities;
using FluentNHibernate.Mapping;

namespace Data.Mappings
{
    public class PakovanjeMap : ClassMap<Pakovanje>
    {
        public PakovanjeMap()
        {
            Table("PAKOVANJE");
            DiscriminateSubClassesOnColumn("TIP", Enum.TipPakovanja.Injekcija);
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Sastav, "SASTAV");
            Map(x => x.Kolicina, "KOLICINA");
            Map(x => x.Deleted, "DELETED");

            HasMany(x => x.KontraindikacijaList).KeyColumn("PAKOVANJE_ID").LazyLoad();
            HasMany(x => x.LekList).KeyColumn("PAKOVANJE_ID").LazyLoad();
        }
    }
}