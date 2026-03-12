using Domain.Wheel;

namespace DataAccess.Repositories.Wheel;

public class WheelListRepository(DatabaseContext databaseContext)
{
    public WheelList GetById(Guid guid)
    {
        return databaseContext.WheelLists.Find(guid) ?? throw new ArgumentException();
    }

    public WheelList[] GetAll()
    {
        return databaseContext.WheelLists.Where(x => !x.IsDeleted).ToArray();
    }

    public WheelList Add(string name)
    {
        WheelList list = new() { Name = name };
        databaseContext.WheelLists.Add(list);
        databaseContext.SaveChanges();

        return list;
    }

    public WheelItem AddItem(Guid listGuid, string title, string definition)
    {
        GetById(listGuid);

        WheelItem item = new() { 
            ListGuid = listGuid,
            Title = title,
            Definition = definition
        };

        databaseContext.WheelItems.Add(item);
        databaseContext.SaveChanges();

        return item;
    }
}
