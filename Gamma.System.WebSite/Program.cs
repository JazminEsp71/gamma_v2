using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

using Gamma.System.WebSite.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Agrega Razor Pages
builder.Services.AddRazorPages();

// ✅ 2. Registrar el IDbConnection (antes que cualquier servicio que lo use)
builder.Services.AddTransient<IDbConnection>(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    var connectionString = config.GetConnectionString("DefaultConnection");
    Console.WriteLine($"Cadena de conexión desde config: {connectionString}");
    return new MySqlConnection(connectionString);

    
});

// ✅ 3. REGISTRA TU SERVICIO AuthService (después de IDbConnection)
builder.Services.AddScoped<AuthService>();

var app = builder.Build();

// Configuración del pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages().WithStaticAssets();

app.Run();