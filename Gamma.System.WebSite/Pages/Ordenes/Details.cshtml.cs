using Gamma.System.Core.Dto;
using Gamma.System.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gamma.System.WebSite.Pages.Ordenes;

public class DetailsModel : PageModel
{
    private readonly ApiService _apiService;

    public DetailsModel(ApiService apiService)
    {
        _apiService = apiService;
    }

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
}