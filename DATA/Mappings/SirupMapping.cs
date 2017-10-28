using Core;
using Core.Entities;
using FluentNHibernate.Mapping;

namespace Data.Mappings
{
    public class SirupMapping : SubclassMap<Sirup>
    {
        public SirupMapping()
        {
            DiscriminatorValue(Enum.TipPakovanja.Sirup);
        }
    }
}