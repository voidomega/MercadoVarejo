using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ma.MercadoAssistente.Api.Contexto;
using Ma.MercadoAssistente.Api.Entidades;
using Ma.Domain.Entities;


using MercadoAssistente.Api.Services;
using Microsoft.Extensions.Primitives;

namespace Ma.MercadoAssistente.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EnderecoClientesController : ControllerBase
    {
        private EnderecoClientesService serviceEnderecoClientes;


        


        public EnderecoClientesController(IHttpContextAccessor httpContextAccessor,MaContext Context)
        {
               

                serviceEnderecoClientes = new EnderecoClientesService(Context);
 
                
StringValues vIdUsrUltEdicao;
                httpContextAccessor.HttpContext.Request.Headers.TryGetValue("IdUsrUltEdicao", out vIdUsrUltEdicao);
                var sIdUsrUltEdicao = vIdUsrUltEdicao.FirstOrDefault();
                if (!string.IsNullOrEmpty(sIdUsrUltEdicao)){
                                  serviceEnderecoClientes.IdUsrUltEdicao = Convert.ToInt32(sIdUsrUltEdicao);
                              }else{ serviceEnderecoClientes.IdUsrUltEdicao = 0;}
            
        }

        [HttpGet(Name ="GetEnderecoClientess")]        
        public IActionResult GetEnderecoClientess()
        {
            try
            {
                return new ObjectResult(serviceEnderecoClientes.GetAllEnderecoClientess());
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                 return BadRequest(Ma.Util.Api.NpgSqlErrorTrapper.GetError(ex));
            }           
        }

        [HttpGet(Name ="GetEnderecoClientesById")]        
        public IActionResult GetEnderecoClientesById(int id)
        {
            try
            {
                return new ObjectResult(serviceEnderecoClientes.GetEnderecoClientesById(id));
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                  return BadRequest(Ma.Util.Api.NpgSqlErrorTrapper.GetError(ex));
            }           
        }


        [HttpPost(Name="PostEnderecoClientes")]
        public IActionResult Post([FromBody] EnderecoClientes enderecoclientes)
        {                   
            try
            {  
                return new ObjectResult(serviceEnderecoClientes.Post(enderecoclientes));
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                  return BadRequest(Ma.Util.Api.NpgSqlErrorTrapper.GetError(ex));
            }     
        }

        [HttpPut(Name="PutEnderecoClientes")]
        public IActionResult Put([FromBody] EnderecoClientes enderecoclientes)
        {      
            try
            {  
                return new ObjectResult(serviceEnderecoClientes.Put(enderecoclientes));
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                  return BadRequest(Ma.Util.Api.NpgSqlErrorTrapper.GetError(ex));
            }     
        }
        
        [HttpDelete(Name="DeleteEnderecoClientes")]
        public IActionResult Delete(int id)
        {
            try
            {
                return new ObjectResult(serviceEnderecoClientes.Delete(id));
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                  return BadRequest(Ma.Util.Api.NpgSqlErrorTrapper.GetError(ex));
            }      
        }
    }
}

