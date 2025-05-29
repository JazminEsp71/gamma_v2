using System.Net.Http;
using System.Text;
using Gamma.System.Core.Dto;
using Gamma.System.Core.Http;
using Gamma.System.WebSite.Services.Interfaces;
using Newtonsoft.Json;

namespace Gamma.System.WebSite.Services;

public class ClientesService : IClientesService
{
    private readonly HttpClient _httpClient;
    private const string Endpoint = "apiClientes";

    public ClientesService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("GammaAPI");
    }

    public async Task<Response<List<ClientesDto>>> GetAllAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync(Endpoint);

            if (!response.IsSuccessStatusCode)
            {
                return new Response<List<ClientesDto>>
                {
                    Errors = new List<string> { $"Error: {response.StatusCode}" }
                };
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<List<ClientesDto>>>(json)
                   ?? new Response<List<ClientesDto>>() { Data = new List<ClientesDto>() };
        }
        catch (Exception ex)
        {
            return new Response<List<ClientesDto>>
            {
                Errors = new List<string> { $"Exception: {ex.Message}" }
            };
        }
    }

    public async Task<Response<ClientesDto>> GetByIdAsync(int idCliente)
    {
        try
        {
            var response = await _httpClient.GetAsync($"{Endpoint}/{idCliente}");

            if (!response.IsSuccessStatusCode)
            {
                return new Response<ClientesDto>
                {
                    Errors = new List<string> { $"Error: {response.StatusCode}" }
                };
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<ClientesDto>>(json)
                   ?? new Response<ClientesDto>();
        }
        catch (Exception ex)
        {
            return new Response<ClientesDto>
            {
                Errors = new List<string> { $"Exception: {ex.Message}" }
            };
        }
    }

    public async Task<Response<ClientesDto>> SaveAsync(ClientesDto clientesDto)
    {
        try
        {
            var jsonRequest = JsonConvert.SerializeObject(clientesDto);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(Endpoint, content);

            if (!response.IsSuccessStatusCode)
            {
                return new Response<ClientesDto>
                {
                    Errors = new List<string> { $"Error: {response.StatusCode}" }
                };
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<ClientesDto>>(json)
                   ?? new Response<ClientesDto>();
        }
        catch (Exception ex)
        {
            return new Response<ClientesDto>
            {
                Errors = new List<string> { $"Exception: {ex.Message}" }
            };
        }
    }

    public async Task<Response<ClientesDto>> UpdateAsync(ClientesDto clientesDto)
    {
        try
        {
            var jsonRequest = JsonConvert.SerializeObject(clientesDto);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(Endpoint, content);

            if (!response.IsSuccessStatusCode)
            {
                return new Response<ClientesDto>
                {
                    Errors = new List<string> { $"Error: {response.StatusCode}" }
                };
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<ClientesDto>>(json)
                   ?? new Response<ClientesDto>();
        }
        catch (Exception ex)
        {
            return new Response<ClientesDto>
            {
                Errors = new List<string> { $"Exception: {ex.Message}" }
            };
        }
    }

    public async Task<Response<bool>> DeleteAsync(int idCliente)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"{Endpoint}/{idCliente}");

            if (!response.IsSuccessStatusCode)
            {
                return new Response<bool>
                {
                    Errors = new List<string> { $"Error: {response.StatusCode}" }
                };
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<bool>>(json)
                   ?? new Response<bool>();
        }
        catch (Exception ex)
        {
            return new Response<bool>
            {
                Errors = new List<string> { $"Exception: {ex.Message}" }
            };
        }
    }
}