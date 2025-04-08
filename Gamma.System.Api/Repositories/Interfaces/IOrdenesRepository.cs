using Gamma.System.Core.Entities;

namespace Gamma.System.Api.Repositories.Interfaces;

public interface IOrdenesRepository
{
    Task<Ordenes> SaveAsync(Ordenes ordenes);

    Task<Ordenes> UpdateAsync(Ordenes ordenes);

    Task<List<Ordenes>> GetAllAsync();

    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una categoria por el id
    Task<Ordenes> GetById(int id);
}