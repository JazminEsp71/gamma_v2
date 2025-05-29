using System.Net.Http;
using System.Text;
using Gamma.System.Core.Dto;
using Gamma.System.Core.Http;
using Gamma.System.WebSite.Services.Interfaces;
using Newtonsoft.Json;

namespace Gamma.System.WebSite.Services;

public class MaquinasService : IMaquinasService
{
    private readonly HttpClient _httpClient;

    public MaquinasService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("GammaAPI");
    }

    public async Task<Response<List<MaquinasDto>>> GetAllAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("apiMaquinas");

            if (!response.IsSuccessStatusCode)
            {
                return new Response<List<MaquinasDto>>
                {
                    Errors = new List<string> { $"Error: {response.StatusCode}" }
                };
            }

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Response<List<MaquinasDto>>>(json)
                   ?? new Response<List<MaquinasDto>> { Data = new List<MaquinasDto>() };
        }
        catch (Exception ex)
        {
            return new Response<List<MaquinasDto>>
            {
                Errors = new List<string> { $"Exception: {ex.Message}" }
            };
        }
    }


    public async Task<Response<MaquinasDto>> SaveAsync(MaquinasDto maquinaDto)
    {
        try
        {
            var jsonRequest = JsonConvert.SerializeObject(maquinaDto);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("apiMaquinas", content);
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<MaquinasDto>>(json)
                   ?? new Response<MaquinasDto>();
        }
        catch (Exception ex)
        {
            return new Response<MaquinasDto>
            {
                Errors = new List<string> { $"Exception: {ex.Message}" }
            };
        }
    }
    
    public async Task<Response<MaquinasDto>> GetByIdAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"apiMaquinas/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return new Response<MaquinasDto>
                {
                    Errors = new List<string> { $"Error: {response.StatusCode}" }
                };
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<MaquinasDto>>(json)
                   ?? new Response<MaquinasDto>();
        }
        catch (Exception ex)
        {
            return new Response<MaquinasDto>
            {
                Errors = new List<string> { $"Exception: {ex.Message}" }
            };
        }
    }



    public async Task<Response<MaquinasDto>> UpdateAsync(MaquinasDto maquinaDto)
    {
        var jsonRequest = JsonConvert.SerializeObject(maquinaDto);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

        var response = await _httpClient.PutAsync("apiMaquinas", content);
        var json = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Response<MaquinasDto>>(json);
    }

    public async Task<Response<bool>> DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"apiMaquinas/{id}");
        var json = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Response<bool>>(json);
    }
}
