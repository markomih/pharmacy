using Core.Entities.Component;

namespace Core.Entities
{
    public abstract class Osoba : Entity
    {
        public virtual Ime Ime { get; set; }
        public virtual Kontakt Kontakt { get; set; }
    }
}