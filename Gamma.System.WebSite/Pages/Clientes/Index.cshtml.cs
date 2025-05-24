using Gamma.System.Core.Dto;
using Gamma.System.WebSite.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gamma.System.WebSite.Pages.Clientes;

public class IndexModel : PageModel
{
    private readonly IClientesService _clientesService;

    public IndexModel(IClientesService clientesService)
    {
        _clientesService = clientesService;
    }

    public List<ClientesDto> Clientes { get; set; } = new();

    public async Task OnGetAsync()
    {
        try
        {
            var response = await _clientesService.GetAllAsync();
            
            if (response == null)
            {
                Clientes = new List<ClientesDto>();
                TempData["Error"] = "No se pudo obtener respuesta del servicio";
                return;
            }

            if (response.Errors != null && response.Errors.Any())
            {
                Clientes = new List<ClientesDto>();
                TempData["Error"] = string.Join(", ", response.Errors);
                return;
            }

            Clientes = response.Data ?? new List<ClientesDto>();
        }
        catch (Exception ex)
        {
            Clientes = new List<ClientesDto>();
            TempData["Error"] = $"Error al cargar los clientes: {ex.Message}";
        }
    }
}