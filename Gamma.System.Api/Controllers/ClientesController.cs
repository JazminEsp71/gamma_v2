using Gamma.System.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Gamma.System.Api.Repositories.Interfaces;
using Gamma.System.Core.Dto;
using Gamma.System.Core.Entities;
using Gamma.System.Core.Http;

namespace Gamma.System.Api.Controllers;

[ApiController]
[Route("api[controller]")]
public class ClientesController : ControllerBase
{
    private readonly IClientesRepository _clientesRepository;

    public ClientesController(IClientesRepository clientesRepository)
    {
        _clientesRepository = clientesRepository;
    }

    [HttpGet]
    public async Task<ActionResult<Response<List<Clientes>>>> GetAll()
    {
        var response = new Response<List<ClientesDto>>();
        var clientes = await _clientesRepository.GetAllAsync();
        response.Data = clientes.Select(c=> new ClientesDto(c)).ToList();
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<ClientesDto>>> Post([FromBody] ClientesDto clientesDto)
    {
        var response = new Response<ClientesDto>();
        var clientes = new Clientes()
        {
            Nombre = clientesDto.Nombre,
            Telefono = clientesDto.Telefono,
            Direccion = clientesDto.Direccion,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdatedDate = DateTime.Now
        };
        
        clientes = await _clientesRepository.SaveAsync(clientes);
        clientes.IdCliente = clientes.IdCliente;
        response.Data = clientesDto;
        
        return Created($"api/clientes/{clientesDto.IdCliente}", response);
    }

    [HttpGet]
    [Route("{idCliente:int}")]
    public async Task<ActionResult<Response<ClientesDto>>> GetById(int idCliente)
    {
        var response = new Response<ClientesDto>();
        var clientes = await _clientesRepository.GetById(idCliente);

        if (clientes == null)
        {
            response.Errors.Add("Client does not exists");
            return NotFound(response);
        }
        
        var clientesDto = new ClientesDto(clientes);
        response.Data = clientesDto;
        
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<ClientesDto>>> Update([FromBody] ClientesDto clientesDto)
    {
        var response = new Response<ClientesDto>();
        var clientes = await _clientesRepository.GetById(clientesDto.IdCliente);
        if (clientes == null)
        {
            response.Errors.Add("Client does not exists");
            return NotFound(response);
        }
        
        clientes.Nombre = clientesDto.Nombre;
        clientes.Telefono = clientesDto.Telefono;
        clientes.Direccion = clientesDto.Direccion;
        clientes.UpdatedBy = "";
        clientes.UpdatedDate = DateTime.Now;
        await _clientesRepository.UpdateAsync(clientes);
        
        return Ok(response);
    }

    [HttpDelete]
    [Route("{idCliente:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int idCliente)
    {
        var response = new Response<bool>();
        var result = await _clientesRepository.DeleteAsync(idCliente);
        response.Data = result;
        
        return Ok(response);
    }
    
}