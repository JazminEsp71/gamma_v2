using Gamma.System.Core.Dto;
using Gamma.System.WebSite.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gamma.System.WebSite.Pages.Maquinas;

public class IndexModel : PageModel
{
    private readonly IMaquinasService _maquinasService;

    public IndexModel(IMaquinasService maquinasService)
    {
        _maquinasService = maquinasService;
    }

    public List<MaquinasDto> Maquinas { get; set; } = new();

    public async Task OnGetAsync()
    {
        var response = await _maquinasService.GetAllAsync();
        Maquinas = response.Data ?? new List<MaquinasDto>();
    }
}