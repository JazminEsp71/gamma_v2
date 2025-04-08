using System.ComponentModel.DataAnnotations;
using Gamma.System.Core.Entities;

namespace Gamma.System.Core.Dto;

public class ClientesDto : DtoBase
{
    public int IdCliente { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El teléfono es obligatorio")]
    [Phone(ErrorMessage = "El teléfono no tiene un formato válido")]
    public string Telefono { get; set; }

    [Required(ErrorMessage = "La dirección es obligatoria")]
    [StringLength(200, ErrorMessage = "La dirección no puede superar los 200 caracteres")]
    public string Direccion { get; set; }

    public ClientesDto() { }

    public ClientesDto(Clientes clientes)
    {
        IdCliente = clientes.IdCliente;
        Nombre = clientes.Nombre;
        Telefono = clientes.Telefono;
        Direccion = clientes.Direccion;
    }
}