using Gamma.System.Core.Dto;
using Gamma.System.WebSite.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gamma.System.WebSite.Pages.Colores;

public class DetailsModel : PageModel
{
    private readonly IColoresService _coloresService;

    public DetailsModel(IColoresService coloresService)
    {
        _coloresService = coloresService;
    }

    public ColoresDto Color { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var response = await _coloresService.GetByIdAsync(id);
        if (response.Data == null)
        {
            TempData["Error"] = "Color no encontrado";
            return RedirectToPage("./Index");
        }

        Color = response.Data;
        return Page();
    }
}