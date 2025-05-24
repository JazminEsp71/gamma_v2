using Gamma.System.Core.Dto;
using Gamma.System.WebSite.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gamma.System.WebSite.Pages.Ordenes;

public class ListModel : PageModel
{
    private readonly IOrdenesService _ordenesService;

    public ListModel(IOrdenesService ordenesService)
    {
        _ordenesService = ordenesService;
    }

    public List<OrdenesDto> Ordenes { get; set; } = new();

    public async Task OnGetAsync()
    {
        var response = await _ordenesService.GetAllAsync();
        Ordenes = response.Data ?? new List<OrdenesDto>();
    }
}