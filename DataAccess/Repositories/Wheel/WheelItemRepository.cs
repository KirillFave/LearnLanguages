using Domain.Wheel;

namespace DataAccess.Repositories.Wheel;

public class WheelItemRepository(DatabaseContext databaseContext)
{
    public WheelItem GetById(Guid guid)
    {
        return databaseContext.WheelItems.Find(guid) ?? throw new ArgumentException();
    }

    public void Enable(Guid guid)
    {
        WheelItem item = GetById(guid);

        if (!item.IsInactive)
        {
            return;
        }

        item.IsInactive = false;
        databaseContext.SaveChanges();
    }

    public void Disable(Guid guid)
    {
        WheelItem item = GetById(guid);

        if (item.IsInactive)
        {
            return;
        }

        item.IsInactive = true;
        databaseContext.SaveChanges();
    }
}