//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using Core;
//using Core.Entities;
//using Core.Entities.Component;
//using NHibernate;
//using NHibernate.Linq;
//using NHibernate.Util;
//using Enum = Core.Enum;

//namespace Data
//{
//    public static class DataProvider
//    {
//        #region SeedData

//        public static void SeedData()
//        {
//            DeleteAllData();
//            var k1 = new Kupac
//            {
//                Kontakt = new Kontakt {BrojTelefona = "067891368"},
//                Ime = new Ime {LIme = "Pera", Prezime = "Pekic"}
//            };
//            var k2 = new Kupac
//            {
//                Ime = new Ime {LIme = "Maki", Prezime = "Makic"},
//                Pazar = 10
//            };
//            var proizvodjac = new Proizvodjac
//            {
//                Naziv = "hemofarm"
//            };

//            var groznicaBolest = new Bolest
//            {
//                NazivBolesti = new NazivBolesti {LatinskiNaziv = "Diferdemija", NarodniNaziv = "Groznica"},
//                Opis = "Uklanja temperaturu"
//            };

//            var drhtavicaBolest = new Bolest
//            {
//                NazivBolesti = new NazivBolesti {LatinskiNaziv = "Pelimerirdemija", NarodniNaziv = "Drhtavica"},
//                Opis = "Uklanja temperaturu"
//            };

//            var prolivBolest = new Bolest
//            {
//                NazivBolesti = new NazivBolesti {LatinskiNaziv = "Diureza", NarodniNaziv = "Proliv"},
//                Opis = "Uklanja temperaturu"
//            };

//            Pakovanje pakovanje = new Prasak
//            {
//                Kolicina = 10,
//                Sastav = "500mg acetilsalicilne kiseline"
//            };

//            var medisLek = new Proizvodjac {Naziv = "Medis Lek"};

//            var remedia = new ApotekarskaUstanova
//            {
//                Naziv = "Remedia Lek",
//                Kontakt = new Kontakt {Email = "office@remedia.com", BrojTelefona = "068474587"},
//                Sajt = "www.remedia.com"
//            };

//            Lek antipiretik = new Antipiretik
//            {
//                NazivLeka = new NazivLeka {HemijskiNaziv = "Ibo Brufen"},
//                Cena = 101.45,
//                Dejstvo = "Smanjuje bronhitis",
//                NacinDoziranja = Enum.NacinDoziranja.Deca,
//                NezeljeniEfekti = "malaksalost",
//                ProcenatParticipacije = 25.25,
//                Pakovanje = pakovanje
//            };

//            Lek diuretik = new Diuretik
//            {
//                NazivLeka = new NazivLeka {HemijskiNaziv = "Febricet"},
//                Cena = 111.45,
//                Dejstvo = "Smanjuje bronhitis",
//                NacinDoziranja = Enum.NacinDoziranja.Deca,
//                NezeljeniEfekti = "malaksalost",
//                ProcenatParticipacije = 25.25,
//                Pakovanje = pakovanje
//            };
//            var lekProizvodjacDuretika = new LekProizvodjac
//            {
//                Lek = diuretik,
//                Proizvodjac = medisLek,
//                KomercialniNacivLeka = "febricetko"
//            };

//            var lekProizvodjacAntipiretika = new LekProizvodjac
//            {
//                Lek = antipiretik,
//                Proizvodjac = medisLek,
//                KomercialniNacivLeka = "brufen"
//            };
//            var apotekaPlus = new ProdajnoMesto
//            {
//                Naziv = "Apoteka Plus",
//                ApotekarskaUstanova = remedia,
//                Lokacija = new Lokacija {Mesto = "Novi Sad", Adresa = "Jug Bogdana 11"}
//            };

//            var extraProdajnoMesto = new ProdajnoMesto
//            {
//                Naziv = "Extra Apoteka",
//                ApotekarskaUstanova = remedia,
//                Lokacija = new Lokacija {Mesto = "Nis", Adresa = "Bulevar Bogdana 11"}
//            };

//            var prodajnoMestoLek1 = new ProdajnoMestoLek
//            {
//                ProdajnoMesto = extraProdajnoMesto,
//                Lek = antipiretik,
//                Kolicina = 5
//            };
//            var zaposleni = new Zaposleni
//            {
//                Kontakt = new Kontakt {BrojTelefona = "0693511368"},
//                Ime = new Ime {LIme = "Dare", Prezime = "Dakic"},
//                Lokacija = new Lokacija {Adresa = "Bulevar 11", Mesto = "Nis"},
//                DatumRodjenja = new DateTime(1950, 10, 10),
//                DatumZaposljavanja = new DateTime(2000, 2, 2),
//                Jmbg = "12124231235134",
//                ProdajnoMesto = extraProdajnoMesto
//            };

//            var kontraindikacija1 = new Kontraindikacija
//            {
//                Opis =
//                    "Oprez pri primeni Brufena je potreban ako imate poremećaj rada jetre, bubrega ili srca, ulceroznog kolitisa ili Kronove bolesti, imate bronhijalnu astmu ili drugu alergijsku bolest.",
//                Lek = antipiretik,
//                Bolest = groznicaBolest,
//                Pakovanje = pakovanje
//            };

//            var kontraindikacija2 = new Kontraindikacija
//            {
//                Opis =
//                    "Oprez pri primeni  je potreban ako imate poremećaj rada jetre, ulceroznog kolitisa ili Kronove bolesti, imate bronhijalnu astmu ili drugu alergijsku bolest.",
//                Lek = diuretik,
//                Bolest = drhtavicaBolest
//            };

//            var lekar = new Lekar
//            {
//                Kontakt = new Kontakt {BrojTelefona = "121241212"},
//                Ime = new Ime {LIme = "Jovan", Prezime = "Jovic"}
//            };
//            var farmaceutZaposleni = new Zaposleni
//            {
//                Ime = new Ime {LIme = "Damir", Prezime = "Damirovic"},
//                Lokacija = new Lokacija {Adresa = "Trg 11", Mesto = "Nis"},
//                ProdajnoMesto = extraProdajnoMesto,
//                Kontakt = new Kontakt {Email = "Damir@lala.com"},
//                DatumDiplomiranja = new DateTime(2000, 2, 2),
//                DatumObnoveLicence = new DateTime(2002, 5, 5),
//                DatumRodjenja = new DateTime(1955, 5, 5),
//                DatumZaposljavanja = new DateTime(2000, 2, 2),
//                Jmbg = "121241241212",
//                FFarmaceut = true
//            };
//            var recept = new Recept
//            {
//                Lek = antipiretik,
//                ProdajnoMesto = extraProdajnoMesto,
//                Kupac = k2,
//                Lekar = lekar,
//                Farmaceut = farmaceutZaposleni,
//                Doza = 4,
//                DatumRealizacije = new DateTime(2015, 5, 5),
//                DatumVazenja = new DateTime(2016, 4, 4),
//                KolicinaLeka = 2
//            };
//            var lekBolest = new LekBolest
//            {
//                Lek = antipiretik,
//                Bolest = groznicaBolest
//            };

