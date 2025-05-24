using System.Net.Http;
using System.Text;
using Gamma.System.Core.Dto;
using Gamma.System.Core.Http;
using Gamma.System.WebSite.Services.Interfaces;
using Newtonsoft.Json;

namespace Gamma.System.WebSite.Services;

public class ClientesService : IClientesService
{
    private readonly string _baseUrl = "http://localhost:5023";
    private readonly string _endpoint = "apiClientes";

    public async Task<Response<List<ClientesDto>>> GetAllAsync()
    {
        try
        {
            var url = $"{_baseUrl}/{_endpoint}";
            using var client = new HttpClient();
            
            var response = await client.GetAsync(url);
            
            if (!response.IsSuccessStatusCode)
            {
                return new Response<List<ClientesDto>> 
                { 
                    Errors = new List<string> { $"Error: {response.StatusCode}" } 
                };
            }
            
            var json = await response.Content.ReadAsStringAsync();
            
            if (string.IsNullOrEmpty(json))
            {
                return new Response<List<ClientesDto>> 
                { 
                    Data = new List<ClientesDto>() 
                };
            }
            
            return JsonConvert.DeserializeObject<Response<List<ClientesDto>>>(json);
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
            var url = $"{_baseUrl}/{_endpoint}/{idCliente}";
            using var client = new HttpClient();
            
            var response = await client.GetAsync(url);
            
            if (!response.IsSuccessStatusCode)
            {
                return new Response<ClientesDto> 
                { 
                    Errors = new List<string> { $"Error: {response.StatusCode}" } 
                };
            }
            
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<ClientesDto>>(json);
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
            var url = $"{_baseUrl}/{_endpoint}";
            using var client = new HttpClient();
            
            var jsonRequest = JsonConvert.SerializeObject(clientesDto);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            
            var response = await client.PostAsync(url, content);
            
            if (!response.IsSuccessStatusCode)
            {
                return new Response<ClientesDto> 
                { 
                    Errors = new List<string> { $"Error: {response.StatusCode}" } 
                };
            }
            
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<ClientesDto>>(json);
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
            var url = $"{_baseUrl}/{_endpoint}";
            using var client = new HttpClient();
            
            var jsonRequest = JsonConvert.SerializeObject(clientesDto);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            
            var response = await client.PutAsync(url, content);
            
            if (!response.IsSuccessStatusCode)
            {
                return new Response<ClientesDto> 
                { 
                    Errors = new List<string> { $"Error: {response.StatusCode}" } 
                };
            }
            
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<ClientesDto>>(json);
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
            var url = $"{_baseUrl}/{_endpoint}/{idCliente}";
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