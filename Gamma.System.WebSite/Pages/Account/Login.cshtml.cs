using System.ComponentModel.DataAnnotations;
using Gamma.System.Core.Dto;
using Gamma.System.WebSite.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Gamma.System.WebSite.Pages.Account;

public class LoginModel : PageModel
{
    private readonly IUsuariosService _usuariosService;
    private readonly ILogger<LoginModel> _logger;

    public LoginModel(IUsuariosService usuariosService, ILogger<LoginModel> logger)
    {
        _usuariosService = usuariosService;
        _logger = logger;
    }

    [BindProperty]
    public InputModel Input { get; set; }

    public string? ReturnUrl { get; set; }

    [TempData]
    public string ErrorMessage { get; set; }

    public class InputModel
    {
        [Required(ErrorMessage = "El correo es requerido")]
        [EmailAddress(ErrorMessage = "Correo electrónico no válido")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; }

        [Display(Name = "Recordar mis datos")]
        public bool RememberMe { get; set; }
    }

    public void OnGet(string? returnUrl = null)
    {
        if (!string.IsNullOrEmpty(ErrorMessage))
        {
            ModelState.AddModelError(string.Empty, ErrorMessage);
        }

        ReturnUrl = returnUrl;
    }

    public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
    {
        ReturnUrl = returnUrl ?? Url.Content("~/");

        if (!ModelState.IsValid)
        {
            return Page();
        }

        try
        {
            var result = await _usuariosService.AuthenticateAsync(Input.Correo, Input.Contrasena);
            
            if (!result.Success || result.Data == null)
            {
                ModelState.AddModelError(string.Empty, "Intento de inicio de sesión no válido.");
                return Page();
            }

            var usuario = result.Data;
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nombre),
                new Claim(ClaimTypes.Email, usuario.Correo)
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = Input.RememberMe,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            _logger.LogInformation("Usuario {Correo} inició sesión.", usuario.Correo);

            return LocalRedirect(ReturnUrl);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error durante el inicio de sesión para el correo {Correo}", Input.Correo);
            ModelState.AddModelError(string.Empty, "Ocurrió un error al intentar iniciar sesión.");
            return Page();
        }
    }
}