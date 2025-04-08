using Dapper;
using Dapper.Contrib.Extensions;
using Gamma.System.Api.DataAccess.Interfaces;
using Gamma.System.Api.Repositories.Interfaces;
using Gamma.System.Core.Entities;


namespace Gamma.System.Api.Repositories;

public class UsuariosRepository : IUsuariosRepository
{
    private readonly IDbContext _dbcontext;

    public UsuariosRepository(IDbContext context)
    {
        _dbcontext = context;
    }

    public async Task<Usuarios> SaveAsync(Usuarios usuarios)
    {
        usuarios.IdUsuario = await _dbcontext.Connection.InsertAsync(usuarios);
        return usuarios;
    }

    public async Task<Usuarios> UpdateAsync(Usuarios usuarios)
    {
        await _dbcontext.Connection.UpdateAsync(usuarios);
        return usuarios;
    }

    public async Task<List<Usuarios>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Usuarios WHERE IsDeleted = 0";
        
        var usuarios = await _dbcontext.Connection.QueryAsync<Usuarios>(sql);
        
        return usuarios.ToList();
    }

    public async Task<bool> DeleteAsync(int IdUsuario)
    {
        var usuarios = await GetById(IdUsuario);
        if(usuarios == null)
            return false;
        
        usuarios.IsDeleted = true;
        
        return await _dbcontext.Connection.UpdateAsync(usuarios);
    }

    public async Task<Usuarios> GetById(int IdUsuario)
    {
        var usuarios = await _dbcontext.Connection.GetAsync<Usuarios>(IdUsuario);
        
        if(usuarios == null)
            return null;
        return usuarios.IsDeleted == true ? null : usuarios;
    }
}