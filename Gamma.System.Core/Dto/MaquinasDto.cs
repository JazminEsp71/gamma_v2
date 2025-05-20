using System.ComponentModel.DataAnnotations;
using Gamma.System.Core.Entities;

namespace Gamma.System.Core.Dto;

public class MaquinasDto : DtoBase
{
    public int Id { get; set; }
    [Required(ErrorMessage = "El nombre de la máquina es obligatorio")]
    [StringLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres")]
    public string Nombre { get; set; }

    [StringLength(50, ErrorMessage = "El nombre del operador 1 no puede superar los 50 caracteres")]
    public string Operador1 { get; set; }

    [StringLength(50, ErrorMessage = "El nombre del operador 2 no puede superar los 50 caracteres")]
    public string Operador2 { get; set; }

    [Required(ErrorMessage = "El estado de la máquina es obligatorio")]
    [RegularExpression("Disponible|En uso|Mantenimiento", ErrorMessage = "El estado debe ser 'Disponible', 'En uso' o 'Mantenimiento'")]
    public string Estado { get; set; }

    [Range(1, 1000, ErrorMessage = "La capacidad máxima debe ser mayor que 0")]
    public int CapacidadMaxima { get; set; }
    
    public MaquinasDto() { }

    public MaquinasDto(Maquinas maquinas)
    {
        Id = maquinas.Id;
        Nombre = maquinas.Nombre;
        Operador1 = maquinas.Operador1;
        Operador2 = maquinas.Operador2;
        Estado = maquinas.Estado;
        CapacidadMaxima = maquinas.CapacidadMaxima;
    }
}