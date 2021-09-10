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
    public class HistoricoPedidosController : ControllerBase
    {
        private HistoricoPedidosService serviceHistoricoPedidos;


        


        public HistoricoPedidosController(IHttpContextAccessor httpContextAccessor,MaContext Context)
        {
               

                serviceHistoricoPedidos = new HistoricoPedidosService(Context);
 
                
StringValues vIdUsrUltEdicao;
                httpContextAccessor.HttpContext.Request.Headers.TryGetValue("IdUsrUltEdicao", out vIdUsrUltEdicao);
                var sIdUsrUltEdicao = vIdUsrUltEdicao.FirstOrDefault();
                if (!string.IsNullOrEmpty(sIdUsrUltEdicao)){
                                  serviceHistoricoPedidos.IdUsrUltEdicao = Convert.ToInt32(sIdUsrUltEdicao);
                              }else{ serviceHistoricoPedidos.IdUsrUltEdicao = 0;}
            
        }

        [HttpGet(Name ="GetHistoricoPedidoss")]        
        public IActionResult GetHistoricoPedidoss()
        {
            try
            {
                return new ObjectResult(serviceHistoricoPedidos.GetAllHistoricoPedidoss());
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

        [HttpGet(Name ="GetHistoricoPedidosById")]        
        public IActionResult GetHistoricoPedidosById(int id)
        {
            try
            {
                return new ObjectResult(serviceHistoricoPedidos.GetHistoricoPedidosById(id));
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


        [HttpPost(Name="PostHistoricoPedidos")]
        public IActionResult Post([FromBody] HistoricoPedidos historicopedidos)
        {                   
            try
            {  
                return new ObjectResult(serviceHistoricoPedidos.Post(historicopedidos));
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

        [HttpPut(Name="PutHistoricoPedidos")]
        public IActionResult Put([FromBody] HistoricoPedidos historicopedidos)
        {      
            try
            {  
                return new ObjectResult(serviceHistoricoPedidos.Put(historicopedidos));
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
        
        [HttpDelete(Name="DeleteHistoricoPedidos")]
        public IActionResult Delete(int id)
        {
            try
            {
                return new ObjectResult(serviceHistoricoPedidos.Delete(id));
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

