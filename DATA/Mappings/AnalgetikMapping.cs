using Core;
using Core.Entities;
using FluentNHibernate.Mapping;

namespace Data.Mappings
{
    public class AnalgetikMapping : SubclassMap<Analgetik>
    {
        public AnalgetikMapping()
        {
            DiscriminatorValue(Enum.TipLeka.Analgetik);
        }
    }
}