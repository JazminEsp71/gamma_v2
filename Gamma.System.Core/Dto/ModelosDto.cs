using System.ComponentModel.DataAnnotations;
using Gamma.System.Core.Entities;

namespace Gamma.System.Core.Dto;

public class ModelosDto : DtoBase
{
    public int IdModelo { get; set; }
    [Required(ErrorMessage = "El nombre del modelo es obligatorio")]
    [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El código de suela es obligatorio")]
    [StringLength(30, ErrorMessage = "El código de suela no puede superar los 30 caracteres")]
    public string CodigoSuela { get; set; }

    [Required(ErrorMessage = "La corrida numérica es obligatoria")]
    [StringLength(50, ErrorMessage = "La corrida numérica no puede superar los 50 caracteres")]
    public string CorridaNumerica { get; set; }

    public bool Burbuja { get; set; } = false;
    public bool Injerto { get; set; } = false;
    public bool Plastisol { get; set; } = false;
    
    public ModelosDto() { }

    public ModelosDto(Modelos modelos)
    {
        IdModelo = modelos.IdModelo;
        Nombre = modelos.Nombre;
        CodigoSuela = modelos.CodigoSuela;
        CorridaNumerica = modelos.CorridaNumerica;
        Burbuja = modelos.Burbuja;
        Injerto = modelos.Injerto;
        Plastisol = modelos.Plastisol;
    }
}