//            using (var session = DataLayer.GetSession())
//            {
//                Add(session, proizvodjac, k1, k2, groznicaBolest, drhtavicaBolest, prolivBolest);
//                Add(session, pakovanje, medisLek, remedia);
//                Add(session, antipiretik, diuretik);

//                Add(session, extraProdajnoMesto, apotekaPlus, prodajnoMestoLek1);
//                Add(session, lekar);
//                Add(session, lekProizvodjacAntipiretika, lekProizvodjacDuretika, zaposleni, farmaceutZaposleni);
//                // samo jednom zbog unique
//                Add(session, kontraindikacija1, kontraindikacija2);
//                Add(session, recept);
//                Add(session, lekBolest);
//            }

//            //GetAll<KupacService>().ForEach(Console.WriteLine);
//            //GetAll<Zaposleni>().ForEach(Console.WriteLine);
//            //GetAll<Farmaceut>().ForEach(Console.WriteLine);
//        }

//        #endregion

//        #region get Data Tables

//        #region Lek

//        public static DataTable GetAnalgetikDataTable(bool naRecept = true)
//        {
//            var dataTable = new DataTable("Analgetici");

//            dataTable.Columns.Add("id");
//            dataTable.Columns.Add("Tip Leka");
//            dataTable.Columns.Add("Participacija");
//            dataTable.Columns.Add("Cena");
//            dataTable.Columns.Add("HemijskiNazivLeka");
//            dataTable.Columns.Add("NacainDoziranja");
//            dataTable.Columns.Add("Recept");
//            dataTable.Columns.Add(Constants.ConcatenatedField, typeof (string), "Id + ' : ' +HemijskiNazivLeka");

//            List<Analgetik> leks;
//            using (var session = DataLayer.GetSession())
//                leks = (List<Analgetik>) session.QueryOver<Analgetik>()
//                    .Where(x => x.NaRecept == naRecept && x.Deleted == false)?.List<Analgetik>();

//            if (leks == null) return dataTable;
//            foreach (var lek in leks)
//            {
//                dataTable.Rows.Add(
//                    lek.Id,
//                    lek.TipLeka.ToString(),
//                    lek.ProcenatParticipacije,
//                    lek.Cena,
//                    lek.NazivLeka.HemijskiNaziv,
//                    lek.NacinDoziranja.ToString(),
//                    lek.NaRecept ? "Da" : "Ne"
//                    );
//            }
//            return dataTable;
//        }

//        public static DataTable GetAntibiotikDataTable(bool naRecept = true)
//        {
//            var dataTable = new DataTable("Antibiotici");

//            dataTable.Columns.Add("id");
//            dataTable.Columns.Add("Tip Leka");
//            dataTable.Columns.Add("Participacija");
//            dataTable.Columns.Add("Cena");
//            dataTable.Columns.Add("HemijskiNazivLeka");
//            dataTable.Columns.Add("NacainDoziranja");
//            dataTable.Columns.Add("Recept");
//            dataTable.Columns.Add(Constants.ConcatenatedField, typeof (string), "Id + ' : ' +HemijskiNazivLeka");

//            List<Antibiotik> leks;
//            using (var session = DataLayer.GetSession())
//            {
//                leks = session.QueryOver<Antibiotik>()
//                    .Where(x => x.NaRecept == naRecept && x.Deleted == false).List<Antibiotik>() as List<Antibiotik>;
//            }


//            if (leks == null) return dataTable;
//            foreach (var lek in leks)
//            {
//                dataTable.Rows.Add(
//                    lek.Id,
//                    lek.TipLeka.ToString(),
//                    lek.ProcenatParticipacije,
//                    lek.Cena,
//                    lek.NazivLeka.HemijskiNaziv,
//                    lek.NacinDoziranja.ToString(),
//                    lek.NaRecept ? "Da" : "Ne"
//                    );
//            }
//            return dataTable;
//        }

//        public static DataTable GetAntipiretikDataTable(bool naRecept = true)
//        {
//            var dataTable = new DataTable("Antipiretik");

//            dataTable.Columns.Add("id");
//            dataTable.Columns.Add("Tip Leka");
//            dataTable.Columns.Add("Participacija");
//            dataTable.Columns.Add("Cena");
//            dataTable.Columns.Add("HemijskiNazivLeka");
//            dataTable.Columns.Add("NacainDoziranja");
//            dataTable.Columns.Add("Recept");
//            dataTable.Columns.Add(Constants.ConcatenatedField, typeof (string), "Id + ' : ' +HemijskiNazivLeka");


//            List<Antipiretik> leks;
//            using (var session = DataLayer.GetSession())
//            {
//                leks = session.QueryOver<Antipiretik>()
//                    .Where(x => x.NaRecept == naRecept && x.Deleted == false).List<Antipiretik>() as List<Antipiretik>;
//            }


//            if (leks == null) return dataTable;
//            foreach (var lek in leks)
//            {
//                dataTable.Rows.Add(
//                    lek.Id,
//                    lek.TipLeka.ToString(),
//                    lek.ProcenatParticipacije,
//                    lek.Cena,
//                    lek.NazivLeka.HemijskiNaziv,
//                    lek.NacinDoziranja.ToString(),
//                    lek.NaRecept ? "Da" : "Ne"
//                    );
//            }
//            return dataTable;
//        }

//        public static DataTable GetDiuretikDataTable(bool naRecept = true)
//        {
//            var dataTable = new DataTable("Diuretik");

//            dataTable.Columns.Add("id");
//            dataTable.Columns.Add("Tip Leka");
//            dataTable.Columns.Add("Participacija");
//            dataTable.Columns.Add("Cena");
//            dataTable.Columns.Add("HemijskiNazivLeka");
//            dataTable.Columns.Add("NacainDoziranja");
//            dataTable.Columns.Add("Recept");
//            dataTable.Columns.Add(Constants.ConcatenatedField, typeof (string), "Id + ' : ' +HemijskiNazivLeka");

