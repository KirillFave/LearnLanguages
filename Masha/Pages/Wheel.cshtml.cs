using DataAccess.Repositories.Wheel;
using Domain.Wheel;
using Masha.Services;
using Masha.ViewModels.Wheel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Masha.Pages;

[IgnoreAntiforgeryToken]
public class WheelModel(
    ViewRendererService viewRendererService,
    WheelListRepository listRepository,
    WheelItemRepository itemRepository
) : PageModel
{
    public WheelList[]? Lists { get; set; }

    public void OnGet()
    {
        Lists = listRepository.GetAll();
    }

    public IActionResult OnPostAddList(string name)
    {
        WheelList list = listRepository.Add(name);
        WheelListVM listVM = new(list, ViewMode.Teacher);
        return Partial("~/Views/Wheel/_Wheel.cshtml", listVM);
    }

    public IActionResult OnGetListPartialView(Guid guid, ViewMode viewMode)
    {
        WheelList list = listRepository.GetById(guid);
        WheelListVM listVM = new(list, viewMode);
        return Partial("~/Views/Wheel/_Wheel.cshtml", listVM);
    }

    public IActionResult OnPostAddItem(Guid listGuid, string title, string definition)
    {
        WheelItem item = listRepository.AddItem(listGuid, title, definition);
        WheelItemVM itemVM = new(item, ViewMode.Teacher);
        return Partial("~/Views/Wheel/_WheelItem.cshtml", itemVM);
    }

    public IActionResult OnPostEnableItem(Guid guid)
    {
        itemRepository.Enable(guid);
        return new NoContentResult();
    }

    public IActionResult OnPostDisableItem(Guid guid)
    {
        itemRepository.Disable(guid);
        return new NoContentResult();
    }
}
