using System.ComponentModel.DataAnnotations.Schema;
using Dapper.Contrib.Extensions;

namespace Gamma.System.Core.Entities;
[Dapper.Contrib.Extensions.Table("clientes")]
public class Clientes : EntityBase
{
    [Key]
    public int IdCliente { get; set; }
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public string Direccion { get; set; }
}