//            List<Diuretik> leks;
//            using (var session = DataLayer.GetSession())
//            {
//                leks = session.QueryOver<Diuretik>()
//                    .Where(x => x.NaRecept == naRecept && x.Deleted == false).List<Diuretik>() as List<Diuretik>;
//            }
//            if (leks == null) return dataTable;
//            foreach (var lek in leks)
//            {
//                dataTable.Rows.Add(
//                    lek.Id,
//                    lek.TipLeka.ToString(),
//                    lek.ProcenatParticipacije,
//                    lek.Cena,
//                    lek.NazivLeka.HemijskiNaziv,
//                    lek.NacinDoziranja.ToString(),
//                    lek.NaRecept ? "Da" : "Ne"
//                    );
//            }
//            return dataTable;
//        }

//        public static DataTable GetLekDataTable(bool naRecept)
//        {
//            var dataTable = new DataTable("Lek");

//            dataTable.Columns.Add("id");
//            dataTable.Columns.Add("Tip Leka");
//            dataTable.Columns.Add("Participacija");
//            dataTable.Columns.Add("Cena");
//            dataTable.Columns.Add("HemijskiNazivLeka");
//            dataTable.Columns.Add("NacainDoziranja");
//            dataTable.Columns.Add("Recept");
//            dataTable.Columns.Add(Constants.ConcatenatedField, typeof (string), "Id + ' : ' +HemijskiNazivLeka");

//            List<Lek> leks;
//            using (var session = DataLayer.GetSession())
//            {
//                leks = session.QueryOver<Lek>()
//                    .Where(x => x.NaRecept == naRecept && x.Deleted == false).List<Lek>() as List<Lek>;
//            }
//            if (leks == null) return dataTable;
//            foreach (var lek in leks)
//            {
//                dataTable.Rows.Add(
//                    lek.Id,
//                    lek.TipLeka.ToString(),
//                    lek.ProcenatParticipacije,
//                    lek.Cena,
//                    lek.NazivLeka.HemijskiNaziv,
//                    lek.NacinDoziranja.ToString(),
//                    lek.NaRecept.ToString()
//                    );
//            }
//            return dataTable;
//        }

//        public static DataTable GetLekDataTable()
//        {
//            var dataTable = new DataTable("Lek");

//            dataTable.Columns.Add("id");
//            dataTable.Columns.Add("Tip Leka");
//            dataTable.Columns.Add("Participacija");
//            dataTable.Columns.Add("Cena");
//            dataTable.Columns.Add("HemijskiNazivLeka");
//            dataTable.Columns.Add("NacainDoziranja");
//            dataTable.Columns.Add("Recept");

//            dataTable.Columns.Add(Constants.ConcatenatedField, typeof (string), "Id + ' : ' +HemijskiNazivLeka");

//            List<Lek> leks;
//            using (var session = DataLayer.GetSession())
//                leks = session.QueryOver<Lek>().Where(x => x.Deleted == false).List<Lek>() as List<Lek>;

//            if (leks == null) return dataTable;
//            foreach (var lek in leks)
//            {
//                dataTable.Rows.Add(
//                    lek.Id,
//                    lek.TipLeka.ToString(),
//                    lek.ProcenatParticipacije,
//                    lek.Cena,
//                    lek.NazivLeka.HemijskiNaziv,
//                    lek.NacinDoziranja.ToString(),
//                    lek.NaRecept.ToString()
//                    );
//            }
//            return dataTable;
//        }

//        #endregion

//        #region Pakovanje

//        public static DataTable GetPakovanjeDataTable()
//        {
//            var dataTable = new DataTable("Pakovanje");

//            dataTable.Columns.Add("Id");
//            dataTable.Columns.Add("Sastav");
//            dataTable.Columns.Add("Kolicina");
//            dataTable.Columns.Add("Tip");
//            dataTable.Columns.Add(Constants.ConcatenatedField, typeof (string), "Id + ' : ' +Tip");

//            List<Pakovanje> objList;
//            using (var session = DataLayer.GetSession())
//                objList =
//                    session.QueryOver<Pakovanje>().Where(x => x.Deleted == false)?.List<Pakovanje>() as List<Pakovanje>;

//            if (objList == null) return dataTable;
//            objList.ForEach(x => dataTable.Rows.Add(x.Id, x.Sastav, x.Kolicina, x.Tip.ToString()));

//            return dataTable;
//        }

//        public static DataTable GetPakovanjeSirupDataTable()
//        {
//            var dataTable = new DataTable("Sirup");

//            dataTable.Columns.Add("Id");
//            dataTable.Columns.Add("Sastav");
//            dataTable.Columns.Add("Kolicina");
//            dataTable.Columns.Add("Tip");

//            dataTable.Columns.Add(Constants.ConcatenatedField, typeof (string), "Id + ' : ' +Tip");

//            List<Sirup> objList;
//            using (var session = DataLayer.GetSession())
//                objList = session.QueryOver<Sirup>().Where(x => x.Deleted == false)?.List<Sirup>() as List<Sirup>;

//            if (objList == null) return dataTable;

//            objList.ForEach(x => dataTable.Rows.Add(x.Id, x.Sastav, x.Kolicina, x.Tip.ToString()));

//            return dataTable;
//        }

//        public static DataTable GetPakovanjePrasakDataTable()
//        {
//            var dataTable = new DataTable("Prasak");

//            dataTable.Columns.Add("Id");
//            dataTable.Columns.Add("Sastav");
//            dataTable.Columns.Add("Kolicina");
//            dataTable.Columns.Add("Tip");

//            dataTable.Columns.Add(Constants.ConcatenatedField, typeof (string), "Id + ' : ' +Tip");

//            List<Prasak> objList;
//            using (var session = DataLayer.GetSession())
//                objList = session.QueryOver<Prasak>().Where(x => x.Deleted == false)?.List<Prasak>() as List<Prasak>;

//            if (objList == null) return dataTable;
//            objList.ForEach(x => dataTable.Rows.Add(x.Id, x.Sastav, x.Kolicina, x.Tip.ToString()));

//            return dataTable;
//        }

//        public static DataTable GetPakovanjeInjekcijaDataTable()
//        {
//            var dataTable = new DataTable("Injekcija");

