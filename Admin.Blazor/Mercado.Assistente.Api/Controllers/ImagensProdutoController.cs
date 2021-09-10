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
    public class ImagensProdutoController : ControllerBase
    {
        private ImagensProdutoService serviceImagensProduto;


        


        public ImagensProdutoController(IHttpContextAccessor httpContextAccessor,MaContext Context)
        {
               

                serviceImagensProduto = new ImagensProdutoService(Context);
 
                
StringValues vIdUsrUltEdicao;
                httpContextAccessor.HttpContext.Request.Headers.TryGetValue("IdUsrUltEdicao", out vIdUsrUltEdicao);
                var sIdUsrUltEdicao = vIdUsrUltEdicao.FirstOrDefault();
                if (!string.IsNullOrEmpty(sIdUsrUltEdicao)){
                                  serviceImagensProduto.IdUsrUltEdicao = Convert.ToInt32(sIdUsrUltEdicao);
                              }else{ serviceImagensProduto.IdUsrUltEdicao = 0;}
            
        }

        [HttpGet(Name ="GetImagensProdutos")]        
        public IActionResult GetImagensProdutos()
        {
            try
            {
                return new ObjectResult(serviceImagensProduto.GetAllImagensProdutos());
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

        [HttpGet(Name ="GetImagensProdutoById")]        
        public IActionResult GetImagensProdutoById(long id)
        {
            try
            {
                return new ObjectResult(serviceImagensProduto.GetImagensProdutoById(id));
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


        [HttpPost(Name="PostImagensProduto")]
        public IActionResult Post([FromBody] ImagensProduto imagensproduto)
        {                   
            try
            {  
                return new ObjectResult(serviceImagensProduto.Post(imagensproduto));
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

        [HttpPut(Name="PutImagensProduto")]
        public IActionResult Put([FromBody] ImagensProduto imagensproduto)
        {      
            try
            {  
                return new ObjectResult(serviceImagensProduto.Put(imagensproduto));
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
        
        [HttpDelete(Name="DeleteImagensProduto")]
        public IActionResult Delete(long id)
        {
            try
            {
                return new ObjectResult(serviceImagensProduto.Delete(id));
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

