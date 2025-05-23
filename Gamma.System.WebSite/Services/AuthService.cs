using System.Data;
using Dapper;
using Gamma.System.Core.Entities;

namespace Gamma.System.WebSite.Services;

public class AuthService
{
    private readonly IDbConnection _connection;

    public AuthService(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<bool> ValidarUsuarioAsync(string nombre, string contrasena)
    {
        var sql = "SELECT COUNT(1) FROM usuarios WHERE Nombre = @nombre AND Contrasena = @contrasena AND IsDeleted = 0";
        var existe = await _connection.ExecuteScalarAsync<bool>(sql, new { Nombre = nombre, Contrasena = contrasena });
        return existe;
    }
}
