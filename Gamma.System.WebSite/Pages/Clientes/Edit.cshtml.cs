using Gamma.System.Core.Dto;
using Gamma.System.WebSite.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gamma.System.WebSite.Pages.Clientes;

public class EditModel : PageModel
{
    private readonly IClientesService _clientesService;

    public EditModel(IClientesService clientesService)
    {
        _clientesService = clientesService;
    }

    [BindProperty]
    public ClientesDto Cliente { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id.HasValue && id.Value > 0)
        {
            var response = await _clientesService.GetByIdAsync(id.Value);
            if (response.Data == null)
            {
                TempData["Error"] = "Cliente no encontrado";
                return RedirectToPage("./Index");
            }
            Cliente = response.Data;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        try
        {
            var response = (Cliente.IdCliente == 0) 
                ? await _clientesService.SaveAsync(Cliente)
                : await _clientesService.UpdateAsync(Cliente);

            if (response.Errors != null && response.Errors.Any())
            {
                foreach (var error in response.Errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
                return Page();
            }

            TempData["Success"] = Cliente.IdCliente == 0 
                ? "Cliente creado correctamente" 
                : "Cliente actualizado correctamente";
            return RedirectToPage("./Index");
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Error al guardar: {ex.Message}";
            return Page();
        }
    }
}