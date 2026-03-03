namespace Domain.Wheel;

public class WheelList
{
    public Guid Guid { get; set; } = Guid.NewGuid();
    public bool IsDeleted { get; set; }
    public required string Name { get; set; }
    public virtual ICollection<WheelItem>? Items { get; set; }
}
