namespace Core.Entities
{
    public class Kontraindikacija : Entity
    {
        public virtual Lek Lek { get; set; }
        public virtual Pakovanje Pakovanje { get; set; }

        public virtual Bolest Bolest { get; set; }

        public virtual string Opis { get; set; }
    }
}