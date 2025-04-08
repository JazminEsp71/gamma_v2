using Gamma.System.Core.Entities;

namespace Gamma.System.Api.Repositories.Interfaces;

public interface IUsuariosRepository
{
    //Metodo para guardar las categorias de un producto
    Task<Usuarios> SaveAsync(Usuarios usuarios);
    
    //Metodo para actualizar las categorias de un producto
    Task<Usuarios> UpdateAsync(Usuarios usuarios);
    
    //Metodo para retornar una lista de categorias de productos
    Task<List<Usuarios>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias de productos que se borrara
    Task<bool> DeleteAsync(int IdUsuario);
    
    //Metodo para obtener una categoria por el id
    Task<Usuarios> GetById(int IdUsuario);
}