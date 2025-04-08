using Gamma.System.Core.Entities;

namespace Gamma.System.Core.Dto;

public class UsuariosDto : DtoBase
{
    public int IdUsuario { get; set; }
    public string Nombre { get; set; }
    public string Correo { get; set; }
    public string Contrasena { get; set; }

    public UsuariosDto(){ }

    public UsuariosDto(Usuarios usuarios)
    {
        IdUsuario = usuarios.IdUsuario;
        Nombre = usuarios.Nombre;
        Correo = usuarios.Correo;
        Contrasena = usuarios.Contrasena;
    }

}