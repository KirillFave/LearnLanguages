namespace Domain.Schemes;

public class Scheme
{
    public required Guid Guid { get; set; }
    public required string Name { get; set; }

    public virtual ICollection<SchemeItem> Items { get; set; } = [];
}
