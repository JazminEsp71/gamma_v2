using System.Net.Http;
using System.Text;
using Gamma.System.Core.Dto;
using Gamma.System.Core.Http;
using Gamma.System.WebSite.Services.Interfaces;
using Newtonsoft.Json;

namespace Gamma.System.WebSite.Services;

public class ModelosService : IModelosService
{
    private readonly HttpClient _httpClient;
    private const string Endpoint = "apiModelos";

    public ModelosService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("GammaAPI");
    }

    public async Task<Response<List<ModelosDto>>> GetAllAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync(Endpoint);

            if (!response.IsSuccessStatusCode)
            {
                return new Response<List<ModelosDto>>
                {
                    Errors = new List<string> { $"Error: {response.StatusCode}" }
                };
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<List<ModelosDto>>>(json)
                   ?? new Response<List<ModelosDto>> { Data = new List<ModelosDto>() };
        }
        catch (Exception ex)
        {
            return new Response<List<ModelosDto>>
            {
                Errors = new List<string> { $"Exception: {ex.Message}" }
            };
        }
    }

    public async Task<Response<ModelosDto>> GetByIdAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"{Endpoint}/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return new Response<ModelosDto>
                {
                    Errors = new List<string> { $"Error: {response.StatusCode}" }
                };
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<ModelosDto>>(json)
                   ?? new Response<ModelosDto>();
        }
        catch (Exception ex)
        {
            return new Response<ModelosDto>
            {
                Errors = new List<string> { $"Exception: {ex.Message}" }
            };
        }
    }

    public async Task<Response<ModelosDto>> SaveAsync(ModelosDto modeloDto)
    {
        try
        {
            var jsonRequest = JsonConvert.SerializeObject(modeloDto);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(Endpoint, content);

            if (!response.IsSuccessStatusCode)
            {
                return new Response<ModelosDto>
                {
                    Errors = new List<string> { $"Error: {response.StatusCode}" }
                };
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<ModelosDto>>(json)
                   ?? new Response<ModelosDto>();
        }
        catch (Exception ex)
        {
            return new Response<ModelosDto>
            {
                Errors = new List<string> { $"Exception: {ex.Message}" }
            };
        }
    }

    public async Task<Response<ModelosDto>> UpdateAsync(ModelosDto modeloDto)
    {
        try
        {
            var jsonRequest = JsonConvert.SerializeObject(modeloDto);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(Endpoint, content);

            if (!response.IsSuccessStatusCode)
            {
                return new Response<ModelosDto>
                {
                    Errors = new List<string> { $"Error: {response.StatusCode}" }
                };
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<ModelosDto>>(json)
                   ?? new Response<ModelosDto>();
        }
        catch (Exception ex)
        {
            return new Response<ModelosDto>
            {
                Errors = new List<string> { $"Exception: {ex.Message}" }
            };
        }
    }

    public async Task<Response<bool>> DeleteAsync(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"{Endpoint}/{id}");

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