using Gamma.System.Core.Dto;
using Gamma.System.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gamma.System.WebSite.Pages.Ordenes;

public class EditModel : PageModel
{
    private readonly ApiService _apiService;

    public EditModel(ApiService apiService)
    {
        _apiService = apiService;
    }

    [BindProperty]
    public OrdenesDto Orden { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var orden = await _apiService.GetOrdenById(id);
        if (orden == null)
        {
            return NotFound();
        }

        Orden = orden;
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
            var success = await _apiService.UpdateOrden(Orden);
            if (success)
            {
                return RedirectToPage("./Index");
            }
            
            ModelState.AddModelError(string.Empty, "No se pudo actualizar la orden. Intente nuevamente.");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, $"Error al actualizar orden: {ex.Message}");
        }

        return Page();
    }
}