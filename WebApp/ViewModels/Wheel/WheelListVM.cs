using Domain.Wheel;
using System.Diagnostics.CodeAnalysis;

namespace Masha.ViewModels.Wheel;

public class WheelListVM
{
    public required Guid Guid { get; init; }
    public required string Name { get; init; }
    public required WheelItemVM[] Items { get; init; }
    public required ViewMode ViewMode { get; init; }

    [SetsRequiredMembers]
    public WheelListVM(WheelList list, ViewMode viewMode)
    {
        Guid = list.Guid;
        Name = list.Name;
        Items = list.Items!
                    .Select(x => new WheelItemVM(x, viewMode))
                    .ToArray();
        ViewMode = viewMode;
    }
}
