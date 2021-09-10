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
    public class MarcasController : ControllerBase
    {
        private MarcasService serviceMarcas;


        


        public MarcasController(IHttpContextAccessor httpContextAccessor,DefaultContext Context)
        {
               

                serviceMarcas = new MarcasService(Context);
 
                
StringValues vIdUsrUltEdicao;
                httpContextAccessor.HttpContext.Request.Headers.TryGetValue("IdUsrUltEdicao", out vIdUsrUltEdicao);
                var sIdUsrUltEdicao = vIdUsrUltEdicao.FirstOrDefault();
                if (!string.IsNullOrEmpty(sIdUsrUltEdicao)){
                                  serviceMarcas.IdUsrUltEdicao = Convert.ToInt32(sIdUsrUltEdicao);
                              }else{ serviceMarcas.IdUsrUltEdicao = 0;}
            
        }

        [HttpGet(Name ="GetMarcass")]        
        public IActionResult GetMarcass()
        {
            try
            {
                return new ObjectResult(serviceMarcas.GetAllMarcass());
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

        [HttpGet(Name ="GetMarcasById")]        
        public IActionResult GetMarcasById(int id)
        {
            try
            {
                return new ObjectResult(serviceMarcas.GetMarcasById(id));
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


        [HttpPost(Name="PostMarcas")]
        public IActionResult Post([FromBody] Marcas marcas)
        {                   
            try
            {  
                return new ObjectResult(serviceMarcas.Post(marcas));
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

        [HttpPut(Name="PutMarcas")]
        public IActionResult Put([FromBody] Marcas marcas)
        {      
            try
            {  
                return new ObjectResult(serviceMarcas.Put(marcas));
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
        
        [HttpDelete(Name="DeleteMarcas")]
        public IActionResult Delete(int id)
        {
            try
            {
                return new ObjectResult(serviceMarcas.Delete(id));
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

