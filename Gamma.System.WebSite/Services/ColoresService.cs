using System.Net.Http;
using System.Text;
using Gamma.System.Core.Dto;
using Gamma.System.Core.Http;
using Gamma.System.WebSite.Services.Interfaces;
using Newtonsoft.Json;

namespace Gamma.System.WebSite.Services;

public class ColoresService : IColoresService
{
    private readonly HttpClient _httpClient;
    private const string Endpoint = "apiColores";

    public ColoresService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("GammaAPI");
    }

    public async Task<Response<List<ColoresDto>>> GetAllAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync(Endpoint);

            if (!response.IsSuccessStatusCode)
            {
                return new Response<List<ColoresDto>>
                {
                    Errors = new List<string> { $"Error: {response.StatusCode}" }
                };
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<List<ColoresDto>>>(json)
                   ?? new Response<List<ColoresDto>>() { Data = new List<ColoresDto>() };
        }
        catch (Exception ex)
        {
            return new Response<List<ColoresDto>>
            {
                Errors = new List<string> { $"Exception: {ex.Message}" }
            };
        }
    }

    public async Task<Response<ColoresDto>> GetByIdAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"{Endpoint}/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return new Response<ColoresDto>
                {
                    Errors = new List<string> { $"Error: {response.StatusCode}" }
                };
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<ColoresDto>>(json)
                   ?? new Response<ColoresDto>();
        }
        catch (Exception ex)
        {
            return new Response<ColoresDto>
            {
                Errors = new List<string> { $"Exception: {ex.Message}" }
            };
        }
    }

    public async Task<Response<ColoresDto>> SaveAsync(ColoresDto coloresDto)
    {
        try
        {
            var jsonRequest = JsonConvert.SerializeObject(coloresDto);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(Endpoint, content);

            if (!response.IsSuccessStatusCode)
            {
                return new Response<ColoresDto>
                {
                    Errors = new List<string> { $"Error: {response.StatusCode}" }
                };
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<ColoresDto>>(json)
                   ?? new Response<ColoresDto>();
        }
        catch (Exception ex)
        {
            return new Response<ColoresDto>
            {
                Errors = new List<string> { $"Exception: {ex.Message}" }
            };
        }
    }

    public async Task<Response<ColoresDto>> UpdateAsync(ColoresDto coloresDto)
    {
        try
        {
            var jsonRequest = JsonConvert.SerializeObject(coloresDto);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(Endpoint, content);

            if (!response.IsSuccessStatusCode)
            {
                return new Response<ColoresDto>
                {
                    Errors = new List<string> { $"Error: {response.StatusCode}" }
                };
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<ColoresDto>>(json)
                   ?? new Response<ColoresDto>();
        }
        catch (Exception ex)
        {
            return new Response<ColoresDto>
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