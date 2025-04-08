namespace Gamma.System.Core.Entities;
[Dapper.Contrib.Extensions.Table("maquinas")]

public class Maquinas: EntityBase
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Operador1 { get; set; }
    public string Operador2 { get; set; }
    public string Estado { get; set; }
    public int CapacidadMaxima { get; set; }
}