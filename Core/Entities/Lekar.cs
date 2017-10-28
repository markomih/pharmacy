using System.Collections.Generic;

namespace Core.Entities
{
    public class Lekar : Osoba
    {
        public Lekar()
        {
            ReceptList = new List<Recept>();
        }

        public virtual IList<Recept> ReceptList { get; set; }

        //public virtual void AddRecept(params Recept[] recepts)
        //{
        //    recepts.ForEach(x => ReceptList.Add(x));
        //}
    }
}