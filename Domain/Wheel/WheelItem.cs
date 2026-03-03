namespace Domain.Wheel;

public class WheelItem
{
    public Guid Guid { get; set; } = Guid.NewGuid();
    public Guid ListGuid { get; set; }
    public virtual WheelList? List { get; set; }
    public required string Title { get; set; }
    public bool IsInactive { get; set; }
}
