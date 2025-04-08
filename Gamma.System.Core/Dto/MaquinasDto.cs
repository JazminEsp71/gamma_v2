using Gamma.System.Core.Entities;

namespace Gamma.System.Core.Dto;

public class MaquinasDto : DtoBase
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Operador1 { get; set; }
    public string Operador2 { get; set; }
    public string Estado { get; set; }
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