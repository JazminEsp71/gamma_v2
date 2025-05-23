using Gamma.System.Core.Dto;
using Gamma.System.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gamma.System.WebSite.Pages.Ordenes;

public class CreateModel : PageModel
{
    private readonly ApiService _apiService;

    public CreateModel(ApiService apiService)
    {
        _apiService = apiService;
    }

    [BindProperty]
    public OrdenesDto Orden { get; set; } = new();

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        try
        {
            var result = await _apiService.CreateOrden(Orden);
            if (result != null)
            {
                return RedirectToPage("./Index");
            }
            
            ModelState.AddModelError(string.Empty, "No se pudo crear la orden. Intente nuevamente.");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, $"Error al crear orden: {ex.Message}");
        }

        return Page();
    }
}