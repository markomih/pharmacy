using Core;
using Core.Entities;
using FluentNHibernate.Mapping;

namespace Data.Mappings
{
    public class DiuretikMapping : SubclassMap<Diuretik>
    {
        public DiuretikMapping()
        {
            DiscriminatorValue(Enum.TipLeka.Diuretik);
        }
    }
}