using Gamma.System.Core.Dto;
using Gamma.System.Core.Http;

namespace Gamma.System.WebSite.Services.Interfaces;

public interface IOrdenesService
{
    Task<Response<List<OrdenesDto>>> GetAllAsync();
    Task<Response<OrdenesDto>> GetByIdAsync(int id);
    Task<Response<OrdenesDto>> SaveAsync(OrdenesDto ordenDto);
    Task<Response<OrdenesDto>> UpdateAsync(OrdenesDto ordenDto);
    Task<Response<bool>> DeleteAsync(int id);
}