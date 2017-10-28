using System;
using System.Collections.Generic;
using Core.Entities.Component;

namespace Core.Entities
{
    public class Zaposleni : Osoba
    {
        public Zaposleni()
        {
            FFarmaceut = false;
            ReceptList = new List<Recept>();
        }

        public virtual DateTime? DatumRodjenja { get; set; }
        public virtual Lokacija Lokacija { get; set; }
        public virtual string Jmbg { get; set; }
        public virtual DateTime DatumZaposljavanja { get; set; }
        public virtual bool FFarmaceut { get; set; }
        public virtual DateTime? DatumObnoveLicence { get; set; }
        public virtual DateTime? DatumDiplomiranja { get; set; }

        public virtual ProdajnoMesto ProdajnoMesto { get; set; }
        public virtual IList<Recept> ReceptList { get; set; }

        //public virtual void AddRecept(params Recept[] recepts)
        //{
        //    recepts.ForEach(x => ReceptList.Add(x));
        //}
    }
}