using Core;
using Core.Entities;
using FluentNHibernate.Mapping;

namespace Data.Mappings
{
    public class ReceptMap : ClassMap<Recept>
    {
        public ReceptMap()
        {
            Table("RECEPT");

            Id(x => x.Id, "ID").GeneratedBy.SequenceIdentity(Constants.User + ".RECEPT_ID_SEQ");

            Map(x => x.DatumRealizacije, "DATUM_REALIZACIJE");
            Map(x => x.DatumVazenja, "DATUM_VAZENJA");
            Map(x => x.Deleted, "DELETED");
            Map(x => x.Doza, "DOZA");
            Map(x => x.KolicinaLeka, "KOLICINA_LEKA");

            References(x => x.Lek).Column("LEK_ID").LazyLoad();
            References(x => x.Farmaceut).Column("FARMACEUT_ID").LazyLoad();
            References(x => x.Lekar).Column("LEKAR_ID").LazyLoad();
            References(x => x.Kupac).Column("KUPAC_ID").LazyLoad();
            References(x => x.ProdajnoMesto).Column("PRODAJNO_MESTO_ID").LazyLoad();
        }
    }
}