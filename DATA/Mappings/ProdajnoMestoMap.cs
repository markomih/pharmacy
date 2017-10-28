using Core;
using Core.Entities;
using FluentNHibernate.Mapping;

namespace Data.Mappings
{
    public class ProdajnoMestoMap : ClassMap<ProdajnoMesto>
    {
        public ProdajnoMestoMap()
        {
            Table("PRODAJNO_MESTO");

            Id(x => x.Id, "ID").GeneratedBy.SequenceIdentity(Constants.User + ".PRODAJNO_MESTO_ID_SEQ");

            Map(x => x.Naziv, "NAZIV");
            Map(x => x.Deleted, "DELETED");
            Component(x => x.Lokacija);

            References(x => x.ApotekarskaUstanova).Column("APOTEKARSKA_USTANOVA_ID").LazyLoad();

            HasMany(x => x.ZaposleniList).KeyColumn("PRODAJNO_MESTO_ID").LazyLoad().Cascade.All();

            HasMany(x => x.ReceptList).KeyColumn("PRODAJNO_MESTO_ID").LazyLoad();

            HasManyToMany(x => x.LekList)
                .Table("PRODAJNO_MESTO_LEK")
                .ParentKeyColumn("PRODAJNO_MESTO_ID")
                .ChildKeyColumn("LEK_ID")
                //.Inverse()
                ;
        }
    }
}