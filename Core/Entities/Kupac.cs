using System.Collections.Generic;

namespace Core.Entities
{
    public class Kupac : Osoba
    {
        public Kupac()
        {
            ReceptList = new List<Recept>();
        }

        public virtual double Pazar { get; set; }

        public virtual IList<Recept> ReceptList { get; set; }
        //    recepts.ForEach(x => ReceptList.Add(x));
        //{

        //public virtual void AddRecept(params Recept[] recepts)
        //}
    }
}