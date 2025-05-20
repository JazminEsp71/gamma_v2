using System.ComponentModel.DataAnnotations;
using Gamma.System.Core.Entities;

namespace Gamma.System.Core.Dto;

public class UsuariosDto : DtoBase
{
    public int IdUsuario { get; set; }
    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El correo electrónico es obligatorio")]
    [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
    [StringLength(100, ErrorMessage = "El correo no puede superar los 100 caracteres")]
    public string Correo { get; set; }

    [Required(ErrorMessage = "La contraseña es obligatoria")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
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