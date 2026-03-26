using Domain.Wheel;

namespace DataAccess.Repositories.Wheel;

public class WheelItemRepository(DatabaseContext databaseContext)
{
    public WheelItem GetById(Guid guid)
    {
        return databaseContext.WheelItems.Find(guid) ?? throw new ArgumentException();
    }

    public WheelItem Edit(Guid guid, string title, string definition)
    {
        WheelItem item = GetById(guid);

        if (item.Title.Equals(title) && item.Definition.Equals(definition))
        {
            return item;
        }

        item.Title = title;
        item.Definition = definition;
        databaseContext.SaveChanges();
        return item;
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