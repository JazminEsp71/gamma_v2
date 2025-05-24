using System.Net.Http;
using System.Text;
using Gamma.System.Core.Dto;
using Gamma.System.Core.Http;
using Gamma.System.WebSite.Services.Interfaces;
using Newtonsoft.Json;

namespace Gamma.System.WebSite.Services;

public class ModelosService : IModelosService
{
    private readonly string _baseUrl = "http://localhost:5023";
    private readonly string _endpoint = "apiModelos";

    public async Task<Response<List<ModelosDto>>> GetAllAsync()
    {
        var url = $"{_baseUrl}/{_endpoint}";
        using var client = new HttpClient();
        
        var response = await client.GetAsync(url);
        var json = await response.Content.ReadAsStringAsync();
        
        return JsonConvert.DeserializeObject<Response<List<ModelosDto>>>(json);
    }

    public async Task<Response<ModelosDto>> GetByIdAsync(int id)
    {
        var url = $"{_baseUrl}/{_endpoint}/{id}";
        using var client = new HttpClient();
        
        var response = await client.GetAsync(url);
        var json = await response.Content.ReadAsStringAsync();
        
        return JsonConvert.DeserializeObject<Response<ModelosDto>>(json);
    }

    public async Task<Response<ModelosDto>> SaveAsync(ModelosDto modeloDto)
    {
        var url = $"{_baseUrl}/{_endpoint}";
        using var client = new HttpClient();
        
        var jsonRequest = JsonConvert.SerializeObject(modeloDto);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
        
        var response = await client.PostAsync(url, content);
        var json = await response.Content.ReadAsStringAsync();
        
        return JsonConvert.DeserializeObject<Response<ModelosDto>>(json);
    }

    public async Task<Response<ModelosDto>> UpdateAsync(ModelosDto modeloDto)
    {
        var url = $"{_baseUrl}/{_endpoint}";
        using var client = new HttpClient();
        
        var jsonRequest = JsonConvert.SerializeObject(modeloDto);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
        
        var response = await client.PutAsync(url, content);
        var json = await response.Content.ReadAsStringAsync();
        
        return JsonConvert.DeserializeObject<Response<ModelosDto>>(json);
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