using System.Collections.Generic;

namespace Core.Entities
{
    public abstract class Pakovanje : Entity
    {
        protected Pakovanje()
        {
            LekList = new List<Lek>();
            KontraindikacijaList = new List<Kontraindikacija>();
        }

        public virtual string Sastav { get; set; }
        public virtual int Kolicina { get; set; }
        public virtual Enum.TipPakovanja Tip { get; protected set; }

        public virtual IList<Lek> LekList { get; set; }
        public virtual IList<Kontraindikacija> KontraindikacijaList { get; set; }

        //public virtual void AddLek(params Lek[] leks)
        //{
        //    leks.ForEach(x => LekList.Add(x));
        //}

        //public virtual void AddKontraindikacija(params Kontraindikacija[] kontraindikacijas)
        //{
        //    kontraindikacijas.ForEach(x => KontraindikacijaList.Add(x));
        //}
    }
}