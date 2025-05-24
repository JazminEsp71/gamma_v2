using Gamma.System.Core.Dto;
using Gamma.System.WebSite.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gamma.System.WebSite.Pages.Clientes;

public class DetailsModel : PageModel
{
    private readonly IClientesService _clientesService;

    public DetailsModel(IClientesService clientesService)
    {
        _clientesService = clientesService;
    }

    public ClientesDto Cliente { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var response = await _clientesService.GetByIdAsync(id);
        if (response.Data == null)
        {
            TempData["Error"] = "Cliente no encontrado";
            return RedirectToPage("./Index");
        }

        Cliente = response.Data;
        return Page();
    }
}