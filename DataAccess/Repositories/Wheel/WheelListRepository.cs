using Domain.Wheel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public WheelItem AddItem(Guid listGuid, string newItemTitle)
    {
        GetById(listGuid);

        WheelItem item = new() { 
            ListGuid = listGuid,
            Title = newItemTitle
        };

        databaseContext.WheelItems.Add(item);
        databaseContext.SaveChanges();

        return item;
    }
}
