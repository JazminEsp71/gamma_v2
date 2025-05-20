using System.ComponentModel.DataAnnotations;
using Gamma.System.Core.Entities;

namespace Gamma.System.Core.Dto;

public class OrdenesDto : DtoBase
{
    public int Id { get; set; }
    [Required(ErrorMessage = "El ID del cliente es obligatorio")]
    [Range(1, int.MaxValue, ErrorMessage = "El ID del cliente debe ser un número positivo")]
    public int IdCliente { get; set; } // FK con Clientes

    [Required(ErrorMessage = "El ID del modelo es obligatorio")]
    [Range(1, int.MaxValue, ErrorMessage = "El ID del modelo debe ser un número positivo")]
    public int IdModelo { get; set; } // FK con Modelos
    
    [Required(ErrorMessage = "El estado de la orden es obligatorio")]
    [RegularExpression("Pendiente|En Producción|Completado|Cancelado", 
        ErrorMessage = "El estado debe ser 'Pendiente', 'En Producción', 'Completado' o 'Cancelado'")]
    public string Estado { get; set; } = "Pendiente";

    [Range(1, int.MaxValue, ErrorMessage = "El número de lote debe ser mayor que 0")]
    public int Lote { get; set; }
    
    public OrdenesDto() { }

    public OrdenesDto(Ordenes ordenes)
    {
        Id = ordenes.Id;
        IdCliente = ordenes.IdCliente;
        IdModelo = ordenes.IdModelo;
        Estado = ordenes.Estado;
        Lote = ordenes.Lote;
    }
    
}