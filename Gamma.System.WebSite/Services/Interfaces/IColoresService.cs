using Gamma.System.Core.Dto;
using Gamma.System.Core.Http;

namespace Gamma.System.WebSite.Services.Interfaces;

public interface IColoresService
{
    Task<Response<List<ColoresDto>>> GetAllAsync();
    Task<Response<ColoresDto>> GetByIdAsync(int id);
    Task<Response<ColoresDto>> SaveAsync(ColoresDto coloresDto);
    Task<Response<ColoresDto>> UpdateAsync(ColoresDto coloresDto);
    Task<Response<bool>> DeleteAsync(int id);
}