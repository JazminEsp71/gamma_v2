using Gamma.System.Core.Dto;
using Gamma.System.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gamma.System.WebSite.Pages.Ordenes;

public class IndexModel : PageModel
{
    private readonly ApiService _apiService;

    public IndexModel(ApiService apiService)
    {
        _apiService = apiService;
    }

    public List<OrdenesDto> Ordenes { get; set; } = new();

    public async Task<IActionResult> OnGetAsync()
    {
        try
        {
            Ordenes = await _apiService.GetOrdenes();
            return Page();
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, $"Error al cargar órdenes: {ex.Message}");
            Ordenes = new List<OrdenesDto>();
            return Page();
        }
    }
}