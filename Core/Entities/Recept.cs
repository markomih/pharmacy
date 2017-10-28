using System;

namespace Core.Entities
{
    public class Recept : Entity
    {
        public virtual ProdajnoMesto ProdajnoMesto { get; set; }
        public virtual Zaposleni Farmaceut { get; set; }
        public virtual Lekar Lekar { get; set; }
        public virtual Kupac Kupac { get; set; }
        public virtual Lek Lek { get; set; }

        public virtual DateTime DatumRealizacije { get; set; }
        public virtual DateTime DatumVazenja { get; set; }
        public virtual int KolicinaLeka { get; set; }
        public virtual int Doza { get; set; }
    }
}