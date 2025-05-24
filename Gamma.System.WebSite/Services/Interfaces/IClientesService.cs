using Gamma.System.Core.Dto;
using Gamma.System.Core.Http;

namespace Gamma.System.WebSite.Services.Interfaces;

public interface IClientesService
{
    Task<Response<List<ClientesDto>>> GetAllAsync();
    Task<Response<ClientesDto>> GetByIdAsync(int idCliente);
    Task<Response<ClientesDto>> SaveAsync(ClientesDto clientesDto);
    Task<Response<ClientesDto>> UpdateAsync(ClientesDto clientesDto);
    Task<Response<bool>> DeleteAsync(int idCliente);
}