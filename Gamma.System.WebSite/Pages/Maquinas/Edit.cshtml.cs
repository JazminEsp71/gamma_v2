using Gamma.System.Core.Dto;
using Gamma.System.WebSite.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gamma.System.WebSite.Pages.Maquinas;

public class EditModel : PageModel
{
    private readonly IMaquinasService _maquinasService;

    public EditModel(IMaquinasService maquinasService)
    {
        _maquinasService = maquinasService;
    }

    [BindProperty]
    public MaquinasDto Maquina { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id.HasValue)
        {
            var response = await _maquinasService.GetByIdAsync(id.Value);
            if (response.Data == null)
            {
                return NotFound();
            }
            Maquina = response.Data;
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
            var response = (Maquina.Id == 0) 
                ? await _maquinasService.SaveAsync(Maquina)
                : await _maquinasService.UpdateAsync(Maquina);

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