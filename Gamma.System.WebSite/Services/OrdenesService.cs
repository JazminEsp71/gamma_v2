using System.Net.Http;
using System.Text;
using Gamma.System.Core.Dto;
using Gamma.System.Core.Http;
using Gamma.System.WebSite.Services.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gamma.System.WebSite.Services;

public class OrdenesService : IOrdenesService
{
    private readonly HttpClient _httpClient;
    private const string Endpoint = "apiOrdenes";

    public OrdenesService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("GammaAPI");
    }

    public async Task<Response<List<OrdenesDto>>> GetAllAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync(Endpoint);

            if (!response.IsSuccessStatusCode)
            {
                return new Response<List<OrdenesDto>>
                {
                    Errors = new List<string> { $"Error: {response.StatusCode}" }
                };
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<List<OrdenesDto>>>(json)
                   ?? new Response<List<OrdenesDto>> { Data = new List<OrdenesDto>() };
        }
        catch (Exception ex)
        {
            return new Response<List<OrdenesDto>>
            {
                Errors = new List<string> { $"Exception: {ex.Message}" }
            };
        }
    }

    public async Task<Response<OrdenesDto>> GetByIdAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"{Endpoint}/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return new Response<OrdenesDto>
                {
                    Errors = new List<string> { $"Error: {response.StatusCode}" }
                };
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<OrdenesDto>>(json)
                   ?? new Response<OrdenesDto>();
        }
        catch (Exception ex)
        {
            return new Response<OrdenesDto>
            {
                Errors = new List<string> { $"Exception: {ex.Message}" }
            };
        }
    }

    public async Task<Response<OrdenesDto>> SaveAsync(OrdenesDto ordenDto)
    {
        try
        {
            var jsonRequest = JsonConvert.SerializeObject(ordenDto);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(Endpoint, content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (IsValidJson(responseContent))
            {
                return JsonConvert.DeserializeObject<Response<OrdenesDto>>(responseContent)
                       ?? new Response<OrdenesDto>();
            }
            else
            {
                return new Response<OrdenesDto>
                {
                    Errors = new List<string> { "La API devolvió una respuesta no esperada" },
                    Message = responseContent
                };
            }
        }
        catch (Exception ex)
        {
            return new Response<OrdenesDto>
            {
                Errors = new List<string> { $"Exception: {ex.Message}" }
            };
        }
    }

    public async Task<Response<OrdenesDto>> UpdateAsync(OrdenesDto ordenDto)
    {
        try
        {
            var jsonRequest = JsonConvert.SerializeObject(ordenDto);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(Endpoint, content);
            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Response<OrdenesDto>>(json)
                   ?? new Response<OrdenesDto>();
        }
        catch (Exception ex)
        {
            return new Response<OrdenesDto>
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

    private bool IsValidJson(string strInput)
    {
        if (string.IsNullOrWhiteSpace(strInput)) return false;

        strInput = strInput.Trim();
        if ((strInput.StartsWith("{") && strInput.EndsWith("}")) ||
            (strInput.StartsWith("[") && strInput.EndsWith("]")))
        {
            try
            {
                JToken.Parse(strInput);
                return true;
            }
            catch
            {
                return false;
            }
        }

        return false;
    }
}