using System.Net.Http.Headers;
using Gamma.System.WebSite.Services;
using Gamma.System.WebSite.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var apiBaseUrl = builder.Configuration["ApiBaseUrl"];
Console.WriteLine($"🔍 Valor de ApiBaseUrl: {apiBaseUrl}");

builder.Services.AddHttpClient("GammaAPI", client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IOrdenesService, OrdenesService>();
builder.Services.AddScoped<IModelosService, ModelosService>();
builder.Services.AddScoped<IMaquinasService, MaquinasService>();
builder.Services.AddScoped<IClientesService, ClientesService>();
builder.Services.AddScoped<IColoresService, ColoresService>();
builder.Services.AddSession();
builder.Services.AddScoped<ApiService>();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles(); 

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages(); 

app.Run();