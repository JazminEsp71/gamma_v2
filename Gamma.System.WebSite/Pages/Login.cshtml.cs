using Gamma.System.Core.Dto;
using Gamma.System.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gamma.System.WebSite.Pages;

public class Login : PageModel
{
    private readonly ApiService _apiService;

    public Login(ApiService apiService)
    {
        _apiService = apiService;
    }

    [BindProperty]
    public UsuariosDto Usuario { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var response = await _apiService.Login(Usuario);

        if (response.IsSuccessStatusCode)
        {
            var usuario = await response.Content.ReadFromJsonAsync<UsuariosDto>();
            HttpContext.Session.SetString("UsuarioId", usuario.IdUsuario.ToString());
            HttpContext.Session.SetString("NombreUsuario", usuario.Nombre);
            return RedirectToPage("/Index");
        }

        ModelState.AddModelError(string.Empty, "Credenciales inválidas");
        return Page();
    }
}