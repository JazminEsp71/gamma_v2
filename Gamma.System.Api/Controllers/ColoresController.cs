using Gamma.System.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Gamma.System.Api.Repositories.Interfaces;
using Gamma.System.Core.Dto;
using Gamma.System.Core.Entities;
using Gamma.System.Core.Http;

namespace Gamma.System.Api.Controllers;

[ApiController]
[Route("api[controller]")]
public class ColoresController : ControllerBase
{
    private readonly IColoresRepository _coloresRepository;

    public ColoresController(IColoresRepository coloresRepository)
    {
        _coloresRepository = coloresRepository;
    }

    [HttpGet]
    public async Task<ActionResult<Response<List<Colores>>>> GetAll()
    {
        var response = new Response<List<ColoresDto>>();
        var colores = await _coloresRepository.GetAllAsync();
        response.Data = colores.Select(c => new ColoresDto(c)).ToList();
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<ColoresDto>>> Post([FromBody] ColoresDto coloresDto)
    {
        var response = new Response<ColoresDto>();
        var colores = new Colores()
        {
            CodigoColor = coloresDto.CodigoColor,
            Nombre = coloresDto.Nombre,
            CodigoPigmento = coloresDto.CodigoPigmento,
            GramosPorKg = coloresDto.GramosPorKg,
            BaseMaterial = coloresDto.BaseMaterial,
            CodigoBulto = coloresDto.CodigoBulto,
            GramosPorBulto = coloresDto.GramosPorBulto,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdatedDate = DateTime.Now
        };
        
        colores = await _coloresRepository.SaveAsync(colores);
        colores.Id = coloresDto.Id;
        response.Data = coloresDto;
        
        return Created($"api/colores/{coloresDto.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<ColoresDto>>> GetById(int id)
    {
        var response = new Response<ColoresDto>();
        var colores = await _coloresRepository.GetById(id);

        if (colores == null)
        {
            response.Errors.Add("Colores does not exist");
            return NotFound(response);
        }
        
        var coloresDto = new ColoresDto(colores);
        response.Data = coloresDto;
        
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<ColoresDto>>> Update([FromBody] ColoresDto coloresDto)
    {
        var response = new Response<ColoresDto>();
        var colores = await _coloresRepository.GetById(coloresDto.Id);
        if (colores == null)
        {
            response.Errors.Add("Colores does not exist");
            return NotFound(response);
        }

        colores.CodigoColor = coloresDto.CodigoColor;
        colores.Nombre = coloresDto.Nombre;
        colores.CodigoPigmento = coloresDto.CodigoPigmento;
        colores.GramosPorKg = coloresDto.GramosPorKg;
        colores.BaseMaterial = coloresDto.BaseMaterial;
        colores.CodigoBulto = coloresDto.CodigoBulto;
        colores.GramosPorBulto = coloresDto.GramosPorBulto;
        colores.UpdatedBy = "";
        colores.UpdatedDate = DateTime.Now;
        await _coloresRepository.UpdateAsync(colores);
        
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        var result = await _coloresRepository.DeleteAsync(id);
        response.Data = result;
        
        return Ok(response);
    }
}