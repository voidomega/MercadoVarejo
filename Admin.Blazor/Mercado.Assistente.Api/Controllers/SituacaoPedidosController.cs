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
    public class SituacaoPedidosController : ControllerBase
    {
        private SituacaoPedidosService serviceSituacaoPedidos;


        


        public SituacaoPedidosController(IHttpContextAccessor httpContextAccessor,MaContext Context)
        {
               

                serviceSituacaoPedidos = new SituacaoPedidosService(Context);
 
                
StringValues vIdUsrUltEdicao;
                httpContextAccessor.HttpContext.Request.Headers.TryGetValue("IdUsrUltEdicao", out vIdUsrUltEdicao);
                var sIdUsrUltEdicao = vIdUsrUltEdicao.FirstOrDefault();
                if (!string.IsNullOrEmpty(sIdUsrUltEdicao)){
                                  serviceSituacaoPedidos.IdUsrUltEdicao = Convert.ToInt32(sIdUsrUltEdicao);
                              }else{ serviceSituacaoPedidos.IdUsrUltEdicao = 0;}
            
        }

        [HttpGet(Name ="GetSituacaoPedidoss")]        
        public IActionResult GetSituacaoPedidoss()
        {
            try
            {
                return new ObjectResult(serviceSituacaoPedidos.GetAllSituacaoPedidoss());
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

        [HttpGet(Name ="GetSituacaoPedidosById")]        
        public IActionResult GetSituacaoPedidosById(int id)
        {
            try
            {
                return new ObjectResult(serviceSituacaoPedidos.GetSituacaoPedidosById(id));
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


        [HttpPost(Name="PostSituacaoPedidos")]
        public IActionResult Post([FromBody] SituacaoPedidos situacaopedidos)
        {                   
            try
            {  
                return new ObjectResult(serviceSituacaoPedidos.Post(situacaopedidos));
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

        [HttpPut(Name="PutSituacaoPedidos")]
        public IActionResult Put([FromBody] SituacaoPedidos situacaopedidos)
        {      
            try
            {  
                return new ObjectResult(serviceSituacaoPedidos.Put(situacaopedidos));
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
        
        [HttpDelete(Name="DeleteSituacaoPedidos")]
        public IActionResult Delete(int id)
        {
            try
            {
                return new ObjectResult(serviceSituacaoPedidos.Delete(id));
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

