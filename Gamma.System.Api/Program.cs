using Gamma.System.Api.DataAccess;
using Gamma.System.Api.DataAccess.Interfaces;
using Gamma.System.Api.Repositories;
using Gamma.System.Api.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddSingleton<IClientesRepository, ClientesRepository>();
builder.Services.AddSingleton<IColoresRepository, ColoresRepository>();
builder.Services.AddSingleton<IModelosRepository, ModelosRepository>();
builder.Services.AddSingleton<IMaquinasRepository, MaquinasRepository>();
builder.Services.AddSingleton<IOrdenesRepository, OrdenesRepository>();
builder.Services.AddSingleton<IUsuariosRepository, UsuariosRepository>();

builder.Services.AddSingleton<IDbContext, DbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
