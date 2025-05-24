using Gamma.System.Core.Dto;
using Gamma.System.WebSite.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gamma.System.WebSite.Pages.Modelos;

public class DeleteModel : PageModel
{
    private readonly IModelosService _modelosService;

    public DeleteModel(IModelosService modelosService)
    {
        _modelosService = modelosService;
    }

    [BindProperty]
    public ModelosDto Modelo { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var response = await _modelosService.GetByIdAsync(id);
        if (response.Data == null)
        {
            return NotFound();
        }

        Modelo = response.Data;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _modelosService.DeleteAsync(Modelo.IdModelo);
        return RedirectToPage("./Index");
    }
}