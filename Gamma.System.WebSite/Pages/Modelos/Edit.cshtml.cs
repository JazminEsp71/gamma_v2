using Gamma.System.Core.Dto;
using Gamma.System.WebSite.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gamma.System.WebSite.Pages.Modelos;

public class EditModel : PageModel
{
    private readonly IModelosService _modelosService;

    public EditModel(IModelosService modelosService)
    {
        _modelosService = modelosService;
    }

    [BindProperty]
    public ModelosDto Modelo { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id.HasValue)
        {
            var response = await _modelosService.GetByIdAsync(id.Value);
            if (response.Data == null)
            {
                return NotFound();
            }
            Modelo = response.Data;
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
            var response = (Modelo.IdModelo == 0) 
                ? await _modelosService.SaveAsync(Modelo)
                : await _modelosService.UpdateAsync(Modelo);

            if (response.Errors != null && response.Errors.Any())
            {
                foreach (var error in response.Errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
                return Page();
            }

            return RedirectToPage("./Index");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, $"Error al guardar: {ex.Message}");
            return Page();
        }
    }
}