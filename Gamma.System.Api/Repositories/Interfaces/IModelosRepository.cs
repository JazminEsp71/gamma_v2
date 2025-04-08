using Gamma.System.Core.Entities;

namespace Gamma.System.Api.Repositories.Interfaces;

public interface IModelosRepository
{
    //Metodo para guardar las categorias de un producto
    Task<Modelos> SaveAsync(Modelos modelos);
    
    //Metodo para actualizar las categorias de un producto
    Task<Modelos> UpdateAsync(Modelos modelos);
    
    //Metodo para retornar una lista de categorias de productos
    Task<List<Modelos>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias de productos que se borrara
    Task<bool> DeleteAsync(int idModelo);
    
    //Metodo para obtener una categoria por el id
    Task<Modelos> GetById(int idModelo);
    
}