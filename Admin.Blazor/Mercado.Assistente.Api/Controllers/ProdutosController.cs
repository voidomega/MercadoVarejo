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
using Microsoft.AspNetCore.Authorization;

namespace Ma.MercadoAssistente.Controllers
{
    // [Authorize(Policy = "mvapi")]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private ProdutosService serviceProdutos;


        private MaContext LocalContext;


        public ProdutosController(IHttpContextAccessor httpContextAccessor, MaContext Context)
        {
               

                serviceProdutos = new ProdutosService(Context);
            LocalContext = Context;


StringValues vIdUsrUltEdicao;
                httpContextAccessor.HttpContext.Request.Headers.TryGetValue("IdUsrUltEdicao", out vIdUsrUltEdicao);
                var sIdUsrUltEdicao = vIdUsrUltEdicao.FirstOrDefault();
                if (!string.IsNullOrEmpty(sIdUsrUltEdicao)){
                                  serviceProdutos.IdUsrUltEdicao = Convert.ToInt32(sIdUsrUltEdicao);
                              }else{ serviceProdutos.IdUsrUltEdicao = 0;}
            
        }

        [HttpGet(Name ="GetProdutoss")]        
        public IActionResult GetProdutoss()
        {
            try
            {
                return new ObjectResult(serviceProdutos.GetAllProdutoss());
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

        [HttpGet(Name ="GetProdutosById")]        
        public IActionResult GetProdutosById(long id)
        {
            try
            {
                return new ObjectResult(serviceProdutos.GetProdutosById(id));
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


        [HttpPost(Name="PostProdutos")]
        public IActionResult Post([FromBody] Produtos produtos)
        {                   
            try
            {  
                return new ObjectResult(serviceProdutos.Post(produtos));
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

        [HttpPut(Name="PutProdutos")]
        public IActionResult Put([FromBody] Produtos produtos)
        {      
            try
            {  
                return new ObjectResult(serviceProdutos.Put(produtos));
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
        
        [HttpDelete(Name="DeleteProdutos")]
        public IActionResult Delete(long id)
        {
            try
            {
                return new ObjectResult(serviceProdutos.Delete(id));
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

