namespace Gamma.System.Core.Entities;
[Dapper.Contrib.Extensions.Table("colores")]
public class Colores: EntityBase
{
    public int Id { get; set; }
    public string CodigoColor { get; set; }
    public string Nombre { get; set; }
    public string CodigoPigmento { get; set; }
    public decimal GramosPorKg { get; set; }
    public string BaseMaterial { get; set; } // 'Cristal' o 'Natural'
    public string CodigoBulto { get; set; }
    public decimal KgPorBulto { get; set; }
    public decimal GramosPorBulto { get; set; }
}