using Gamma.System.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Gamma.System.Api.Repositories.Interfaces;
using Gamma.System.Core.Dto;
using Gamma.System.Core.Entities;
using Gamma.System.Core.Http;

namespace Gamma.System.Api.Controllers;

[ApiController]
[Route("api[controller]")]
public class MaquinasController : ControllerBase
{
    private readonly IMaquinasRepository _maquinasRepository;

    public MaquinasController(IMaquinasRepository maquinasRepository)
    {
        _maquinasRepository = maquinasRepository;
    }

    [HttpGet]
    public async Task<ActionResult<Response<List<Maquinas>>>> GetAll()
    {
        var response = new Response<List<MaquinasDto>>();
        var maquinas = await _maquinasRepository.GetAllAsync();
        response.Data = 
            maquinas.Select(c=> new MaquinasDto(c)).ToList();
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<MaquinasDto>>> Post([FromBody] MaquinasDto maquinasDto)
    {
        var response = new Response<MaquinasDto>();
        var maquinas = new Maquinas()
        {
            Nombre = maquinasDto.Nombre,
            Operador1 = maquinasDto.Operador1,
            Operador2 = maquinasDto.Operador2,
            Estado = maquinasDto.Estado,
            CapacidadMaxima = maquinasDto.CapacidadMaxima,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdatedDate = DateTime.Now
        };
        
        maquinas = await _maquinasRepository.SaveAsync(maquinas);
        maquinas.Id = maquinas.Id;
        response.Data = maquinasDto;
        
        return Created($"api/maquinas/{maquinasDto.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<MaquinasDto>>> GetById(int id)
    {
        var response = new Response<MaquinasDto>();
        var maquinas = await _maquinasRepository.GetById(id);

        if (maquinas == null)
        {
            response.Errors.Add("Machine does not exists");
            return NotFound(response);
        }
        
        var maquinasDto = new MaquinasDto(maquinas);
        response.Data = maquinasDto;
        
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<MaquinasDto>>> Update([FromBody] MaquinasDto maquinasDto)
    {
        var response = new Response<MaquinasDto>();
        var maquinas = await _maquinasRepository.GetById(maquinasDto.Id);
        if (maquinas == null)
        {
            response.Errors.Add("Machines does not exists");
            return NotFound(response);
        }
        
        maquinas.Nombre = maquinasDto.Nombre;
        maquinas.Operador1 = maquinasDto.Operador1;
        maquinas.Operador2 = maquinasDto.Operador2;
        maquinas.Estado = maquinasDto.Estado;
        maquinas.CapacidadMaxima = maquinasDto.CapacidadMaxima;
        maquinas.UpdatedBy = "";
        maquinas.UpdatedDate = DateTime.Now;
        await _maquinasRepository.UpdateAsync(maquinas);
        
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        var result = await _maquinasRepository.DeleteAsync(id);
        response.Data = result;
        
        return Ok(response);
    }
    
}