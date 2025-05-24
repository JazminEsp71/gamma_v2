using Gamma.System.Core.Dto;
using Gamma.System.Core.Http;

namespace Gamma.System.WebSite.Services.Interfaces;

public interface IModelosService
{
    Task<Response<List<ModelosDto>>> GetAllAsync();
    Task<Response<ModelosDto>> GetByIdAsync(int id);
    Task<Response<ModelosDto>> SaveAsync(ModelosDto modeloDto);
    Task<Response<ModelosDto>> UpdateAsync(ModelosDto modeloDto);
    Task<Response<bool>> DeleteAsync(int id);
}