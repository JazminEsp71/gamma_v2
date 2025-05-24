using Gamma.System.Core.Dto;
using Gamma.System.WebSite.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gamma.System.WebSite.Pages.Clientes;

public class DeleteModel : PageModel
{
    private readonly IClientesService _clientesService;

    public DeleteModel(IClientesService clientesService)
    {
        _clientesService = clientesService;
    }

    [BindProperty]
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

    public async Task<IActionResult> OnPostAsync()
    {
        try
        {
            var response = await _clientesService.DeleteAsync(Cliente.IdCliente);
            
            if (response.Errors != null && response.Errors.Any())
            {
                TempData["Error"] = string.Join(", ", response.Errors);
                return Page();
            }

            TempData["Success"] = "Cliente eliminado correctamente";
            return RedirectToPage("./Index");
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Error al eliminar: {ex.Message}";
            return Page();
        }
    }
}