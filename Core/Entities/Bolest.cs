using System.Collections.Generic;
using Core.Entities.Component;

namespace Core.Entities
{
    public class Bolest : Entity
    {
        public Bolest()
        {
            LekList = new List<Lek>();
            KontraindikacijaList = new List<Kontraindikacija>();
        }

        public virtual NazivBolesti NazivBolesti { get; set; }
        public virtual string Opis { get; set; }
        public virtual IList<Kontraindikacija> KontraindikacijaList { get; set; }

        #region

        public virtual IList<Lek> LekList { get; set; }
        //public virtual IList<LekBolest> LekBolestList { get; set; }

        #endregion
    }
}