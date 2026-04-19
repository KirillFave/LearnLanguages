namespace Domain.Schemes;

public class Item
{
    public required Guid Guid { get; set; }
    public required string Title { get; set; }
    public required string Text { get; set; }
    public required string Color { get; set; }
    public required int Column {  get; set; }
    public required int Row { get; set; }
}