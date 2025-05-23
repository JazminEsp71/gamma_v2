using System.Net.Http.Json;
using Gamma.System.Core.Dto;
using Gamma.System.Core.Http;

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
    public async Task<string> TestApiConnection()
    {
        try
        {
            var client = _httpClientFactory.CreateClient("GammaAPI");
            var response = await client.GetAsync("apiOrdenes");
        
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return $"Conexión exitosa! Respuesta: {content}";
            }
        
            return $"Error en la API: {response.StatusCode}";
        }
        catch (Exception ex)
        {
            return $"Error de conexión: {ex.Message}";
        }
    }
    //ordenes
    public async Task<List<OrdenesDto>> GetOrdenes()
    {
        try
        {
            var client = _httpClientFactory.CreateClient("Gamma.System.Api");
            var response = await client.GetAsync("apiOrdenes");
        
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadFromJsonAsync<Response<List<OrdenesDto>>>();
                return apiResponse?.Data ?? new List<OrdenesDto>();
            }
            return new List<OrdenesDto>();
        }
        catch (Exception ex)
        {
            return new List<OrdenesDto>();
        }
    }

    public async Task<OrdenesDto> GetOrdenById(int id)
    {
        try
        {
            var client = _httpClientFactory.CreateClient("Gamma.System.Api");
            var response = await client.GetAsync($"apiOrdenes/{id}");
        
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadFromJsonAsync<Response<OrdenesDto>>();
                return apiResponse?.Data;
            }
            return null;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<bool> CreateOrden(OrdenesDto orden)
    {
        try
        {
            var client = _httpClientFactory.CreateClient("Gamma.System.Api");
            var response = await client.PostAsJsonAsync("apiOrdenes", orden);
        
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
        
            var errorContent = await response.Content.ReadAsStringAsync();
            return false;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> UpdateOrden(OrdenesDto orden)
    {
        var client = _httpClientFactory.CreateClient("Gamma.System.Api");
        var response = await client.PutAsJsonAsync("apiOrdenes", orden);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteOrden(int id)
    {
        var client = _httpClientFactory.CreateClient("Gamma.System.Api");
        var response = await client.DeleteAsync($"apiOrdenes/{id}");
        return response.IsSuccessStatusCode;
    }
    
}