using Gamma.System.Core.Dto;
using Gamma.System.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gamma.System.WebSite.Pages.Ordenes;

public class IndexModel : PageModel
{
    private readonly ApiService _apiService;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ApiService apiService, ILogger<IndexModel> logger)
    {
        _apiService = apiService;
        _logger = logger;
    }

    public List<OrdenesDto> Ordenes { get; set; } = new();

    public async Task<IActionResult> OnGetAsync()
    {
        try
        {
            Ordenes = await _apiService.GetOrdenes();
            
            if (Ordenes == null || Ordenes.Count == 0)
            {
                _logger.LogWarning("No se encontraron órdenes o la lista está vacía");
                TempData["WarningMessage"] = "No se encontraron órdenes registradas.";
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener órdenes");
            TempData["ErrorMessage"] = "Error al cargar las órdenes. Por favor intente nuevamente.";
            Ordenes = new List<OrdenesDto>();
        }

        return Page();
    }
}