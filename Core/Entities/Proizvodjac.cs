using System.Collections.Generic;

namespace Core.Entities
{
    public class Proizvodjac : Entity
    {
        public Proizvodjac()
        {
            LekList = new List<Lek>();
        }

        public virtual string Naziv { get; set; }

        public virtual IList<Lek> LekList { get; set; }

    }
}