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
    private readonly string _baseUrl = "http://localhost:5023";
    private readonly string _endpoint = "apiOrdenes";

    public async Task<Response<List<OrdenesDto>>> GetAllAsync()
    {
        var url = $"{_baseUrl}/{_endpoint}";
        using var client = new HttpClient();
        
        var response = await client.GetAsync(url);
        var json = await response.Content.ReadAsStringAsync();
        
        return JsonConvert.DeserializeObject<Response<List<OrdenesDto>>>(json);
    }

    public async Task<Response<OrdenesDto>> GetByIdAsync(int id)
    {
        var url = $"{_baseUrl}/{_endpoint}/{id}";
        using var client = new HttpClient();
        
        var response = await client.GetAsync(url);
        var json = await response.Content.ReadAsStringAsync();
        
        return JsonConvert.DeserializeObject<Response<OrdenesDto>>(json);
    }

    public async Task<Response<OrdenesDto>> SaveAsync(OrdenesDto ordenDto)
    {
        var url = $"{_baseUrl}/{_endpoint}";
        using var client = new HttpClient();
    
        var jsonRequest = JsonConvert.SerializeObject(ordenDto);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
    
        try
        {
            var response = await client.PostAsync(url, content);
            var responseContent = await response.Content.ReadAsStringAsync();
        
            // Verifica si la respuesta es JSON válido
            if (IsValidJson(responseContent))
            {
                return JsonConvert.DeserializeObject<Response<OrdenesDto>>(responseContent);
            }
            else
            {
                // Si no es JSON válido, devuelve un objeto de respuesta con el mensaje de error
                return new Response<OrdenesDto>
                {
                    Data = null,
                    Message = responseContent,
                    Errors = new List<string> { "La API devolvió una respuesta no esperada" }
                };
            }
        }
        catch (Exception ex)
        {
            return new Response<OrdenesDto>
            {
                Data = null,
                Message = "Error al conectar con la API",
                Errors = new List<string> { ex.Message }
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
                var obj = JToken.Parse(strInput);
                return true;
            }
            catch
            {
                return false;
            }
        }
        return false;
    }

    public async Task<Response<OrdenesDto>> UpdateAsync(OrdenesDto ordenDto)
    {
        var url = $"{_baseUrl}/{_endpoint}";
        using var client = new HttpClient();
        
        var jsonRequest = JsonConvert.SerializeObject(ordenDto);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
        
        var response = await client.PutAsync(url, content);
        var json = await response.Content.ReadAsStringAsync();
        
        return JsonConvert.DeserializeObject<Response<OrdenesDto>>(json);
    }

    public async Task<Response<bool>> DeleteAsync(int id)
    {
        var url = $"{_baseUrl}/{_endpoint}/{id}";
        using var client = new HttpClient();
        
        var response = await client.DeleteAsync(url);
        var json = await response.Content.ReadAsStringAsync();
        
        return JsonConvert.DeserializeObject<Response<bool>>(json);
    }
}