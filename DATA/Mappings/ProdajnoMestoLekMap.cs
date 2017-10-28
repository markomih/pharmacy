using Core.Entities;
using FluentNHibernate.Mapping;

namespace Data.Mappings
{
    public class ProdajnoMestoLekMap : ClassMap<ProdajnoMestoLek>
    {
        public ProdajnoMestoLekMap()
        {
            Table("PRODAJNO_MESTO_LEK");
            CompositeId()
                .KeyReference(x => x.Lek, "LEK_ID")
                .KeyReference(x => x.ProdajnoMesto, "PRODAJNO_MESTO_ID");

            Map(x => x.Kolicina, "KOLICINA").LazyLoad();
        }
    }
}