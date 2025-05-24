using Gamma.System.Core.Dto;
using Gamma.System.Core.Http;

namespace Gamma.System.WebSite.Services.Interfaces;

public interface IUsuariosService
{
    Task<Response<List<UsuariosDto>>> GetAllAsync();
    Task<Response<UsuariosDto>> GetByIdAsync(int id);
    Task<Response<UsuariosDto>> SaveAsync(UsuariosDto usuariosDto);
    Task<Response<UsuariosDto>> UpdateAsync(UsuariosDto usuariosDto);
    Task<Response<bool>> DeleteAsync(int id);
    Task<Response<UsuariosDto>> AuthenticateAsync(string correo, string contrasena);
}