using Gamma.System.Core.Dto;
using Gamma.System.WebSite.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gamma.System.WebSite.Pages.Maquinas;

public class DeleteModel : PageModel
{
    private readonly IMaquinasService _maquinasService;

    public DeleteModel(IMaquinasService maquinasService)
    {
        _maquinasService = maquinasService;
    }

    [BindProperty]
    public MaquinasDto Maquina { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var response = await _maquinasService.GetByIdAsync(id);
        if (response.Data == null)
        {
            return NotFound();
        }

        Maquina = response.Data;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _maquinasService.DeleteAsync(Maquina.Id);
        return RedirectToPage("./Index");
    }
}