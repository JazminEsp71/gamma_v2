using Gamma.System.Core.Dto;
using Gamma.System.WebSite.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gamma.System.WebSite.Pages.Maquinas;

public class DetailsModel : PageModel
{
    private readonly IMaquinasService _maquinasService;

    public DetailsModel(IMaquinasService maquinasService)
    {
        _maquinasService = maquinasService;
    }

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
}