using Gamma.System.Core.Entities;

namespace Gamma.System.Core.Dto;

public class ColoresDto : DtoBase
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
    
    public ColoresDto() { }

    public ColoresDto(Colores colore)
    {
        Id = colore.Id;
        CodigoColor = colore.CodigoColor;
        Nombre = colore.Nombre;
        CodigoPigmento = colore.CodigoPigmento;
        GramosPorKg = colore.GramosPorKg;
        GramosPorBulto = colore.GramosPorBulto;
        BaseMaterial = colore.BaseMaterial;
        CodigoBulto = colore.CodigoBulto;
        KgPorBulto = colore.KgPorBulto;
        GramosPorBulto = colore.GramosPorBulto;
    }
}