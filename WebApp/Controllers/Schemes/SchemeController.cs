using Microsoft.AspNetCore.Mvc;
using DataAccess.Repositories.Wheel;
using Domain.Schemes;

namespace WebApp.Controllers.Schemes;

[ApiController]
[Route("api/schemes")]
public class SchemeController(
    SchemeRepository schemeRepository) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add(string name)
    {
        Scheme scheme = await schemeRepository.Add(name);
        return Ok(scheme);
    }
}
