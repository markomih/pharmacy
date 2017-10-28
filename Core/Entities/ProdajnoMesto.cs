using System.Collections.Generic;
using Core.Entities.Component;

namespace Core.Entities
{
    public class ProdajnoMesto : Entity
    {
        public ProdajnoMesto()
        {
            ZaposleniList = new List<Zaposleni>();
            LekList = new List<Lek>();
            ReceptList = new List<Recept>();
        }

        public virtual string Naziv { get; set; }
        public virtual Lokacija Lokacija { get; set; }

        public virtual ApotekarskaUstanova ApotekarskaUstanova { get; set; }

        public virtual IList<Zaposleni> ZaposleniList { get; set; }
        public virtual IList<Lek> LekList { get; set; }

        public virtual IList<Recept> ReceptList { get; set; }


        //public virtual void AddRecept(params Recept[] recepts)
        //{
        //    recepts.ForEach(x => ReceptList.Add(x));
        //}
        //public virtual void AddZaposleni(params Zaposleni[] zaposlenis)
        //{
        //    zaposlenis.ForEach(x => ZaposleniList.Add(x));
        //}
        //public virtual void AddLek(params Lek[] leks)
        //{
        //    leks.ForEach(x => LekList.Add(x));
        //}
    }
}