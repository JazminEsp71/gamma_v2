using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gamma.System.WebSite.Pages;

public class IndexModel : PageModel
{
    private readonly AuthService _authService;

    public IndexModel(AuthService authService)
    {
        _authService = authService;
    }

    [BindProperty]
    public string Usuario { get; set; }

    [BindProperty]
    public string Password { get; set; }

    public bool LoginFallido { get; set; }

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        var valido = await _authService.ValidarUsuarioAsync(Usuario, Password);
        if (valido)
            return RedirectToPage("Home");

        LoginFallido = true;
        return Page();
    }
}