//            dataTable.Columns.Add("Id");
//            dataTable.Columns.Add("Sastav");
//            dataTable.Columns.Add("Kolicina");
//            dataTable.Columns.Add("Tip");

//            dataTable.Columns.Add(Constants.ConcatenatedField, typeof (string), "Id + ' : ' +Tip");

//            List<Injekcija> objList;
//            using (var session = DataLayer.GetSession())
//                objList =
//                    session.QueryOver<Injekcija>().Where(x => x.Deleted == false)?.List<Injekcija>() as List<Injekcija>;

//            if (objList == null) return dataTable;
//            objList.ForEach(x => dataTable.Rows.Add(x.Id, x.Sastav, x.Kolicina, x.Tip.ToString()));

//            return dataTable;
//        }

//        public static DataTable GetPakovanjeTabletaDataTable()
//        {
//            var dataTable = new DataTable("Tableta");

//            dataTable.Columns.Add("Id");
//            dataTable.Columns.Add("Sastav");
//            dataTable.Columns.Add("Kolicina");
//            dataTable.Columns.Add("Tip");

//            dataTable.Columns.Add(Constants.ConcatenatedField, typeof (string), "Id + ' : ' +Tip");

//            List<Tableta> objList;
//            using (var session = DataLayer.GetSession())
//                objList = session.QueryOver<Tableta>().Where(x => x.Deleted == false)?.List<Tableta>() as List<Tableta>;

//            if (objList == null) return dataTable;
//            objList.ForEach(x => dataTable.Rows.Add(x.Id, x.Sastav, x.Kolicina, x.Tip.ToString()));

//            return dataTable;
//        }

//        #endregion

//        #region ProdajnoMesto

//        public static DataTable GetProdajnoMestoDataTable()
//        {
//            var dataTable = new DataTable("ProdajnoMesto");

//            dataTable.Columns.Add("Id");
//            dataTable.Columns.Add("Naziv");
//            dataTable.Columns.Add("Adresa");
//            dataTable.Columns.Add("Mesto");

//            dataTable.Columns.Add(Constants.ConcatenatedField, typeof (string), "Id + ' : ' +Naziv");

//            List<ProdajnoMesto> objList;
//            using (var session = DataLayer.GetSession())
//                objList =
//                    session.QueryOver<ProdajnoMesto>().Where(x => x.Deleted == false)?.List<ProdajnoMesto>() as
//                        List<ProdajnoMesto>;

//            if (objList == null) return dataTable;
//            objList.ForEach(x => dataTable.Rows.Add(x.Id, x.Naziv, x.Lokacija.Adresa, x.Lokacija.Mesto));

//            return dataTable;
//        }

//        #endregion

//        #region Bolest

//        public static DataTable GetBolestDataTable()
//        {
//            var dataTable = new DataTable("Bolesti");

//            dataTable.Columns.Add("Id");
//            dataTable.Columns.Add("NarodniNaziv");
//            dataTable.Columns.Add("LatinskiNaziv");
//            dataTable.Columns.Add("Opis");

//            dataTable.Columns.Add(Constants.ConcatenatedField, typeof (string), "Id + ' : ' +LatinskiNaziv");

//            List<Bolest> objList;
//            using (var session = DataLayer.GetSession())
//                objList = session.QueryOver<Bolest>().Where(x => x.Deleted == false)?.List<Bolest>() as List<Bolest>;


//            if (objList == null) return dataTable;
//            objList.ForEach(
//                x => dataTable.Rows.Add(x.Id, x.NazivBolesti.NarodniNaziv, x.NazivBolesti.LatinskiNaziv, x.Opis));

//            return dataTable;
//        }

//        #endregion

//        #region Recept

//        public static DataTable GetReceptDataTable()
//        {
//            var dataTable = new DataTable("Recept");

//            dataTable.Columns.Add("Id");
//            dataTable.Columns.Add("DatumRealizacije");
//            dataTable.Columns.Add("DatumVazenja");
//            dataTable.Columns.Add("KolicinaLeka");
//            dataTable.Columns.Add("Doza");

//            dataTable.Columns.Add(Constants.ConcatenatedField, typeof (string), "Id + ' : ' +Doza");

//            List<Recept> objList;
//            using (var session = DataLayer.GetSession())
//                objList = session.QueryOver<Recept>().Where(x => x.Deleted == false)?.List<Recept>() as List<Recept>;


//            if (objList == null) return dataTable;
//            objList.ForEach(x => dataTable.Rows.Add(x.Id, x.DatumRealizacije, x.DatumVazenja, x.KolicinaLeka, x.Doza));

//            return dataTable;
//        }

//        #endregion

//        #region Proizvodjac

//        public static DataTable GetProizvodjacDataTable()
//        {
//            var dataTable = new DataTable("Proizvodjac");

//            dataTable.Columns.Add("Id");
//            dataTable.Columns.Add("Naziv");

//            dataTable.Columns.Add(Constants.ConcatenatedField, typeof (string), "Id + ' : ' +Naziv");

//            List<Proizvodjac> objList;
//            using (var session = DataLayer.GetSession())
//                objList =
//                    session.QueryOver<Proizvodjac>().Where(x => x.Deleted == false)?.List<Proizvodjac>() as
//                        List<Proizvodjac>;


//            if (objList == null) return dataTable;
//            objList.ForEach(x => dataTable.Rows.Add(x.Id, x.Naziv));

//            return dataTable;
//        }

//        #endregion

//        #region ApotekarskaUstanova

//        public static DataTable GetApotekarskaUstanovaDataTable()
//        {
//            var dataTable = new DataTable("ApotekarskaUstanova");

//            dataTable.Columns.Add("Id");
//            dataTable.Columns.Add("Naziv");
//            dataTable.Columns.Add("Email");
//            dataTable.Columns.Add("BrojTelefona");
//            dataTable.Columns.Add("Sajt");

//            dataTable.Columns.Add(Constants.ConcatenatedField, typeof (string), "Id + ' : ' +Naziv");

//            List<ApotekarskaUstanova> objList;
//            using (var session = DataLayer.GetSession())
//                objList =
//                    session.QueryOver<ApotekarskaUstanova>().Where(x => x.Deleted == false)?.List<ApotekarskaUstanova>()
//                        as List<ApotekarskaUstanova>;


//            if (objList == null) return dataTable;
//            objList.ForEach(x => dataTable.Rows.Add(x.Id, x.Naziv, x.Kontakt.Email, x.Kontakt.BrojTelefona, x.Sajt));

