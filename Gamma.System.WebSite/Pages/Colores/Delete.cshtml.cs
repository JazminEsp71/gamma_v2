using Gamma.System.Core.Dto;
using Gamma.System.WebSite.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gamma.System.WebSite.Pages.Colores;

public class DeleteModel : PageModel
{
    private readonly IColoresService _coloresService;

    public DeleteModel(IColoresService coloresService)
    {
        _coloresService = coloresService;
    }

    [BindProperty]
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

    public async Task<IActionResult> OnPostAsync()
    {
        try
        {
            var response = await _coloresService.DeleteAsync(Color.Id);
            
            if (response.Errors != null && response.Errors.Any())
            {
                TempData["Error"] = string.Join(", ", response.Errors);
                return Page();
            }

            TempData["Success"] = "Color eliminado correctamente";
            return RedirectToPage("./Index");
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Error al eliminar: {ex.Message}";
            return Page();
        }
    }
}