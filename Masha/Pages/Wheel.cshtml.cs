using DataAccess.Repositories.Wheel;
using Domain.Wheel;
using Masha.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

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

        string rendered = viewRendererService.RenderViewToStringAsync("_Wheel", list)
                .GetAwaiter()
                .GetResult();

        return new OkObjectResult(rendered);
    }

    public IActionResult OnGetListPartialView(Guid guid)
    {
        WheelList list = listRepository.GetById(guid);

        string rendered = viewRendererService.RenderViewToStringAsync("_Wheel", list)
                .GetAwaiter()
                .GetResult();

        return new OkObjectResult(rendered);
    }

    public IActionResult OnPostAddItem(Guid listGuid, string title, string definition)
    {
        WheelItem item = listRepository.AddItem(listGuid, title, definition);

        string rendered = viewRendererService.RenderViewToStringAsync("_WheelItem", item)
            .GetAwaiter()
            .GetResult();

        return new OkObjectResult(rendered);
    }
}
