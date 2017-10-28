using Core;
using Core.Entities;
using FluentNHibernate.Mapping;

namespace Data.Mappings
{
    public class TabletaMapping : SubclassMap<Tableta>
    {
        public TabletaMapping()
        {
            DiscriminatorValue(Enum.TipPakovanja.Tableta);
        }
    }
}