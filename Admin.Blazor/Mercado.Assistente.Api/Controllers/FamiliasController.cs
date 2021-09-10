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
    public class FamiliasController : ControllerBase
    {
        private FamiliasService serviceFamilias;


        


        public FamiliasController(IHttpContextAccessor httpContextAccessor,MaContext Context)
        {
               

                serviceFamilias = new FamiliasService(Context);
 
                
StringValues vIdUsrUltEdicao;
                httpContextAccessor.HttpContext.Request.Headers.TryGetValue("IdUsrUltEdicao", out vIdUsrUltEdicao);
                var sIdUsrUltEdicao = vIdUsrUltEdicao.FirstOrDefault();
                if (!string.IsNullOrEmpty(sIdUsrUltEdicao)){
                                  serviceFamilias.IdUsrUltEdicao = Convert.ToInt32(sIdUsrUltEdicao);
                              }else{ serviceFamilias.IdUsrUltEdicao = 0;}
            
        }

        [HttpGet(Name ="GetFamiliass")]        
        public IActionResult GetFamiliass()
        {
            try
            {
                return new ObjectResult(serviceFamilias.GetAllFamiliass());
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


        [HttpGet(Name = "GetFamiliasByIdCategoria")]
        public IActionResult GetFamiliasByIdCategoria(int id)
        {
            try
            {
                return new ObjectResult(serviceFamilias.GetFamiliasByIdCategoria(id));
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


        [HttpGet(Name ="GetFamiliasById")]        
        public IActionResult GetFamiliasById(int id)
        {
            try
            {
                return new ObjectResult(serviceFamilias.GetFamiliasById(id));
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


        [HttpPost(Name= "PostFamilias")]
        public IActionResult PostFamilias([FromBody] Familias familias)
        {                   
            try
            {  
                return new ObjectResult(serviceFamilias.Post(familias));
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

        [HttpPut(Name= "PutFamilias")]
        public IActionResult PutFamilias([FromBody] Familias familias)
        {      
            try
            {  
                return new ObjectResult(serviceFamilias.Put(familias));
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
        
        [HttpDelete(Name= "DeleteFamilias")]
        public IActionResult DeleteFamilias(int id)
        {
            try
            {
                return new ObjectResult(serviceFamilias.Delete(id));
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

