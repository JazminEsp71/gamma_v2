using Gamma.System.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gamma.System.WebSite.Pages;

public class ApiTestModel : PageModel
{
    private readonly ApiService _apiService;
    
    public ApiTestModel(ApiService apiService)
    {
        _apiService = apiService;
    }
    
    public string TestResult { get; set; }
    
    public async Task OnGetAsync()
    {
        TestResult = await _apiService.TestApiConnection();
    }
}