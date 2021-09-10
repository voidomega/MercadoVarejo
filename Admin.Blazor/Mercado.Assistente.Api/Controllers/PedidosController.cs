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
    public class PedidosController : ControllerBase
    {
        private PedidosService servicePedidos;


        


        public PedidosController(IHttpContextAccessor httpContextAccessor,MaContext Context)
        {
               

                servicePedidos = new PedidosService(Context);
 
                
StringValues vIdUsrUltEdicao;
                httpContextAccessor.HttpContext.Request.Headers.TryGetValue("IdUsrUltEdicao", out vIdUsrUltEdicao);
                var sIdUsrUltEdicao = vIdUsrUltEdicao.FirstOrDefault();
                if (!string.IsNullOrEmpty(sIdUsrUltEdicao)){
                                  servicePedidos.IdUsrUltEdicao = Convert.ToInt32(sIdUsrUltEdicao);
                              }else{ servicePedidos.IdUsrUltEdicao = 0;}
            
        }

        [HttpGet(Name ="GetPedidoss")]        
        public IActionResult GetPedidoss()
        {
            try
            {
                return new ObjectResult(servicePedidos.GetAllPedidoss());
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

        [HttpGet(Name ="GetPedidosById")]        
        public IActionResult GetPedidosById(long id)
        {
            try
            {
                return new ObjectResult(servicePedidos.GetPedidosById(id));
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


        [HttpPost(Name="PostPedidos")]
        public IActionResult Post([FromBody] Pedidos pedidos)
        {                   
            try
            {  
                return new ObjectResult(servicePedidos.Post(pedidos));
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

        [HttpPut(Name="PutPedidos")]
        public IActionResult Put([FromBody] Pedidos pedidos)
        {      
            try
            {  
                return new ObjectResult(servicePedidos.Put(pedidos));
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
        
        [HttpDelete(Name="DeletePedidos")]
        public IActionResult Delete(long id)
        {
            try
            {
                return new ObjectResult(servicePedidos.Delete(id));
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