//            return dataTable;
//        }

//        #endregion

//        #region Kontraindikacija

//        public static DataTable GetKontraindikacijaDataTable()
//        {
//            var dataTable = new DataTable("Kontraindikacija");

//            dataTable.Columns.Add("Id");
//            dataTable.Columns.Add("Opis");

//            dataTable.Columns.Add(Constants.ConcatenatedField, typeof (string), "Id + ' : ' +Opis");

//            List<Kontraindikacija> objList;
//            using (var session = DataLayer.GetSession())
//                objList =
//                    session.QueryOver<Kontraindikacija>().Where(x => x.Deleted == false)?.List<Kontraindikacija>() as
//                        List<Kontraindikacija>;


//            if (objList == null) return dataTable;
//            objList.ForEach(x => dataTable.Rows.Add(x.Id, x.Opis));

//            return dataTable;
//        }

//        #endregion

//        #region Osoba

//        public static DataTable GetKupacDataTable()
//        {
//            var dataTable = new DataTable("Kupac");

//            dataTable.Columns.Add("Id");
//            dataTable.Columns.Add("LIme");
//            dataTable.Columns.Add("Prezime");
//            dataTable.Columns.Add("Email");
//            dataTable.Columns.Add("BrojTelefona");

//            dataTable.Columns.Add(Constants.ConcatenatedField, typeof (string), "Id + ' : ' +LIme");

//            List<Kupac> objList;
//            using (var session = DataLayer.GetSession())
//                objList = session.QueryOver<Kupac>().Where(x => x.Deleted == false)?.List<Kupac>() as List<Kupac>;

//            if (objList == null) return dataTable;
//            objList.ForEach(
//                x => dataTable.Rows.Add(x.Id, x.Ime.LIme, x.Ime.Prezime, x.Kontakt?.Email, x.Kontakt?.BrojTelefona));

//            return dataTable;
//        }

//        public static DataTable GetLekarDataTable()
//        {
//            var dataTable = new DataTable("Lekar");

//            dataTable.Columns.Add("Id");
//            dataTable.Columns.Add("LIme");
//            dataTable.Columns.Add("Prezime");
//            dataTable.Columns.Add("Email");
//            dataTable.Columns.Add("BrojTelefona");

//            dataTable.Columns.Add(Constants.ConcatenatedField, typeof (string), "Id + ' : ' +LIme");

//            List<Lekar> objList;
//            using (var session = DataLayer.GetSession())
//                objList = session.QueryOver<Lekar>().Where(x => x.Deleted == false)?.List<Lekar>() as List<Lekar>;

//            if (objList == null) return dataTable;
//            objList.ForEach(
//                x => dataTable.Rows.Add(x.Id, x.Ime.LIme, x.Ime.Prezime, x.Kontakt.Email, x.Kontakt.BrojTelefona));

//            return dataTable;
//        }

//        public static DataTable GetZaposleniDataTable()
//        {
//            var dataTable = new DataTable("Zaposleni");

//            dataTable.Columns.Add("Id");
//            dataTable.Columns.Add("LIme");
//            dataTable.Columns.Add("Prezime");
//            dataTable.Columns.Add("Email");
//            dataTable.Columns.Add("Broj Telefona");
//            dataTable.Columns.Add("Farmaceut");

//            dataTable.Columns.Add(Constants.ConcatenatedField, typeof (string), "Id + ' : ' +LIme");

//            List<Zaposleni> objList;
//            using (var session = DataLayer.GetSession())
//                objList =
//                    session.QueryOver<Zaposleni>().Where(x => x.Deleted == false)?.List<Zaposleni>() as List<Zaposleni>;

//            if (objList == null) return dataTable;
//            objList.ForEach(
//                x =>
//                    dataTable.Rows.Add(x.Id, x.Ime.LIme, x.Ime.Prezime, x.Kontakt.Email, x.Kontakt.BrojTelefona,
//                        x.FFarmaceut ? "Da" : "Ne"));

//            return dataTable;
//        }

//        public static DataTable GetFarmaceutDataTable()
//        {
//            var dataTable = new DataTable("Zaposleni");

//            dataTable.Columns.Add("Id");
//            dataTable.Columns.Add("LIme");
//            dataTable.Columns.Add("Prezime");
//            dataTable.Columns.Add("Email");
//            dataTable.Columns.Add("Broj Telefona");
//            dataTable.Columns.Add("Farmaceut");

//            dataTable.Columns.Add(Constants.ConcatenatedField, typeof (string), "Id + ' : ' +LIme");

//            List<Zaposleni> objList;
//            using (var session = DataLayer.GetSession())
//                objList =
//                    session.QueryOver<Zaposleni>().Where(x => x.Deleted == false && x.FFarmaceut)?.List<Zaposleni>() as
//                        List<Zaposleni>;


//            if (objList == null) return dataTable;
//            objList.ForEach(
//                x => dataTable.Rows.Add(x.Id, x.Ime.LIme, x.Ime.Prezime, x.Kontakt.Email, x.Kontakt.BrojTelefona));

//            return dataTable;
//        }

//        #endregion

//        #endregion

//        #region CRUD

//        public static bool Add(params object[] objects)
//        {
//            try
//            {
//                using (var session = DataLayer.GetSession())
//                {
//                    objects.ForEach(o => session.SaveOrUpdate(o));
//                    session.BeginTransaction().Commit();
//                }
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//                return false;
//            }
//            return true;
//        }

//        public static IEnumerable<T> GetAll<T>(ISession session = null)
//        {
//            using (session = session ?? DataLayer.GetSession())
//                return session.Query<T>().Select(p => p);
//        }

//        public static IList<T> GetAllList<T>(ISession session)
//        {
//            return session.Query<T>().Select(p => p).ToList();
//        }

//        public static T Get<T>(int id)
//        {
//            using (var session = DataLayer.GetSession())
//                return session.Get<T>(id);
//        }

//        public static void Remove<T>(int id)
//        {
//            using (var session = DataLayer.GetSession())
//            {
//                try
//                {
//                    var el = session.Get<T>(id) as Entity;
//                    if (el == null) return;

//                    el.Deleted = true;
//                    session.Update(session.Get<T>(id));
//                    session.BeginTransaction().Commit();
//                }
//                catch (Exception e)
//                {
//                    Console.WriteLine(e);
//                }
//            }
//        }

