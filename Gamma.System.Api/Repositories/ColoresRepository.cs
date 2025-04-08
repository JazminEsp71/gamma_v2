using System.Drawing;
using Dapper;
using Dapper.Contrib.Extensions;
using Gamma.System.Api.DataAccess.Interfaces;
using Gamma.System.Api.Repositories.Interfaces;
using Gamma.System.Core.Entities;

namespace Gamma.System.Api.Repositories;

public class ColoresRepository : IColoresRepository
{
    private readonly IDbContext _dbcontext;

    public ColoresRepository(IDbContext context)
    {
        _dbcontext = context;
    }

    public async Task<Colores> SaveAsync(Colores colores)
    {
        colores.Id = await _dbcontext.Connection.InsertAsync(colores);
        return colores;
    }

    public async Task<Colores> UpdateAsync(Colores colores)
    {
        await _dbcontext.Connection.UpdateAsync(colores);
        return colores;
    }

    public async Task<List<Colores>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Colores WHERE IsDeleted = 0 ";
        
        var colores = await _dbcontext.Connection.QueryAsync<Colores>(sql);
        
        return colores.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var colores = await GetById(id);
        if(colores == null)
               return false;
          
          colores.IsDeleted = true; 
           
         return await _dbcontext.Connection.UpdateAsync(colores);
    }

    public async Task<Colores> GetById(int id)
    {
        var colores = await _dbcontext.Connection.GetAsync<Colores>(id);
        
        if(colores == null)
            return null;
        return colores.IsDeleted == true ? null : colores;
    }

}