using Gamma.System.Core.Dto;
using Gamma.System.WebSite.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gamma.System.WebSite.Pages.Colores;

public class IndexModel : PageModel
{
    private readonly IColoresService _coloresService;

    public IndexModel(IColoresService coloresService)
    {
        _coloresService = coloresService;
    }

    public List<ColoresDto> Colores { get; set; } = new();

    public async Task OnGetAsync()
    {
        try
        {
            var response = await _coloresService.GetAllAsync();
            
            if (response == null)
            {
                Colores = new List<ColoresDto>();
                TempData["Error"] = "No se pudo obtener respuesta del servicio";
                return;
            }

            if (response.Errors != null && response.Errors.Any())
            {
                Colores = new List<ColoresDto>();
                TempData["Error"] = string.Join(", ", response.Errors);
                return;
            }

            Colores = response.Data ?? new List<ColoresDto>();
        }
        catch (Exception ex)
        {
            Colores = new List<ColoresDto>();
            TempData["Error"] = $"Error al cargar los colores: {ex.Message}";
        }
    }
}