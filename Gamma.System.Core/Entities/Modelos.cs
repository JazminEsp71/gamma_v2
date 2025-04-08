using Dapper.Contrib.Extensions;

namespace Gamma.System.Core.Entities;

[Dapper.Contrib.Extensions.Table("modelos")]

public class Modelos : EntityBase
{
    [Key]
    public int IdModelo { get; set; }
    public string Nombre { get; set; }
    public string CodigoSuela { get; set; }
    public string CorridaNumerica { get; set; }
    public bool Burbuja { get; set; } = false;
    public bool Injerto { get; set; } = false;
    public bool Plastisol { get; set; } = false;
}