using Domain.Schemes;

namespace WebApp.ViewModels.Schemes;

public class SchemeVM
{
    public required Guid Guid { get; set; }
    public required string Name { get; set; }

    public required SchemeItemVM[] ItemVMs { get; set; }
}
