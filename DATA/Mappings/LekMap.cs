using Core;
using Core.Entities;
using FluentNHibernate.Mapping;

namespace Data.Mappings
{
    public class LekMap : ClassMap<Lek>
    {
        public LekMap()
        {
            Table("LEK");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            DiscriminateSubClassesOnColumn("TIP", Enum.TipLeka.Diuretik);

            Map(x => x.Dejstvo, "DEJSTVO");
            Map(x => x.NezeljeniEfekti, "NEZELJENI_EFEKTI");
            Map(x => x.NaRecept, "NA_RECEPT").Default("0");
            Map(x => x.ProcenatParticipacije, "PROCENAT_PARTICIPACIJE");
            Map(x => x.Cena, "CENA");
            Component(x => x.NazivLeka);
            Map(x => x.NacinDoziranja, "NACIN_DOZIRANJA").CustomType(typeof (int));
            Map(x => x.Deleted, "DELETED");

            References(x => x.Pakovanje).Column("PAKOVANJE_ID").LazyLoad();

            HasMany(x => x.KontraindikacijaList).KeyColumn("LEK_ID").LazyLoad().Inverse();

            HasMany(x => x.ReceptList).KeyColumn("LEK_ID").LazyLoad();

            #region

            HasManyToMany(x => x.BolestList)
                .Table("LEK_BOLEST")
                .ParentKeyColumn("LEK_ID")
                .ChildKeyColumn("BOLEST_ID")
                .Cascade.All()
                ;
           // HasMany(x => x.LekBolestList).KeyColumn("LEK_ID").LazyLoad().Cascade.All().Inverse();

            #endregion

            HasManyToMany(x => x.ProizvodjacList)
                .Table("LEK_PROIZVODJAC")
                .ParentKeyColumn("LEK_ID")
                .ChildKeyColumn("PROIZVODJAC_ID")
                .Cascade.SaveUpdate()
                .LazyLoad();

            HasManyToMany(x => x.ProdajnoMestoList)
                .Table("PRODAJNO_MESTO_LEK")
                .ParentKeyColumn("LEK_ID")
                .ChildKeyColumn("PRODAJNO_MESTO_ID")
                .LazyLoad();
        }
    }
}