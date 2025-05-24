using Gamma.System.Core.Dto;
using Gamma.System.WebSite.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gamma.System.WebSite.Pages.Modelos;

public class IndexModel : PageModel
{
    private readonly IModelosService _modelosService;

    public IndexModel(IModelosService modelosService)
    {
        _modelosService = modelosService;
    }

    public List<ModelosDto> Modelos { get; set; } = new();

    public async Task OnGetAsync()
    {
        var response = await _modelosService.GetAllAsync();
        Modelos = response.Data ?? new List<ModelosDto>();
    }
}