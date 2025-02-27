namespace WebAPi.Interfaces.Interceptors;

public interface ISoftDelete
{
    public bool IsDeleted { get; set; }

    public int? DeletedBy { get; set; }

    public DateTimeOffset? DeletedAt { get; set; }
}