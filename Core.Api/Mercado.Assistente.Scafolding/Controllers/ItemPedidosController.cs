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
    public class ItemPedidosController : ControllerBase
    {
        private ItemPedidosService serviceItemPedidos;


        


        public ItemPedidosController(IHttpContextAccessor httpContextAccessor,DefaultContext Context)
        {
               

                serviceItemPedidos = new ItemPedidosService(Context);
 
                
StringValues vIdUsrUltEdicao;
                httpContextAccessor.HttpContext.Request.Headers.TryGetValue("IdUsrUltEdicao", out vIdUsrUltEdicao);
                var sIdUsrUltEdicao = vIdUsrUltEdicao.FirstOrDefault();
                if (!string.IsNullOrEmpty(sIdUsrUltEdicao)){
                                  serviceItemPedidos.IdUsrUltEdicao = Convert.ToInt32(sIdUsrUltEdicao);
                              }else{ serviceItemPedidos.IdUsrUltEdicao = 0;}
            
        }

        [HttpGet(Name ="GetItemPedidoss")]        
        public IActionResult GetItemPedidoss()
        {
            try
            {
                return new ObjectResult(serviceItemPedidos.GetAllItemPedidoss());
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

        [HttpGet(Name ="GetItemPedidosById")]        
        public IActionResult GetItemPedidosById(long id)
        {
            try
            {
                return new ObjectResult(serviceItemPedidos.GetItemPedidosById(id));
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


        [HttpPost(Name="PostItemPedidos")]
        public IActionResult Post([FromBody] ItemPedidos itempedidos)
        {                   
            try
            {  
                return new ObjectResult(serviceItemPedidos.Post(itempedidos));
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

        [HttpPut(Name="PutItemPedidos")]
        public IActionResult Put([FromBody] ItemPedidos itempedidos)
        {      
            try
            {  
                return new ObjectResult(serviceItemPedidos.Put(itempedidos));
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
        
        [HttpDelete(Name="DeleteItemPedidos")]
        public IActionResult Delete(long id)
        {
            try
            {
                return new ObjectResult(serviceItemPedidos.Delete(id));
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

