using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MercadoAssistente.Data.Layer.Context;
using Mercado.Assistente.Domain.Entities;
using Ma.Domain.Entities;


using MercadoAssistente.Api.Services;
using Microsoft.Extensions.Primitives;

namespace Ma.MercadoAssistente.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DadosCobrancasController : ControllerBase
    {
        private DadosCobrancasService serviceDadosCobrancas;


        


        public DadosCobrancasController(IHttpContextAccessor httpContextAccessor,DefaultContext Context)
        {
               

                serviceDadosCobrancas = new DadosCobrancasService(Context);
 
                
StringValues vIdUsrUltEdicao;
                httpContextAccessor.HttpContext.Request.Headers.TryGetValue("IdUsrUltEdicao", out vIdUsrUltEdicao);
                var sIdUsrUltEdicao = vIdUsrUltEdicao.FirstOrDefault();
                if (!string.IsNullOrEmpty(sIdUsrUltEdicao)){
                                  serviceDadosCobrancas.IdUsrUltEdicao = Convert.ToInt32(sIdUsrUltEdicao);
                              }else{ serviceDadosCobrancas.IdUsrUltEdicao = 0;}
            
        }

        [HttpGet(Name ="GetDadosCobrancass")]        
        public IActionResult GetDadosCobrancass()
        {
            try
            {
                return new ObjectResult(serviceDadosCobrancas.GetAllDadosCobrancass());
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

        [HttpGet(Name ="GetDadosCobrancasById")]        
        public IActionResult GetDadosCobrancasById(long id)
        {
            try
            {
                return new ObjectResult(serviceDadosCobrancas.GetDadosCobrancasById(id));
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


        [HttpPost(Name="PostDadosCobrancas")]
        public IActionResult Post([FromBody] DadosCobrancas dadoscobrancas)
        {                   
            try
            {  
                return new ObjectResult(serviceDadosCobrancas.Post(dadoscobrancas));
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

        [HttpPut(Name="PutDadosCobrancas")]
        public IActionResult Put([FromBody] DadosCobrancas dadoscobrancas)
        {      
            try
            {  
                return new ObjectResult(serviceDadosCobrancas.Put(dadoscobrancas));
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
        
        [HttpDelete(Name="DeleteDadosCobrancas")]
        public IActionResult Delete(long id)
        {
            try
            {
                return new ObjectResult(serviceDadosCobrancas.Delete(id));
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

