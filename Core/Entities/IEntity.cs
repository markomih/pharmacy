namespace Core.Entities
{
    public interface IEntity
    {
        bool Deleted { get; set; }
        int Id { get; }
    }
}