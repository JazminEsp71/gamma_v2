using Gamma.System.WebSite.Services;
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
    public string nombre { get; set; }

    [BindProperty]
    public string contrasena { get; set; }
    public bool LoginFallido { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        var usuarioValido = await _authService.ValidarUsuarioAsync(nombre, contrasena);

        if (!usuarioValido)
        {
            ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrectos");
            return Page();
        }

        // Aquí ya puedes redirigir a la vista con los 5 apartados
        return RedirectToPage("/Dashboard");
    }
}
