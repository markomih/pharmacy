using Core.Entities;
using FluentNHibernate.Mapping;

namespace Data.Mappings
{
    public class KupacMap : SubclassMap<Kupac>
    {
        public KupacMap()
        {
            Table("KUPAC");

            KeyColumn("ID");
            Map(x => x.Pazar, "PAZAR");

            HasMany(x => x.ReceptList).KeyColumn("KUPAC_ID").LazyLoad();
        }
    }
}