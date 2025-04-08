using Gamma.System.Core.Entities;

namespace Gamma.System.Core.Dto;

public class ModelosDto : DtoBase
{
    public int IdModelo { get; set; }
    public string Nombre { get; set; }
    public string CodigoSuela { get; set; }
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