using Core;
using Core.Entities;
using FluentNHibernate.Mapping;

namespace Data.Mappings
{
    public class ProizvodjacMap : ClassMap<Proizvodjac>
    {
        public ProizvodjacMap()
        {
            Table("PROIZVODJAC");

            Id(x => x.Id, "ID").GeneratedBy.SequenceIdentity(Constants.User + ".PROIZVODJAC_ID_SEQ");

            Map(x => x.Deleted, "DELETED");
            Map(x => x.Naziv, "NAZIV");

            HasManyToMany(x => x.LekList)
                .Table("LEK_PROIZVODJAC")
                .ParentKeyColumn("PROIZVODJAC_ID")
                .ChildKeyColumn("LEK_ID")
                .Cascade.SaveUpdate()
                .LazyLoad();
        }
    }
}