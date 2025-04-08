using Gamma.System.Core.Dto;
using Dapper.Contrib.Extensions;

namespace Gamma.System.Core.Entities;

[Dapper.Contrib.Extensions.Table("usuarios")]
public class Usuarios : EntityBase
{
    [Key]
    public int IdUsuario { get; set; }
    public string Nombre { get; set; }
    public string Correo { get; set; }
    public string Contrasena { get; set; }

}