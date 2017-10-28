using Core.Entities;
using FluentNHibernate.Mapping;

namespace Data.Mappings
{
    public class ZaposleniMap : SubclassMap<Zaposleni>
    {
        public ZaposleniMap()
        {
            Table("ZAPOSLENI");
            KeyColumn("ID");

            Map(x => x.DatumRodjenja, "DATUM_RODJENJA");
            Component(x => x.Lokacija);
            Map(x => x.Jmbg, "JMBG").Unique();
            Map(x => x.DatumZaposljavanja, "DATUM_ZAPOSLJENJA");

            Map(x => x.FFarmaceut).Access.Property().Default("0");
            Map(x => x.DatumDiplomiranja, "DATUM_DIPLOMIRANJA").Nullable();
            Map(x => x.DatumObnoveLicence, "DATUM_OBNOVE_LICENCE").Nullable();

            References(x => x.ProdajnoMesto).Column("PRODAJNO_MESTO_ID").LazyLoad().Cascade.SaveUpdate();

            HasMany(x => x.ReceptList).KeyColumn("FARMACEUT_ID");
        }
    }
}