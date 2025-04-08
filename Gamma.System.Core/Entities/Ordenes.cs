namespace Gamma.System.Core.Entities;
[Dapper.Contrib.Extensions.Table("ordenes")]

public class Ordenes: EntityBase
{
    public int Id { get; set; }
    public int IdCliente { get; set; } // FK con Clientes
    public int IdModelo { get; set; } // FK con Modelos
    public string Estado { get; set; } = "Pendiente"; // Puede ser 'Pendiente', 'En Producción', 'Completado', 'Cancelado'
    
    public int Lote { get; set; }
}