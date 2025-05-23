using System.Net.Http.Json;
using Gamma.System.Core.Dto;

namespace Gamma.System.WebSite.Services;

public class ApiService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ApiService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
    {
        _httpClientFactory = httpClientFactory;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<HttpResponseMessage> Login(UsuariosDto usuario)
    {
        var client = _httpClientFactory.CreateClient("GammaAPI");
        return await client.PostAsJsonAsync("api/usuarios/login", usuario);
    }
// En Services/ApiService.cs
    public async Task<UsuariosDto?> Authenticate(string correo, string contrasena)
    {
        var client = _httpClientFactory.CreateClient("Gamma.System.Api");
    
        try
        {
            var response = await client.PostAsJsonAsync("api/usuarios", new {
                Correo = correo,
                Contrasena = contrasena
            });

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<UsuariosDto>();
            }
        
            // Si la respuesta no es exitosa, leer el mensaje de error
            var errorContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Error en autenticación: {errorContent}");
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Excepción al autenticar: {ex.Message}");
            return null;
        }
    }
}