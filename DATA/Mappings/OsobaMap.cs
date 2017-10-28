using Core.Entities;
using FluentNHibernate.Mapping;

namespace Data.Mappings
{
    public class OsobaMap : ClassMap<Osoba>
    {
        public OsobaMap()
        {
            Table("OSOBA");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Component(x => x.Ime);
            Component(x => x.Kontakt);
            Map(x => x.Deleted, "DELETED");
        }
    }
}