//        public static void Update(int id, Entity obj)
//        {
//            using (var session = DataLayer.GetSession())
//            {
//                try
//                {
//                    session.Update(obj);
//                    session.BeginTransaction().Commit();
//                }
//                catch (Exception e)
//                {
//                    Console.WriteLine(e);
//                }
//            }
//        }

//        public static List<object> GetAllObjects(Type type)
//        {
//            using (var session = DataLayer.GetSession())
//            {
//                try
//                {
//                    var list = session.CreateCriteria(type).List<object>();
//                    return (List<object>) list;
//                }
//                catch (Exception e)
//                {
//                    Console.WriteLine(e);
//                    return null;
//                }
//            }
//        }

//        public static void DeleteAllData()
//        {
//            try
//            {
//                using (var session = DataLayer.GetSession())
//                {
//                    using (var transaction = session.BeginTransaction())
//                    {
//                        session.CreateSQLQuery("DELETE FROM LEK_PROIZVODJAC").ExecuteUpdate();
//                        session.CreateSQLQuery("DELETE FROM LEK_BOLEST").ExecuteUpdate();
//                        session.CreateSQLQuery("DELETE FROM PRODAJNO_MESTO_LEK").ExecuteUpdate();

//                        session.CreateSQLQuery("DELETE FROM KONTRAINDIKACIJA").ExecuteUpdate();

//                        session.CreateSQLQuery("DELETE FROM LEK_PROIZVODJAC").ExecuteUpdate();


//                        session.CreateSQLQuery("DELETE FROM RECEPT").ExecuteUpdate();

//                        session.CreateSQLQuery("DELETE FROM ZAPOSLENI").ExecuteUpdate();
//                        session.CreateSQLQuery("DELETE FROM KUPAC").ExecuteUpdate();
//                        session.CreateSQLQuery("DELETE FROM LEKAR").ExecuteUpdate();
//                        session.CreateSQLQuery("DELETE FROM OSOBA").ExecuteUpdate();
//                        session.CreateSQLQuery("DELETE FROM PRODAJNO_MESTO").ExecuteUpdate();

//                        session.CreateSQLQuery("DELETE FROM LEK").ExecuteUpdate();
//                        session.CreateSQLQuery("DELETE FROM PROIZVODJAC").ExecuteUpdate();
//                        session.CreateSQLQuery("DELETE FROM BOLEST").ExecuteUpdate();
//                        session.CreateSQLQuery("DELETE FROM PAKOVANJE").ExecuteUpdate();
//                        session.CreateSQLQuery("DELETE FROM APOTEKARSKA_USTANOVA").ExecuteUpdate();


//                        //session.CreateSQLQuery("DELETE FROM OSOBA").ExecuteUpdate();

//                        transaction.Commit();
//                    }
//                }
//            }
//            catch (Exception exception)
//            {
//                Console.WriteLine(exception);
//            }
//        }

//        #endregion

//        #region Getters All IEnumerable

//        #region Lek

//        public static IEnumerable<Analgetik> GetAllAnalgetik(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<Analgetik>().Where(x => x.Deleted == false);
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<Analgetik>().Where(x => x.Deleted == false);
//            }
//        }

//        public static IEnumerable<Antibiotik> GetAllAntibiotik(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<Antibiotik>().Where(x => x.Deleted == false);
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<Antibiotik>().Where(x => x.Deleted == false);
//            }
//        }

//        public static IEnumerable<Antipiretik> GetAllAntipiretik(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<Antipiretik>().Where(x => x.Deleted == false);
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<Antipiretik>().Where(x => x.Deleted == false);
//            }
//        }

//        public static IEnumerable<Diuretik> GetAllDiuretik(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<Diuretik>().Where(x => x.Deleted == false);
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<Diuretik>().Where(x => x.Deleted == false);
//            }
//        }

//        public static IEnumerable<Lek> GetAllLek(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<Lek>().Where(x => x.Deleted == false);
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<Lek>().Where(x => x.Deleted == false);
//            }
//        }

//        #endregion

//        public static IEnumerable<ApotekarskaUstanova> GetAllApotekarskaUstanova(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<ApotekarskaUstanova>().Where(x => x.Deleted == false);
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<ApotekarskaUstanova>().Where(x => x.Deleted == false);
//            }
//        }

//        public static IEnumerable<Bolest> GetAllBolest(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<Bolest>().Where(x => x.Deleted == false);
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<Bolest>().Where(x => x.Deleted == false);
//            }
//        }

//        public static IEnumerable<Kontraindikacija> GetAllKontraindikacija(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<Kontraindikacija>().Where(x => x.Deleted == false);
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<Kontraindikacija>().Where(x => x.Deleted == false);
//            }
//        }

//        #region Osoba

//        public static IEnumerable<Kupac> GetAllKupac(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<Kupac>().Where(x => x.Deleted == false);
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<Kupac>().Where(x => x.Deleted == false);
//            }
//        }

//        public static IEnumerable<Osoba> GetAllOsoba(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<Osoba>().Where(x => x.Deleted == false);
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<Osoba>().Where(x => x.Deleted == false);
//            }
//        }

//        public static IEnumerable<Zaposleni> GetAllZaposleni(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<Zaposleni>().Where(x => x.Deleted == false);
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<Zaposleni>().Where(x => x.Deleted == false);
//            }
//        }

//        public static IEnumerable<Zaposleni> GetAllFarmaceut(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<Zaposleni>().Where(x => x.Deleted == false);
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<Zaposleni>().Where(x => x.Deleted == false && x.FFarmaceut);
//            }
//        }

//        public static IEnumerable<Lekar> GetAllLekar(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<Lekar>().Where(x => x.Deleted == false);
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<Lekar>().Where(x => x.Deleted == false);
//            }
//        }

//        #endregion

//        #region Pakovanje

//        public static IEnumerable<Pakovanje> GetAllPakovanje(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<Pakovanje>().Where(x => x.Deleted == false);
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<Pakovanje>().Where(x => x.Deleted == false);
//            }
//        }

//        public static IEnumerable<Sirup> GetAllSirup(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<Sirup>().Where(x => x.Deleted == false);
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<Sirup>().Where(x => x.Deleted == false);
//            }
//        }

//        public static IEnumerable<Prasak> GetAllPrasak(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<Prasak>().Where(x => x.Deleted == false);
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<Prasak>().Where(x => x.Deleted == false);
//            }
//        }

