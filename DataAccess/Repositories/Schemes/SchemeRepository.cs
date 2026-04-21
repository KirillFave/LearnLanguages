using Domain.Schemes;

namespace DataAccess.Repositories.Wheel;

public class SchemeRepository(DatabaseContext databaseContext)
{
    public IEnumerable<Scheme> GetAll()
    {
        return databaseContext.Schemes.AsEnumerable();
    }

    public async Task<Scheme?> GetNullableByIdAsync(Guid guid)
    {
        return await databaseContext.Schemes.FindAsync(guid);
    }

    public async Task<Scheme> GetByIdAsync(Guid guid)
    {
        Scheme? scheme = await GetNullableByIdAsync(guid) ??
            throw new ArgumentException(
                $"Сущность {nameof(Scheme)} не найдена по {nameof(guid)} = {guid}.",
                nameof(guid));

        return scheme;
    }

    public async Task<Scheme> Add(string name)
    {
        Scheme scheme = new()
        {
            Guid = Guid.NewGuid(),
            Name = name
        };

        await databaseContext.Schemes.AddAsync(scheme);
        await databaseContext.SaveChangesAsync();
        return scheme;
    }
}
