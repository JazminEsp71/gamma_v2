namespace Gamma.System.Core.Entities;

public class Orden_detalle_corrida: EntityBase
{
    public int IdDetalle { get; set; }
    public int IdOrden { get; set; } // FK con Ordenes
    public int Talla { get; set; } // Punto de la corrida numérica
    public int Cantidad { get; set; } // Cantidad solicitada en esa talla
}