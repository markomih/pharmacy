using Core.Entities;
using FluentNHibernate.Mapping;

namespace Data.Mappings
{
    public class LekarMap : SubclassMap<Lekar>
    {
        public LekarMap()
        {
            Table("LEKAR");
            KeyColumn("ID");

            HasMany(x => x.ReceptList).KeyColumn("LEKAR_ID").LazyLoad();
        }
    }
}