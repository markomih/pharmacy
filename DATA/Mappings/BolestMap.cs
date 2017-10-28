using Core;
using Core.Entities;
using FluentNHibernate.Mapping;

namespace Data.Mappings
{
    public class BolestMap : ClassMap<Bolest>
    {
        public BolestMap()
        {
            Table("BOLEST");

            Id(x => x.Id, "ID").GeneratedBy.SequenceIdentity(Constants.User + ".BOLEST_ID_SEQ");

            Component(x => x.NazivBolesti);
            Map(x => x.Deleted, "DELETED");
            Map(x => x.Opis, "OPIS");

            HasMany(x => x.KontraindikacijaList).KeyColumn("BOLEST_ID").LazyLoad();

            #region

            HasManyToMany(x => x.LekList)
                .Table("LEK_BOLEST")
                .ParentKeyColumn("BOLEST_ID")
                .ChildKeyColumn("LEK_ID")
                //.Inverse()
                .Cascade.All()
                //.Cascade.SaveUpdate()
                ;
            //HasMany(x => x.LekBolestList).KeyColumn("BOLEST_ID").LazyLoad().Cascade.All().Inverse();

            #endregion
        }
    }
}