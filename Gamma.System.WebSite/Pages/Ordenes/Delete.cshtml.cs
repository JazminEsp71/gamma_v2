using Gamma.System.Core.Dto;
using Gamma.System.WebSite.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gamma.System.WebSite.Pages.Ordenes;

public class DeleteModel : PageModel
{
    private readonly IOrdenesService _ordenesService;

    public DeleteModel(IOrdenesService ordenesService)
    {
        _ordenesService = ordenesService;
    }

    [BindProperty]
    public OrdenesDto Orden { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var response = await _ordenesService.GetByIdAsync(id);
        if (response.Data == null)
        {
            return NotFound();
        }

        Orden = response.Data;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _ordenesService.DeleteAsync(Orden.Id);
        return RedirectToPage("./List");
    }
}