using Microsoft.AspNetCore.Mvc;
using Gamma.System.Api.Repositories.Interfaces;
using Gamma.System.Core.Dto;
using Gamma.System.Core.Entities;
using Gamma.System.Core.Http;

namespace Gamma.System.Api.Controllers;

[ApiController]
[Route("api[controller]")]
public class ModelosController : ControllerBase
{
    private readonly IModelosRepository _modelosRepository;

    public ModelosController(IModelosRepository modelosRepository)
    {
        _modelosRepository = modelosRepository;
    }

    [HttpGet]
    public async Task<ActionResult<Response<List<Modelos>>>> GetAll()
    {
        var response = new Response<List<ModelosDto>>();
        var modelos = await _modelosRepository.GetAllAsync();
        response.Data = 
            modelos.Select(c => new ModelosDto(c)).ToList();
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<ModelosDto>>> Post([FromBody] ModelosDto modelosDto)
    {
        var response = new Response<ModelosDto>();
        var modelos = new Modelos()
        {
            Nombre = modelosDto.Nombre,
            CodigoSuela = modelosDto.CodigoSuela,
            CorridaNumerica = modelosDto.CorridaNumerica,
            Burbuja = modelosDto.Burbuja,
            Injerto = modelosDto.Injerto,
            Plastisol = modelosDto.Plastisol,
        };
        
        modelos = await _modelosRepository.SaveAsync(modelos);
        modelos.IdModelo = modelosDto.IdModelo;
        response.Data = modelosDto;
        
        return Created($"api/modelos/{modelosDto.IdModelo}", response);
    }

    [HttpGet]
    [Route("{idModelo:int}")]
    public async Task<ActionResult<Response<ModelosDto>>> GetById(int idModelo)
    {
        var response = new Response<ModelosDto>();
        var modelos = await _modelosRepository.GetById(idModelo);

        if (modelos == null)
        {
            response.Errors.Add("Models does not exists");
            return NotFound(response);
        }
        
        var modelosDto = new ModelosDto(modelos);
        response.Data = modelosDto;
        
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<ModelosDto>>> Update([FromBody] ModelosDto modelosDto)
    {
        var response = new Response<ModelosDto>();
        var modelos = await _modelosRepository.GetById(modelosDto.IdModelo);
        if (modelos == null)
        {
            response.Errors.Add("Models does not exists");
            return NotFound(response);
        }
        
        modelos.Nombre = modelosDto.Nombre;
        modelos.CodigoSuela = modelosDto.CodigoSuela;
        modelos.CorridaNumerica = modelosDto.CorridaNumerica;
        modelos.Burbuja = modelosDto.Burbuja;
        modelos.Injerto = modelosDto.Injerto;
        modelos.Plastisol = modelosDto.Plastisol;
        modelos.UpdatedBy = "";
        modelos.UpdatedDate = DateTime.Now;
        await _modelosRepository.UpdateAsync(modelos);
        
        return Ok(response);
    }

    [HttpDelete]
    [Route("{idModelo:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int idModelo)
    {
        var response = new Response<bool>();
        var result = await _modelosRepository.DeleteAsync(idModelo);
        response.Data = result;
        
        return Ok(response);
    }
}