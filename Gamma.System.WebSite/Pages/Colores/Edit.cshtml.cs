using Gamma.System.Core.Dto;
using Gamma.System.WebSite.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gamma.System.WebSite.Pages.Colores;

public class EditModel : PageModel
{
    private readonly IColoresService _coloresService;

    public EditModel(IColoresService coloresService)
    {
        _coloresService = coloresService;
    }

    [BindProperty]
    public ColoresDto Color { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id.HasValue && id.Value > 0)
        {
            var response = await _coloresService.GetByIdAsync(id.Value);
            if (response.Data == null)
            {
                TempData["Error"] = "Color no encontrado";
                return RedirectToPage("./Index");
            }
            Color = response.Data;
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
            var response = (Color.Id == 0) 
                ? await _coloresService.SaveAsync(Color)
                : await _coloresService.UpdateAsync(Color);

            if (response.Errors != null && response.Errors.Any())
            {
                foreach (var error in response.Errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
                return Page();
            }

            TempData["Success"] = Color.Id == 0 
                ? "Color creado correctamente" 
                : "Color actualizado correctamente";
            return RedirectToPage("./Index");
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Error al guardar: {ex.Message}";
            return Page();
        }
    }
}