namespace Core.Entities
{
    public class ProdajnoMestoLek
    {
        public virtual Lek Lek { get; set; }
        public virtual ProdajnoMesto ProdajnoMesto { get; set; }

        public virtual int Kolicina { get; set; }

        #region Fluent NHibernate Composite Key Overrides

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var compare = obj as ProdajnoMestoLek;

            if (compare == null)
                return false;

            return Lek.Id == compare.Lek.Id &&
                   ProdajnoMesto.Id == compare.ProdajnoMesto.Id;
        }

        public override int GetHashCode()
        {
            return (Lek.Id + "|" + ProdajnoMesto.Id).GetHashCode();
        }

        #endregion
    }
}