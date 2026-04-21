using DataAccess.Repositories.Wheel;
using Domain.Schemes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.ViewModels.Schemes;

namespace Masha.Pages;

[IgnoreAntiforgeryToken]
public class SchemesModel(
    SchemeRepository schemeRepository
) : PageModel
{
    public SchemeVM SchemeVM { get; set; } = null!;

    public async Task<IActionResult> OnGet(Guid schemeGuid)
    {
        Scheme scheme = await schemeRepository.GetByIdAsync(schemeGuid);

        return Page();
    }
}
