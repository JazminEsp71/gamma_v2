using Gamma.System.Core.Dto;
using Gamma.System.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gamma.System.WebSite.Pages;

public class Login : PageModel
{
    public void OnGet()
    {
        // Método GET vacío
    }

    public IActionResult OnPost()
    {
        // Redirigir directamente al Index sin validar credenciales
        return RedirectToPage("/Index");
    }
}