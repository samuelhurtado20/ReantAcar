namespace WebAPi.Data.Entities;

public class AuditLog : BaseEntity
{
    public string UserId { get; set; } = null!;

    public string EntityName { get; set; } = null!;

    public string Action { get; set; } = null!;

    public DateTime Timestamp { get; set; }

    public string Changes { get; set; } = null!;
}