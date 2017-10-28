using System.Collections.Generic;
using Core.Entities.Component;

namespace Core.Entities
{
    public abstract class Lek : Entity
    {
        protected Lek()
        {
            NaRecept = true;
            BolestList = new List<Bolest>();
            ProizvodjacList = new List<Proizvodjac>();
            KontraindikacijaList = new List<Kontraindikacija>();
            ProdajnoMestoList = new List<ProdajnoMesto>();
            ReceptList = new List<Recept>();
        }

        public virtual string Dejstvo { get; set; }
        public virtual string NezeljeniEfekti { get; set; }
        public virtual bool NaRecept { get; set; }
        public virtual double ProcenatParticipacije { get; set; }
        public virtual double Cena { get; set; }
        public virtual NazivLeka NazivLeka { get; set; }
        public virtual Enum.NacinDoziranja NacinDoziranja { get; set; }
        public virtual Enum.TipLeka TipLeka { get; protected set; }

        public virtual Pakovanje Pakovanje { get; set; }
        public virtual IList<Proizvodjac> ProizvodjacList { get; set; }
        public virtual IList<ProdajnoMesto> ProdajnoMestoList { get; set; }
        public virtual IList<Kontraindikacija> KontraindikacijaList { get; set; }
        public virtual IList<Recept> ReceptList { get; set; }
        
        #region

        public virtual IList<Bolest> BolestList { get; set; }
        //public virtual IList<LekBolest> LekBolestList { get; set; }

        #endregion
        
    }
}