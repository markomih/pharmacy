using Core;
using Core.Entities;
using FluentNHibernate.Mapping;

namespace Data.Mappings
{
    public class AntibiotikMapping : SubclassMap<Antibiotik>
    {
        public AntibiotikMapping()
        {
            DiscriminatorValue(Enum.TipLeka.Antibiotik);
        }
    }
}