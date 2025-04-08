using Dapper;
using Dapper.Contrib.Extensions;
using Gamma.System.Api.DataAccess.Interfaces;
using Gamma.System.Api.Repositories.Interfaces;
using Gamma.System.Core.Entities;

namespace Gamma.System.Api.Repositories;

public class MaquinasRepository : IMaquinasRepository{

    private readonly IDbContext _dbcontext;

    public MaquinasRepository(IDbContext context)
    {
        _dbcontext = context;
    }

    public async Task<Maquinas> SaveAsync(Maquinas maquinas)
    {
        maquinas.Id = await _dbcontext.Connection.InsertAsync(maquinas);
        return maquinas;
    }

    public async Task<Maquinas> UpdateAsync(Maquinas maquinas)
    {
        await _dbcontext.Connection.UpdateAsync(maquinas);
        return maquinas;
    }

    public async Task<List<Maquinas>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Maquinas WHERE IsDeleted = 0";
        
        var maquinas = await _dbcontext.Connection.QueryAsync<Maquinas>(sql);
        
        return maquinas.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var maquinas = await GetById(id);
        if(maquinas == null)
            return false;
        
        maquinas.IsDeleted = true;
        
        return await _dbcontext.Connection.UpdateAsync(maquinas);
    }
    
    public async Task<Maquinas> GetById(int id)
    {
        var maquinas = await _dbcontext.Connection.GetAsync<Maquinas>(id);
        
        if(maquinas == null)
            return null;
        return maquinas.IsDeleted == true ? null : maquinas;
    }
}