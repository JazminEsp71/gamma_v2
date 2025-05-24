using System.Net.Http;
using System.Text;
using Gamma.System.Core.Dto;
using Gamma.System.Core.Http;
using Gamma.System.WebSite.Services.Interfaces;
using Newtonsoft.Json;

namespace Gamma.System.WebSite.Services;

public class UsuariosService : IUsuariosService
{
    private readonly string _baseUrl = "http://localhost:5023";
    private readonly string _endpoint = "api/Usuarios";

    public async Task<Response<List<UsuariosDto>>> GetAllAsync()
    {
        try
        {
            var url = $"{_baseUrl}/{_endpoint}";
            using var client = new HttpClient();
            
            var response = await client.GetAsync(url);
            
            if (!response.IsSuccessStatusCode)
            {
                return new Response<List<UsuariosDto>> 
                { 
                    Errors = new List<string> { $"Error: {response.StatusCode}" } 
                };
            }
            
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<List<UsuariosDto>>>(json);
        }
        catch (Exception ex)
        {
            return new Response<List<UsuariosDto>> 
            { 
                Errors = new List<string> { $"Exception: {ex.Message}" } 
            };
        }
    }

    public async Task<Response<UsuariosDto>> GetByIdAsync(int id)
    {
        try
        {
            var url = $"{_baseUrl}/{_endpoint}/{id}";
            using var client = new HttpClient();
            
            var response = await client.GetAsync(url);
            
            if (!response.IsSuccessStatusCode)
            {
                return new Response<UsuariosDto> 
                { 
                    Errors = new List<string> { $"Error: {response.StatusCode}" } 
                };
            }
            
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<UsuariosDto>>(json);
        }
        catch (Exception ex)
        {
            return new Response<UsuariosDto> 
            { 
                Errors = new List<string> { $"Exception: {ex.Message}" } 
            };
        }
    }

    public async Task<Response<UsuariosDto>> SaveAsync(UsuariosDto usuariosDto)
    {
        try
        {
            var url = $"{_baseUrl}/{_endpoint}";
            using var client = new HttpClient();
            
            var jsonRequest = JsonConvert.SerializeObject(usuariosDto);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            
            var response = await client.PostAsync(url, content);
            
            if (!response.IsSuccessStatusCode)
            {
                return new Response<UsuariosDto> 
                { 
                    Errors = new List<string> { $"Error: {response.StatusCode}" } 
                };
            }
            
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<UsuariosDto>>(json);
        }
        catch (Exception ex)
        {
            return new Response<UsuariosDto> 
            { 
                Errors = new List<string> { $"Exception: {ex.Message}" } 
            };
        }
    }

    public async Task<Response<UsuariosDto>> UpdateAsync(UsuariosDto usuariosDto)
    {
        try
        {
            var url = $"{_baseUrl}/{_endpoint}";
            using var client = new HttpClient();
            
            var jsonRequest = JsonConvert.SerializeObject(usuariosDto);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            
            var response = await client.PutAsync(url, content);
            
            if (!response.IsSuccessStatusCode)
            {
                return new Response<UsuariosDto> 
                { 
                    Errors = new List<string> { $"Error: {response.StatusCode}" } 
                };
            }
            
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<UsuariosDto>>(json);
        }
        catch (Exception ex)
        {
            return new Response<UsuariosDto> 
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

    public async Task<Response<UsuariosDto>> AuthenticateAsync(string correo, string contrasena)
    {
        try
        {
            var url = $"{_baseUrl}/{_endpoint}/authenticate";
            using var client = new HttpClient();
            
            var authRequest = new { Correo = correo, Contrasena = contrasena };
            var jsonRequest = JsonConvert.SerializeObject(authRequest);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            
            var response = await client.PostAsync(url, content);
            
            if (!response.IsSuccessStatusCode)
            {
                return new Response<UsuariosDto> 
                { 
                    Errors = new List<string> { "Credenciales inválidas" } 
                };
            }
            
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<UsuariosDto>>(json);
        }
        catch (Exception ex)
        {
            return new Response<UsuariosDto> 
            { 
                Errors = new List<string> { $"Error de autenticación: {ex.Message}" } 
            };
        }
    }
}