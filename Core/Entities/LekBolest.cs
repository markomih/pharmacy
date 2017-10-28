namespace Core.Entities
{
    public class LekBolest
    {
        public virtual Lek Lek { get; set; }
        public virtual Bolest Bolest { get; set; }

        #region Fluent NHibernate Composite Key Overrides

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var compare = obj as LekBolest;

            if (compare == null)
                return false;

            return Lek.Id == compare.Lek.Id &&
                   Bolest.Id == compare.Bolest.Id;
        }

        public override int GetHashCode()
        {
            return (Lek.Id + "|" + Bolest.Id).GetHashCode();
        }

        #endregion
    }
}