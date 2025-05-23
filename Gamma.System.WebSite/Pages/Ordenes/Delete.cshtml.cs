using Gamma.System.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gamma.System.WebSite.Pages.Ordenes;

public class DeleteModel : PageModel
{
    private readonly ApiService _apiService;

    public DeleteModel(ApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var success = await _apiService.DeleteOrden(id);
        if (!success)
        {
            TempData["ErrorMessage"] = "No se pudo eliminar la orden.";
        }

        return RedirectToPage("./Index");
    }
}