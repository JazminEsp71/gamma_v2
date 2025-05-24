using System.Net.Http;
using System.Text;
using Gamma.System.Core.Dto;
using Gamma.System.Core.Http;
using Gamma.System.WebSite.Services.Interfaces;
using Newtonsoft.Json;

namespace Gamma.System.WebSite.Services;

public class ColoresService : IColoresService
{
    private readonly string _baseUrl = "http://localhost:5023";
    private readonly string _endpoint = "apiColores";

    public async Task<Response<List<ColoresDto>>> GetAllAsync()
    {
        try
        {
            var url = $"{_baseUrl}/{_endpoint}";
            using var client = new HttpClient();
            
            var response = await client.GetAsync(url);
            
            if (!response.IsSuccessStatusCode)
            {
                return new Response<List<ColoresDto>> 
                { 
                    Errors = new List<string> { $"Error: {response.StatusCode}" } 
                };
            }
            
            var json = await response.Content.ReadAsStringAsync();
            
            if (string.IsNullOrEmpty(json))
            {
                return new Response<List<ColoresDto>> 
                { 
                    Data = new List<ColoresDto>() 
                };
            }
            
            return JsonConvert.DeserializeObject<Response<List<ColoresDto>>>(json);
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
            var url = $"{_baseUrl}/{_endpoint}/{id}";
            using var client = new HttpClient();
            
            var response = await client.GetAsync(url);
            
            if (!response.IsSuccessStatusCode)
            {
                return new Response<ColoresDto> 
                { 
                    Errors = new List<string> { $"Error: {response.StatusCode}" } 
                };
            }
            
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<ColoresDto>>(json);
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
            var url = $"{_baseUrl}/{_endpoint}";
            using var client = new HttpClient();
            
            var jsonRequest = JsonConvert.SerializeObject(coloresDto);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            
            var response = await client.PostAsync(url, content);
            
            if (!response.IsSuccessStatusCode)
            {
                return new Response<ColoresDto> 
                { 
                    Errors = new List<string> { $"Error: {response.StatusCode}" } 
                };
            }
            
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<ColoresDto>>(json);
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
            var url = $"{_baseUrl}/{_endpoint}";
            using var client = new HttpClient();
            
            var jsonRequest = JsonConvert.SerializeObject(coloresDto);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            
            var response = await client.PutAsync(url, content);
            
            if (!response.IsSuccessStatusCode)
            {
                return new Response<ColoresDto> 
                { 
                    Errors = new List<string> { $"Error: {response.StatusCode}" } 
                };
            }
            
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<ColoresDto>>(json);
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
            var url = $"{_baseUrl}/{_endpoint}/{id}";
            using var client = new HttpClient();
            
            var response = await client.DeleteAsync(url);
            
            if (!response.IsSuccessStatusCode)
            {
                return new Response<bool> 
                { 
                    Errors = new List<string> { $"Error: {response.StatusCode}" } 
                };
            }
            
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<bool>>(json);
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