//        public static IEnumerable<Injekcija> GetAllInjekcija(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<Injekcija>().Where(x => x.Deleted == false);
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<Injekcija>().Where(x => x.Deleted == false);
//            }
//        }

//        public static IEnumerable<Tableta> GetAllTableta(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<Tableta>().Where(x => x.Deleted == false);
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<Tableta>().Where(x => x.Deleted == false);
//            }
//        }

//        #endregion

//        public static IEnumerable<ProdajnoMesto> GetAllProdajnoMesto(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<ProdajnoMesto>().Where(x => x.Deleted == false);
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<ProdajnoMesto>().Where(x => x.Deleted == false);
//            }
//        }

//        public static IEnumerable<Proizvodjac> GetAllProizvodjac(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<Proizvodjac>().Where(x => x.Deleted == false);
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<Proizvodjac>().Where(x => x.Deleted == false);
//            }
//        }

//        public static IEnumerable<Recept> GetAllRecept(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<Recept>().Where(x => x.Deleted == false);
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<Recept>().Where(x => x.Deleted == false);
//            }
//        }

//        #endregion

//        #region Getters All IList

//        #region Lek

//        public static IList<Analgetik> GetAllAnalgetikList(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<Analgetik>().Where(x => x.Deleted == false).ToList();
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<Analgetik>().Where(x => x.Deleted == false).ToList();
//            }
//        }

//        public static IList<Antibiotik> GetAllAntibiotikList(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<Antibiotik>().Where(x => x.Deleted == false).ToList();
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<Antibiotik>().Where(x => x.Deleted == false).ToList();
//            }
//        }

//        public static IList<Antipiretik> GetAllAntipiretikList(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<Antipiretik>().Where(x => x.Deleted == false).ToList();
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<Antipiretik>().Where(x => x.Deleted == false).ToList();
//            }
//        }

//        public static IList<Diuretik> GetAllDiuretikList(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<Diuretik>().Where(x => x.Deleted == false).ToList();
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<Diuretik>().Where(x => x.Deleted == false).ToList();
//            }
//        }

//        public static IList<Lek> GetAllLekList(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<Lek>().Where(x => x.Deleted == false).ToList();
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<Lek>().Where(x => x.Deleted == false).ToList();
//            }
//        }

//        #endregion

//        public static IList<ApotekarskaUstanova> GetAllApotekarskaUstanovaList(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<ApotekarskaUstanova>().Where(x => x.Deleted == false).ToList();
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<ApotekarskaUstanova>().Where(x => x.Deleted == false).ToList();
//            }
//        }

//        public static IList<Bolest> GetAllBolestList(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<Bolest>().Where(x => x.Deleted == false).ToList();
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<Bolest>().Where(x => x.Deleted == false).ToList();
//            }
//        }

//        public static IList<Kontraindikacija> GetAllKontraindikacijaList(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<Kontraindikacija>().Where(x => x.Deleted == false).ToList();
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<Kontraindikacija>().Where(x => x.Deleted == false).ToList();
//            }
//        }

//        #region Osoba

//        public static IList<Kupac> GetAllKupacList(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<Kupac>().Where(x => x.Deleted == false).ToList();
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<Kupac>().Where(x => x.Deleted == false).ToList();
//            }
//        }

//        public static IList<Osoba> GetAllOsobaList(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<Osoba>().Where(x => x.Deleted == false).ToList();
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<Osoba>().Where(x => x.Deleted == false).ToList();
//            }
//        }

//        public static IList<Zaposleni> GetAllZaposleniList(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<Zaposleni>().Where(x => x.Deleted == false).ToList();
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<Zaposleni>().Where(x => x.Deleted == false).ToList();
//            }
//        }

//        public static IList<Zaposleni> GetAllFarmaceutList(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<Zaposleni>().Where(x => x.Deleted == false).ToList();
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<Zaposleni>().Where(x => x.Deleted == false && x.FFarmaceut).ToList();
//            }
//        }

//        public static IList<Lekar> GetAllLekarList(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<Lekar>().Where(x => x.Deleted == false).ToList();
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<Lekar>().Where(x => x.Deleted == false).ToList();
//            }
//        }

//        #endregion

//        #region Pakovanje

//        public static IList<Pakovanje> GetAllPakovanjeList(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<Pakovanje>().Where(x => x.Deleted == false).ToList();
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<Pakovanje>().Where(x => x.Deleted == false).ToList();
//            }
//        }

//        public static IList<Sirup> GetAllSirupList(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<Sirup>().Where(x => x.Deleted == false).ToList();
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<Sirup>().Where(x => x.Deleted == false).ToList();
//            }
//        }

//        public static IList<Prasak> GetAllPrasakList(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<Prasak>().Where(x => x.Deleted == false).ToList();
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<Prasak>().Where(x => x.Deleted == false).ToList();
//            }
//        }

//        public static IList<Injekcija> GetAllInjekcijaList(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<Injekcija>().Where(x => x.Deleted == false).ToList();
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<Injekcija>().Where(x => x.Deleted == false).ToList();
//            }
//        }

//        public static IList<Tableta> GetAllTabletaList(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<Tableta>().Where(x => x.Deleted == false).ToList();
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<Tableta>().Where(x => x.Deleted == false).ToList();
//            }
//        }

//        #endregion

//        public static IList<ProdajnoMesto> GetAllProdajnoMestoList(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<ProdajnoMesto>().Where(x => x.Deleted == false).ToList();
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<ProdajnoMesto>().Where(x => x.Deleted == false).ToList();
//            }
//        }

//        public static IList<Proizvodjac> GetAllProizvodjacList(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<Proizvodjac>().Where(x => x.Deleted == false).ToList();
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<Proizvodjac>().Where(x => x.Deleted == false).ToList();
//            }
//        }

//        public static IList<Recept> GetAllReceptList(ISession session = null)
//        {
//            if (session != null)
//            {
//                return session.Query<Recept>().Where(x => x.Deleted == false).ToList();
//            }
//            using (session = DataLayer.GetSession())
//            {
//                return session.Query<Recept>().Where(x => x.Deleted == false).ToList();
//            }
//        }

//        #endregion

//        #region Getters

//        #region Lek

//        public static Analgetik GetAnalgetik(int id)
//        {
//            using (var session = DataLayer.GetSession())
//            {
//                var obj = session.Get<Analgetik>(id);

//                if (obj == null) return null;

