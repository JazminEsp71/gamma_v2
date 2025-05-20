using System.ComponentModel.DataAnnotations;
using Gamma.System.Core.Entities;

namespace Gamma.System.Core.Dto;

public class ColoresDto : DtoBase
{
    public int Id { get; set; }
    [Required(ErrorMessage = "El código del color es obligatorio")]
    [StringLength(10, ErrorMessage = "El código del color no puede tener más de 10 caracteres")]
    public string CodigoColor { get; set; }

    [Required(ErrorMessage = "El nombre del color es obligatorio")]
    [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El código del pigmento es obligatorio")]
    [StringLength(10, ErrorMessage = "El código del pigmento no puede tener más de 10 caracteres")]
    public string CodigoPigmento { get; set; }

    [Range(0.01, 1000, ErrorMessage = "Los gramos por kg deben ser mayores a 0")]
    public decimal GramosPorKg { get; set; }

    [Required(ErrorMessage = "La base del material es obligatoria")]
    [RegularExpression("Cristal|Natural", ErrorMessage = "La base del material debe ser 'Cristal' o 'Natural'")]
    public string BaseMaterial { get; set; }

    [Required(ErrorMessage = "El código del bulto es obligatorio")]
    [StringLength(10, ErrorMessage = "El código del bulto no puede tener más de 10 caracteres")]
    public string CodigoBulto { get; set; }

    [Range(0.01, 1000, ErrorMessage = "Los Kg por bulto deben ser mayores a 0")]
    public decimal KgPorBulto { get; set; }

    [Range(0.01, 100000, ErrorMessage = "Los gramos por bulto deben ser mayores a 0")]
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