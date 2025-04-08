using Gamma.System.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Gamma.System.Api.Repositories.Interfaces;
using Gamma.System.Core.Dto;
using Gamma.System.Core.Entities;
using Gamma.System.Core.Http;

namespace Gamma.System.Api.Controllers;

[ApiController]
[Route("api[controller]")]

public class OrdenesController : ControllerBase
{
    private readonly IOrdenesRepository _ordenesRepository;

    public OrdenesController(IOrdenesRepository ordenesRepository){
        _ordenesRepository = ordenesRepository;
    }

    [HttpGet]
    public async Task<ActionResult<Response<List<Ordenes>>>> GetAll()
    {
        var response = new Response<List<OrdenesDto>>();
        var ordenes = await _ordenesRepository.GetAllAsync();
        response.Data = 
            ordenes.Select(c=> new OrdenesDto(c)).ToList();
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<OrdenesDto>>> Post([FromBody] OrdenesDto ordenesDto)
    {
        var response = new Response<OrdenesDto>();
        var ordenes = new Ordenes()
        {
            IdCliente = ordenesDto.IdCliente,
            Id = ordenesDto.Id,
            Estado = ordenesDto.Estado,
            Lote = ordenesDto.Lote
        };
        
        ordenes = await _ordenesRepository.SaveAsync(ordenes);
        ordenes.Id = ordenes.Id;
        response.Data = ordenesDto;
        
        return Created($"api/ordenes/{ordenesDto.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<OrdenesDto>>> GetById(int id)
    {
        var response = new Response<OrdenesDto>();
        var ordenes = await _ordenesRepository.GetById(id);

        if (ordenes == null)
        {
            response.Errors.Add(("Order does not exists"));
            return NotFound(response);
        }
        
        var ordenesDto = new OrdenesDto(ordenes);
        response.Data = ordenesDto;
        
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<OrdenesDto>>> Update([FromBody] OrdenesDto ordenesDto)
    {
        var response = new Response<OrdenesDto>();
        var ordenes = await _ordenesRepository.GetById(ordenesDto.Id);
        if (ordenes == null)
        {
            response.Errors.Add(("Order does not exists"));
            return NotFound(response);
        }
        
        ordenes.IdCliente = ordenesDto.IdCliente;
        ordenes.Id = ordenesDto.Id;
        ordenes.Estado = ordenesDto.Estado;
        ordenes.Lote = ordenesDto.Lote;
        ordenes.UpdatedBy = "";
        ordenes.UpdatedDate = DateTime.Now;
        await _ordenesRepository.UpdateAsync(ordenes);
        
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        var result = await _ordenesRepository.DeleteAsync(id);
        response.Data = result;
        
        return Ok(response);
    }
    
}