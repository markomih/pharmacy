using System.Collections.Generic;
using Core.Entities.Component;

namespace Core.Entities
{
    public class ApotekarskaUstanova : Entity
    {
        public ApotekarskaUstanova()
        {
            ProdajnoMestoList = new List<ProdajnoMesto>();
        }

        public virtual string Naziv { get; set; }

        public virtual Kontakt Kontakt { get; set; }

        public virtual string Sajt { get; set; }

        public virtual IList<ProdajnoMesto> ProdajnoMestoList { get; set; }


        //public virtual void AddProdajnoMesto(params ProdajnoMesto[] prodajnoMestos)
        //{
        //    prodajnoMestos.ForEach(x => ProdajnoMestoList.Add(x));
        //}
    }
}