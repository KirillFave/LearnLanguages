using Domain.Wheel;
using System.Diagnostics.CodeAnalysis;

namespace Masha.ViewModels.Wheel;

public class WheelItemVM
{
    public required Guid Guid { get; init; }
    public required string Title { get; init; }
    public required string Definition { get; init; }
    public required bool IsInactive { get; init; }
    public required ViewMode ViewMode { get; init; }

    [SetsRequiredMembers]
    public WheelItemVM(WheelItem item, ViewMode viewMode)
    {
        Guid = item.Guid;
        Title = item.Title;
        Definition = item.Definition;
        IsInactive = item.IsInactive;
        ViewMode = viewMode;
    }
}
