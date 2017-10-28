namespace Core.Entities
{
    public abstract class Entity : IEntity
    {
        protected Entity()
        {
            Deleted = false;
        }

        public virtual bool Deleted { get; set; }
        public virtual int Id { get; protected set; }
    }
}