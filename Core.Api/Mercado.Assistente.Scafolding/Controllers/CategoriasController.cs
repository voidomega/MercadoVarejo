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
    public class CategoriasController : ControllerBase
    {
        private CategoriasService serviceCategorias;


        


        public CategoriasController(IHttpContextAccessor httpContextAccessor,DefaultContext Context)
        {
               

                serviceCategorias = new CategoriasService(Context);
 
                
StringValues vIdUsrUltEdicao;
                httpContextAccessor.HttpContext.Request.Headers.TryGetValue("IdUsrUltEdicao", out vIdUsrUltEdicao);
                var sIdUsrUltEdicao = vIdUsrUltEdicao.FirstOrDefault();
                if (!string.IsNullOrEmpty(sIdUsrUltEdicao)){
                                  serviceCategorias.IdUsrUltEdicao = Convert.ToInt32(sIdUsrUltEdicao);
                              }else{ serviceCategorias.IdUsrUltEdicao = 0;}
            
        }

        [HttpGet(Name ="GetCategoriass")]        
        public IActionResult GetCategoriass()
        {
            try
            {
                return new ObjectResult(serviceCategorias.GetAllCategoriass());
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

        [HttpGet(Name ="GetCategoriasById")]        
        public IActionResult GetCategoriasById(int id)
        {
            try
            {
                return new ObjectResult(serviceCategorias.GetCategoriasById(id));
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


        [HttpPost(Name="PostCategorias")]
        public IActionResult Post([FromBody] Categorias categorias)
        {                   
            try
            {  
                return new ObjectResult(serviceCategorias.Post(categorias));
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

        [HttpPut(Name="PutCategorias")]
        public IActionResult Put([FromBody] Categorias categorias)
        {      
            try
            {  
                return new ObjectResult(serviceCategorias.Put(categorias));
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
        
        [HttpDelete(Name="DeleteCategorias")]
        public IActionResult Delete(int id)
        {
            try
            {
                return new ObjectResult(serviceCategorias.Delete(id));
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

