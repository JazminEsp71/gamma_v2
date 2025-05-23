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

    // Agregar más métodos para otros endpoints según necesites
}