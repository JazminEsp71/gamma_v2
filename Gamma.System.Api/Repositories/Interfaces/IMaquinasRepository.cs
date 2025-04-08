using Gamma.System.Core.Entities;

namespace Gamma.System.Api.Repositories.Interfaces;

public interface IMaquinasRepository{
    
    Task<Maquinas> SaveAsync(Maquinas maquinas);

    Task<Maquinas> UpdateAsync(Maquinas maquinas);

    Task<List<Maquinas>> GetAllAsync();

    Task<bool> DeleteAsync(int id);

    Task<Maquinas> GetById(int id);
}