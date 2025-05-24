using System.Net.Http;
using System.Text;
using Gamma.System.Core.Dto;
using Gamma.System.Core.Http;
using Gamma.System.WebSite.Services.Interfaces;
using Newtonsoft.Json;

namespace Gamma.System.WebSite.Services;

public class MaquinasService : IMaquinasService
{
    private readonly string _baseUrl = "http://localhost:5023";
    private readonly string _endpoint = "apiMaquinas";

    public async Task<Response<List<MaquinasDto>>> GetAllAsync()
    {
        var url = $"{_baseUrl}/{_endpoint}";
        using var client = new HttpClient();
        
        var response = await client.GetAsync(url);
        var json = await response.Content.ReadAsStringAsync();
        
        return JsonConvert.DeserializeObject<Response<List<MaquinasDto>>>(json);
    }

    public async Task<Response<MaquinasDto>> GetByIdAsync(int id)
    {
        var url = $"{_baseUrl}/{_endpoint}/{id}";
        using var client = new HttpClient();
        
        var response = await client.GetAsync(url);
        var json = await response.Content.ReadAsStringAsync();
        
        return JsonConvert.DeserializeObject<Response<MaquinasDto>>(json);
    }

    public async Task<Response<MaquinasDto>> SaveAsync(MaquinasDto maquinaDto)
    {
        var url = $"{_baseUrl}/{_endpoint}";
        using var client = new HttpClient();
        
        var jsonRequest = JsonConvert.SerializeObject(maquinaDto);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
        
        var response = await client.PostAsync(url, content);
        var json = await response.Content.ReadAsStringAsync();
        
        return JsonConvert.DeserializeObject<Response<MaquinasDto>>(json);
    }

    public async Task<Response<MaquinasDto>> UpdateAsync(MaquinasDto maquinaDto)
    {
        var url = $"{_baseUrl}/{_endpoint}";
        using var client = new HttpClient();
        
        var jsonRequest = JsonConvert.SerializeObject(maquinaDto);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
        
        var response = await client.PutAsync(url, content);
        var json = await response.Content.ReadAsStringAsync();
        
        return JsonConvert.DeserializeObject<Response<MaquinasDto>>(json);
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