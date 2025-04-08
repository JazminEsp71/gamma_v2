using Gamma.System.Core.Entities;

namespace Gamma.System.Core.Dto;

public class Orden_detalle_corridaDto : DtoBase
{
    public int IdDetalle { get; set; }
    public int IdOrden { get; set; } // FK con Ordenes
    public int Talla { get; set; } // Punto de la corrida numérica
    public int Cantidad { get; set; } // Cantidad solicitada en esa talla
    
    public Orden_detalle_corridaDto() { }

    public Orden_detalle_corridaDto(Orden_detalle_corrida orden_detalle_corrida)
    {
        IdDetalle = orden_detalle_corrida.IdDetalle;
        IdOrden = orden_detalle_corrida.IdOrden;
        Talla = orden_detalle_corrida.Talla;
        Cantidad = orden_detalle_corrida.Cantidad;
    }
}