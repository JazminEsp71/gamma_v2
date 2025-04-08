using Gamma.System.Core.Entities;

namespace Gamma.System.Core.Dto;

public class OrdenesDto : DtoBase
{
    public int Id { get; set; }
    public int IdCliente { get; set; } // FK con Clientes
    public int IdModelo { get; set; } // FK con Modelos
    public string Estado { get; set; } = "Pendiente"; // Puede ser 'Pendiente', 'En Producción', 'Completado', 'Cancelado'
    
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