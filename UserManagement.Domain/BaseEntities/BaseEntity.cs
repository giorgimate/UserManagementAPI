namespace UserManagement.Domain.BaseEntities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public Status Status { get; set; } = Status.Active;
    }
}
