using Domain.Wheel;

namespace Domain.Schemes;

public class SchemeItem
{
    public required Guid Guid { get; set; }
    public required string Title { get; set; }
    public required string Text { get; set; }
    public required string Color { get; set; }
    public required int Column {  get; set; }
    public required int Row { get; set; }

    public Guid SchemeGuid { get; set; }
    public virtual Scheme? Scheme { get; set; }
}