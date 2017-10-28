using Core;
using Core.Entities;
using FluentNHibernate.Mapping;

namespace Data.Mappings
{
    public class PrasakMapping : SubclassMap<Prasak>
    {
        public PrasakMapping()
        {
            DiscriminatorValue(Enum.TipPakovanja.Prasak);
        }
    }
}