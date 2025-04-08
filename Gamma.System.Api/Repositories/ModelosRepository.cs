using Dapper;
using Dapper.Contrib.Extensions;
using Gamma.System.Api.DataAccess.Interfaces;
using Gamma.System.Api.Repositories.Interfaces;
using Gamma.System.Core.Entities;

namespace Gamma.System.Api.Repositories;

public class ModelosRepository : IModelosRepository
{
    private readonly IDbContext _dbcontext;

    public ModelosRepository(IDbContext context)
    {
        _dbcontext = context;
    }

    public async Task<Modelos> SaveAsync(Modelos modelos)
    {
        modelos.IdModelo = await _dbcontext.Connection.InsertAsync(modelos);
        return modelos;
    }

    public async Task<Modelos> UpdateAsync(Modelos modelos)
    {
        await _dbcontext.Connection.UpdateAsync(modelos);
        return modelos;
    }

    public async Task<List<Modelos>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Modelos WHERE IsDeleted = 0 ";
        
        var modelos = await _dbcontext.Connection.QueryAsync<Modelos>(sql);
        
        return modelos.ToList();
    }

    public async Task<bool> DeleteAsync(int idModelo)
    {
        var modelos = await GetById(idModelo);
        if(modelos == null)
            return false;

        modelos.IsDeleted = true;

        return await _dbcontext.Connection.UpdateAsync(modelos);
    }

    public async Task<Modelos> GetById(int idModelo)
    {
        var modelos = await _dbcontext.Connection.GetAsync<Modelos>(idModelo);
        
        if(modelos == null)
            return null;
        return modelos.IsDeleted == true ? null : modelos;
    }
}