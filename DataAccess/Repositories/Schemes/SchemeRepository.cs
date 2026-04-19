using Domain.Schemes;

namespace DataAccess.Repositories.Wheel;

public class SchemeRepository(DatabaseContext databaseContext)
{
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
