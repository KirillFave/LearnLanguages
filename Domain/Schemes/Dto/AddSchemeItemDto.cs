namespace Domain.Schemes.Dto;

public class AddSchemeItemDto
{
    public required Guid SchemeGuid { get; set; }
    public required string Title { get; set; }
    public required string Translation { get; set; }
    public required string Text { get; set; }
    public required int Column { get; set; }
    public required int Row { get; set; }
    public required string Color {  get; set; }
}
