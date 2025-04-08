using Gamma.System.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Gamma.System.Api.Repositories.Interfaces;
using Gamma.System.Core.Dto;
using Gamma.System.Core.Entities;
using Gamma.System.Core.Http;

namespace Gamma.System.Api.Controllers;

[ApiController]
[Route("api[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly IUsuariosRepository _usuariosRepository;

    public UsuariosController(IUsuariosRepository usuariosRepository)
    {
        _usuariosRepository = usuariosRepository;
    }

    [HttpGet]
    public async Task<ActionResult<Response<List<Usuarios>>>> GetAll()
    {
        var response = new Response<List<UsuariosDto>>();
        var usuarios = await _usuariosRepository.GetAllAsync();
        response.Data = usuarios.Select(c=> new UsuariosDto(c)).ToList();
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<UsuariosDto>>> Post([FromBody] UsuariosDto usuariosDto)
    {
        var response = new Response<UsuariosDto>();
        var usuarios = new Usuarios()
        {
            Nombre = usuariosDto.Nombre,
            Correo = usuariosDto.Correo,
            Contrasena = usuariosDto.Contrasena,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdatedDate = DateTime.Now
        };
        
        usuarios = await _usuariosRepository.SaveAsync(usuarios);
        usuarios.IdUsuario = usuarios.IdUsuario;
        response.Data = usuariosDto;
        
        return Created($"api/usuarios/{usuariosDto.IdUsuario}", response);
    }

    [HttpGet]
    [Route("{idUsurio:int}")]
    public async Task<ActionResult<Response<UsuariosDto>>> GetById(int idUsuario)
    {
        var response = new Response<UsuariosDto>();
        var usuarios = await _usuariosRepository.GetById(idUsuario);

        if (usuarios == null)
        {
            response.Errors.Add("User does not exists");
            return NotFound(response);
        }
        
        var usuariosDto = new UsuariosDto(usuarios);
        response.Data = usuariosDto;
        
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<UsuariosDto>>> Update([FromBody] UsuariosDto usuariosDto)
    {
        var response = new Response<UsuariosDto>();
        var usuarios = await _usuariosRepository.GetById(usuariosDto.IdUsuario);
        if (usuarios == null)
        {
            response.Errors.Add("User does not exists");
            return NotFound(response);
        }
        
        usuarios.Nombre = usuariosDto.Nombre;
        usuarios.Correo = usuariosDto.Correo;
        usuarios.Contrasena = usuariosDto.Contrasena;
        usuarios.UpdatedBy = "";
        usuarios.UpdatedDate = DateTime.Now;
        await _usuariosRepository.UpdateAsync(usuarios);
        
        return Ok(response);
    }

    [HttpDelete]
    [Route("{idUsuario:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int idUsuario)
    {
        var response = new Response<bool>();
        var result = await _usuariosRepository.DeleteAsync(idUsuario);
        response.Data = result;
        
        return Ok(response);
    }
    
}