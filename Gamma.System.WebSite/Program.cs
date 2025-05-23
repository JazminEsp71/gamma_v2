using Gamma.System.WebSite.Services;

var builder = WebApplication.CreateBuilder(args);
// Configuración del HttpClient
builder.Services.AddHttpClient("GammaAPI", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]);
});
// Add services to the container.
builder.Services.AddRazorPages();
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