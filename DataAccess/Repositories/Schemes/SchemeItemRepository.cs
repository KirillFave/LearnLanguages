using Domain.Schemes;
using Domain.Schemes.Dto;

namespace DataAccess.Repositories.Wheel;

public class SchemeItemRepository(DatabaseContext databaseContext)
{
    public SchemeItem Add(AddSchemeItemDto dto)
    {
        SchemeItem schemeItem = new()
        {
            Guid = Guid.NewGuid(),
            SchemeGuid = dto.SchemeGuid,
            Title = dto.Title,
            Translation = dto.Translation,
            Text = dto.Text,
            Row = dto.Row,
            Column = dto.Column,
            Color = dto.Color
        };

        databaseContext.SchemeItems.Add(schemeItem);
        databaseContext.SaveChanges();
        return schemeItem;
    }
}