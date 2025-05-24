using System.Net.Http.Headers;
using Gamma.System.WebSite.Services;
using Gamma.System.WebSite.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
// Configuración del HttpClient
builder.Services.AddHttpClient("GammaAPI", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]);
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));
});
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IOrdenesService, OrdenesService>();
builder.Services.AddScoped<IModelosService, ModelosService>();
builder.Services.AddScoped<IMaquinasService, MaquinasService>();
builder.Services.AddSession();
builder.Services.AddScoped<ApiService>();
builder.Services.AddHttpContextAccessor();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession(); 
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapRazorPages()
    .WithStaticAssets();

app.Run();