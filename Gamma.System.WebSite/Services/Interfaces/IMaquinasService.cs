using Gamma.System.Core.Dto;
using Gamma.System.Core.Http;

namespace Gamma.System.WebSite.Services.Interfaces;

public interface IMaquinasService
{
    Task<Response<List<MaquinasDto>>> GetAllAsync();
    Task<Response<MaquinasDto>> GetByIdAsync(int id);
    Task<Response<MaquinasDto>> SaveAsync(MaquinasDto maquinaDto);
    Task<Response<MaquinasDto>> UpdateAsync(MaquinasDto maquinaDto);
    Task<Response<bool>> DeleteAsync(int id);
}