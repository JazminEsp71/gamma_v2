using Gamma.System.Core.Entities;

namespace Gamma.System.Api.Repositories.Interfaces;

public interface IColoresRepository
{
    //Metodo para guardar las categorias de un producto
    Task<Colores> SaveAsync(Colores colores);
    
    //Metodo para actualizar las categorias de un producto
    Task<Colores> UpdateAsync(Colores colores);
    
    //Metodo para retornar una lista de categorias de productos
    Task<List<Colores>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias de productos que se borrara
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una categoria por el id
    Task<Colores> GetById(int id);
}