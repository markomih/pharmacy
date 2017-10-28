namespace Core.Entities
{
    public class LekProizvodjac
    {
        public virtual Lek Lek { get; set; }
        public virtual Proizvodjac Proizvodjac { get; set; }
        public virtual string KomercialniNacivLeka { get; set; }

        #region Fluent NHibernate Composite Key Overrides

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var compare = obj as LekProizvodjac;

            if (compare == null)
                return false;

            return Lek.Id == compare.Lek.Id &&
                   Proizvodjac.Id == compare.Proizvodjac.Id;
        }

        public override int GetHashCode()
        {
            return (Lek.Id + "|" + Proizvodjac.Id).GetHashCode();
        }

        #endregion
    }
}