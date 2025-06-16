namespace CleanArchMvc.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
        DateTime CreatedDate { get; set; }
    }
}
