using Core;
using Core.Entities;
using FluentNHibernate.Mapping;

namespace Data.Mappings
{
    public class InjekcijaMapping : SubclassMap<Injekcija>
    {
        public InjekcijaMapping()
        {
            DiscriminatorValue(Enum.TipPakovanja.Injekcija);
        }
    }
}