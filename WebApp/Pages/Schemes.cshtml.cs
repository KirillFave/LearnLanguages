using AutoMapper;
using DataAccess.Repositories.Wheel;
using Domain.Schemes;
using Domain.Schemes.Dto;
using Masha.ViewModels.Wheel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using WebApp.ViewModels.Schemes;

namespace Masha.Pages;

[IgnoreAntiforgeryToken]
public class SchemesModel(
    SchemeRepository schemeRepository,
    SchemeItemRepository schemeItemRepository,
    IMapper mapper
) : PageModel
{
    public SchemeVM SchemeVM { get; set; } = null!;

    [BindProperty]
    public AddSchemeItemDto AddSchemeItemDto { get; set; } = null!;

    public async Task<IActionResult> OnGet(Guid schemeGuid)
    {
        Scheme scheme = await schemeRepository.GetByIdAsync(schemeGuid);

        SchemeVM = mapper.Map<SchemeVM>(scheme);

        return Page();
    }

    public IActionResult OnPostAddItem()
    {
        SchemeItem schemeItem = schemeItemRepository.Add(AddSchemeItemDto);
        SchemeItemVM VM = mapper.Map<SchemeItemVM>(schemeItem);
        return Partial("~/Views/Schemes/_SchemeItemBadge.cshtml", VM);
    }
}
