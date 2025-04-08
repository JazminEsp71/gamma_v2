using Dapper;
using Dapper.Contrib.Extensions;
using Gamma.System.Api.DataAccess.Interfaces;
using Gamma.System.Api.Repositories.Interfaces;
using Gamma.System.Core.Entities;

namespace Gamma.System.Api.Repositories;

public class OrdenesRepository : IOrdenesRepository
{
    private readonly IDbContext _dbcontext;

    public OrdenesRepository(IDbContext context)
    {
        _dbcontext = context;
    }

    public async Task<Ordenes> SaveAsync(Ordenes ordenes)
    {
        ordenes.Id = await _dbcontext.Connection.InsertAsync(ordenes);
        return ordenes;
    }

    public async Task<Ordenes> UpdateAsync (Ordenes ordenes)
    {
        await _dbcontext.Connection.UpdateAsync(ordenes);
        return ordenes;
    }

    public async Task<List<Ordenes>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Ordenes WHERE IsDeleted = 0";
        
        var ordenes = await _dbcontext.Connection.QueryAsync<Ordenes>(sql);
        
        return ordenes.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var ordenes = await GetById(id);
        if(ordenes == null)
            return false;
        
        ordenes.IsDeleted = true;
        
        return await _dbcontext.Connection.UpdateAsync(ordenes);
    }

    public async Task<Ordenes> GetById(int id)
    {
        var ordenes = await _dbcontext.Connection.GetAsync<Ordenes>(id);
        
        if(ordenes == null)
            return null;
        return ordenes.IsDeleted == true ? null : ordenes;
    }
}