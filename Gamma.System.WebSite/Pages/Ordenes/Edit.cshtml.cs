using Gamma.System.Core.Dto;
using Gamma.System.WebSite.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gamma.System.WebSite.Pages.Ordenes;

public class EditModel : PageModel
{
    private readonly IOrdenesService _ordenesService;

    public EditModel(IOrdenesService ordenesService)
    {
        _ordenesService = ordenesService;
    }

    [BindProperty]
    public OrdenesDto Orden { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id.HasValue)
        {
            var response = await _ordenesService.GetByIdAsync(id.Value);
            if (response.Data == null)
            {
                return NotFound();
            }
            Orden = response.Data;
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
            var response = (Orden.Id == 0) 
                ? await _ordenesService.SaveAsync(Orden)
                : await _ordenesService.UpdateAsync(Orden);

            if (response.Errors != null && response.Errors.Any())
            {
                foreach (var error in response.Errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
                return Page();
            }

            return RedirectToPage("./List");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, $"Error al guardar: {ex.Message}");
            return Page();
        }
    }
}