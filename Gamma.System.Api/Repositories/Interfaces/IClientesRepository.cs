using Gamma.System.Core.Entities;

namespace Gamma.System.Api.Repositories.Interfaces;

public interface IClientesRepository
{
    //Metodo para guardar las categorias de un producto
    Task<Clientes> SaveAsync(Clientes clientes);
    
    //Metodo para actualizar las categorias de un producto
    Task<Clientes> UpdateAsync(Clientes clientes);
    
    //Metodo para retornar una lista de categorias de productos
    Task<List<Clientes>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias de productos que se borrara
    Task<bool> DeleteAsync(int idCliente);
    
    //Metodo para obtener una categoria por el id
    Task<Clientes> GetById(int idCliente);
}