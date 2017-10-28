using System;

namespace Core
{
    public static class Enum
    {
        public enum Entity
        {
            Analgetik,
            Antibiotik,
            Antipiretik,
            ApotekarskaUstanova,
            Bolest,
            Diuretik,
            Kupac,
            Lek,
            Lekar,
            Pakovanje,
            ProdajnoMesto,
            Proizvodjac,
            Recept,
            Zaposleni
        }

        public enum NacinDoziranja
        {
            Trudnice = 1,
            Deca,
            Odrasli
        }

        public enum OsobaTip
        {
            Kupac,
            Zaposleni,
            Lekar,
            Farmaceut
        }

        public enum TipLeka
        {
            Antibiotik,
            Antipiretik,
            Analgetik,
            Diuretik
        }

        public enum TipPakovanja
        {
            Sirup,
            Prasak,
            Injekcija,
            Tableta
        }

        public enum ZaposleniTip
        {
            Zaposleni,
            Farmaceut
        }

        public static string GetTipLeka(TipLeka tipLeka)
        {
            switch (tipLeka)
            {
                case TipLeka.Analgetik:
                    return "Analgetici";
                case TipLeka.Antipiretik:
                    return "Antipiretici";
                case TipLeka.Antibiotik:
                    return "Antibiotici";
                case TipLeka.Diuretik:
                    return "Diuretici";
                default:
                    return "Lekovi";
            }
        }

        public static TipLeka GetEnumTipLeka(string tipLeka)
        {
            if (tipLeka == TipLeka.Antipiretik.ToString())
            {
                return TipLeka.Antipiretik;
            }
            if (tipLeka == TipLeka.Antibiotik.ToString())
            {
                return TipLeka.Antibiotik;
            }
            if (tipLeka == TipLeka.Analgetik.ToString())
            {
                return TipLeka.Analgetik;
            }
            if (tipLeka == TipLeka.Diuretik.ToString())
            {
                return TipLeka.Diuretik;
            }
            throw new Exception("unknown tip leka");
        }

        public static NacinDoziranja GetEnumNacinDoziranja(string nacinDoziranja)
        {
            switch (nacinDoziranja)
            {
                case "Trudnice":
                    return NacinDoziranja.Trudnice;
                case "Deca":
                    return NacinDoziranja.Deca;
                case "Odrasli":
                    return NacinDoziranja.Odrasli;
            }
            return NacinDoziranja.Trudnice;
        }

        public static string GetNacinDoziranja(NacinDoziranja nacinDoziranja)
        {
            switch (nacinDoziranja)
            {
                case NacinDoziranja.Deca:
                    return "Analgetici";
                case NacinDoziranja.Odrasli:
                    return "Odrasli";
                case NacinDoziranja.Trudnice:
                    return "Trudnice";
                default:
                    return "Nacin Doziranja";
            }
        }

        public static string GetEntity(Entity entities)
        {
            switch (entities)
            {
                case Entity.ApotekarskaUstanova:
                    return "Apotekarska Ustanove";
                case Entity.ProdajnoMesto:
                    return "Apotekarska Ustanove";
                default:
                    return entities.ToString();
            }
        }

        public static TipPakovanja GetEnumTipPakovanja(string tipPakovanja)
        {
            if (tipPakovanja == TipPakovanja.Tableta.ToString())
                return TipPakovanja.Tableta;

            if (tipPakovanja == TipPakovanja.Injekcija.ToString())
                return TipPakovanja.Injekcija;

            if (tipPakovanja == TipPakovanja.Prasak.ToString())
                return TipPakovanja.Prasak;

            if (tipPakovanja == TipPakovanja.Sirup.ToString())
                return TipPakovanja.Sirup;

            throw new Exception("unknown tip pakovanja");
        }
    }
}