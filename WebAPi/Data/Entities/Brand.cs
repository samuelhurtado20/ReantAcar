using WebAPi.Interfaces.Interceptors;

namespace WebAPi.Data.Entities;

public class Brand : BaseEntity, ISoftDelete
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Image { get; set; } = string.Empty;

    public bool IsDeleted { get; set; }

    public int? DeletedBy { get; set; }

    public DateTimeOffset? DeletedAt { get; set; }
}