//                obj.BolestList = GetAllBolestList(session);
//                obj.KontraindikacijaList = GetAllKontraindikacijaList(session);
//                obj.ProdajnoMestoList = GetAllProdajnoMestoList(session);
//                obj.ReceptList = GetAllReceptList(session);
//                obj.ProizvodjacList = GetAllProizvodjacList(session);
//                return obj;
//            }
//        }

//        public static Antibiotik GetAntibiotik(int id)
//        {
//            using (var session = DataLayer.GetSession())
//            {
//                var obj = session.Get<Antibiotik>(id);

//                if (obj == null) return null;

//                obj.BolestList = GetAllBolestList(session);
//                obj.KontraindikacijaList = GetAllKontraindikacijaList(session);
//                obj.ProdajnoMestoList = GetAllProdajnoMestoList(session);
//                obj.ReceptList = GetAllReceptList(session);
//                obj.ProizvodjacList = GetAllProizvodjacList(session);
//                return obj;
//            }
//        }

//        public static Antipiretik GetAntipiretik(int id)
//        {
//            using (var session = DataLayer.GetSession())
//            {
//                var obj = session.Get<Antipiretik>(id);

//                if (obj == null) return null;

//                obj.BolestList = GetAllBolestList(session);
//                obj.KontraindikacijaList = GetAllKontraindikacijaList(session);
//                obj.ProdajnoMestoList = GetAllProdajnoMestoList(session);
//                obj.ReceptList = GetAllReceptList(session);
//                obj.ProizvodjacList = GetAllProizvodjacList(session);
//                return obj;
//            }
//        }

//        public static Diuretik GetDiuretik(int id)
//        {
//            using (var session = DataLayer.GetSession())
//            {
//                var obj = session.Get<Diuretik>(id);

//                if (obj == null) return null;

//                obj.BolestList = GetAllBolestList(session);
//                obj.KontraindikacijaList = GetAllKontraindikacijaList(session);
//                obj.ProdajnoMestoList = GetAllProdajnoMestoList(session);
//                obj.ReceptList = GetAllReceptList(session);
//                obj.ProizvodjacList = GetAllProizvodjacList(session);
//                return obj;
//            }
//        }

//        public static Lek GetLek(int id)
//        {
//            using (var session = DataLayer.GetSession())
//            {
//                var obj = session.Get<Lek>(id);

//                if (obj == null) return null;

//                obj.BolestList = GetAllBolestList(session);
//                obj.KontraindikacijaList = GetAllKontraindikacijaList(session);
//                obj.ProdajnoMestoList = GetAllProdajnoMestoList(session);
//                obj.ReceptList = GetAllReceptList(session);
//                obj.ProizvodjacList = GetAllProizvodjacList(session);
//                return obj;
//            }
//        }

//        #endregion

//        public static ApotekarskaUstanova GetApotekarskaUstanova(int id)
//        {
//            using (var session = DataLayer.GetSession())
//            {
//                var obj = session.Get<ApotekarskaUstanova>(id);

//                if (obj == null) return null;

//                obj.ProdajnoMestoList = GetAllProdajnoMestoList(session);
//                return obj;
//            }
//        }

//        public static Bolest GetBolest(int id)
//        {
//            using (var session = DataLayer.GetSession())
//            {
//                var obj = session.Get<Bolest>(id);

//                if (obj == null) return null;

//                obj.KontraindikacijaList = GetAllKontraindikacijaList(session);
//                obj.LekList = GetAllLekList(session);
//                return obj;
//            }
//        }

//        public static Kontraindikacija GetKontraindikacija(int id)
//        {
//            using (var session = DataLayer.GetSession())
//            {
//                var obj = session.Get<Kontraindikacija>(id);

//                return obj;
//            }
//        }

//        #region Osoba

//        public static Osoba GetOsoba(int id)
//        {
//            using (var session = DataLayer.GetSession())
//            {
//                var obj = session.Get<Osoba>(id);

//                return obj;
//            }
//        }

//        public static Kupac GetKupac(int id)
//        {
//            using (var session = DataLayer.GetSession())
//            {
//                var obj = session.Get<Kupac>(id);

//                if (obj == null) return null;

//                obj.ReceptList = GetAllReceptList(session);
//                return obj;
//            }
//        }

//        public static Zaposleni GetZaposleni(int id)
//        {
//            using (var session = DataLayer.GetSession())
//            {
//                var obj = session.Get<Zaposleni>(id);

//                if (obj == null) return null;

//                obj.ReceptList = GetAllReceptList(session);
//                return obj;
//            }
//        }

//        public static Lekar GetLekar(int id)
//        {
//            using (var session = DataLayer.GetSession())
//            {
//                var obj = session.Get<Lekar>(id);

//                if (obj == null) return null;

//                obj.ReceptList = GetAllReceptList(session);
//                return obj;
//            }
//        }

//        #endregion

//        public static Pakovanje GetPakovanje(int id)
//        {
//            using (var session = DataLayer.GetSession())
//            {
//                var obj = session.Get<Pakovanje>(id);

//                if (obj == null) return null;

//                obj.LekList = GetAllLekList(session);
//                obj.KontraindikacijaList = GetAllKontraindikacijaList(session);
//                return obj;
//            }
//        }

//        public static ProdajnoMesto GetProdajnoMesto(int id)
//        {
//            using (var session = DataLayer.GetSession())
//            {
//                var obj = session.Get<ProdajnoMesto>(id);

//                if (obj == null) return null;

//                obj.ReceptList = GetAllReceptList(session);
//                return obj;
//            }
//        }

//        public static Proizvodjac GetProizvodjac(int id)
//        {
//            using (var session = DataLayer.GetSession())
//            {
//                var obj = session.Get<Proizvodjac>(id);

//                if (obj == null) return null;

//                obj.LekList = GetAllLekList(session);
//                return obj;
//            }
//        }

//        public static Recept GetRecept(int id)
//        {
//            using (var session = DataLayer.GetSession())
//            {
//                var obj = session.Get<Recept>(id);

//                return obj;
//            }
//        }

//        public static ProdajnoMestoLek GetProdajnoMestoLek(Lek lek, ProdajnoMesto prodajnoMesto)
//        {
//            using (var session = DataLayer.GetSession())
//            {
//                var obj =
//                    session.Query<ProdajnoMestoLek>()
//                        .Where(x => x.ProdajnoMesto == prodajnoMesto && x.Lek == lek)
//                        .ToArray();

//                return obj.First();
//            }
//        }

//        #endregion
//    }
//}