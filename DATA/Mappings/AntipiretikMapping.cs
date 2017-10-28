using Core;
using Core.Entities;
using FluentNHibernate.Mapping;

namespace Data.Mappings
{
    public class AntipiretikMapping : SubclassMap<Antipiretik>
    {
        public AntipiretikMapping()
        {
            DiscriminatorValue(Enum.TipLeka.Antipiretik);
        }
    }
}