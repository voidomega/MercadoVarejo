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
    public class PromocaoProdutosController : ControllerBase
    {
        private PromocaoProdutosService servicePromocaoProdutos;


        


        public PromocaoProdutosController(IHttpContextAccessor httpContextAccessor,DefaultContext Context)
        {
               

                servicePromocaoProdutos = new PromocaoProdutosService(Context);
 
                
StringValues vIdUsrUltEdicao;
                httpContextAccessor.HttpContext.Request.Headers.TryGetValue("IdUsrUltEdicao", out vIdUsrUltEdicao);
                var sIdUsrUltEdicao = vIdUsrUltEdicao.FirstOrDefault();
                if (!string.IsNullOrEmpty(sIdUsrUltEdicao)){
                                  servicePromocaoProdutos.IdUsrUltEdicao = Convert.ToInt32(sIdUsrUltEdicao);
                              }else{ servicePromocaoProdutos.IdUsrUltEdicao = 0;}
            
        }

        [HttpGet(Name ="GetPromocaoProdutoss")]        
        public IActionResult GetPromocaoProdutoss()
        {
            try
            {
                return new ObjectResult(servicePromocaoProdutos.GetAllPromocaoProdutoss());
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

        [HttpGet(Name ="GetPromocaoProdutosById")]        
        public IActionResult GetPromocaoProdutosById(int id)
        {
            try
            {
                return new ObjectResult(servicePromocaoProdutos.GetPromocaoProdutosById(id));
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


        [HttpPost(Name="PostPromocaoProdutos")]
        public IActionResult Post([FromBody] PromocaoProdutos promocaoprodutos)
        {                   
            try
            {  
                return new ObjectResult(servicePromocaoProdutos.Post(promocaoprodutos));
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

        [HttpPut(Name="PutPromocaoProdutos")]
        public IActionResult Put([FromBody] PromocaoProdutos promocaoprodutos)
        {      
            try
            {  
                return new ObjectResult(servicePromocaoProdutos.Put(promocaoprodutos));
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
        
        [HttpDelete(Name="DeletePromocaoProdutos")]
        public IActionResult Delete(int id)
        {
            try
            {
                return new ObjectResult(servicePromocaoProdutos.Delete(id));
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

