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
    public class FamiliasController : ControllerBase
    {
        private FamiliasService serviceFamilias;


        


        public FamiliasController(IHttpContextAccessor httpContextAccessor,DefaultContext Context)
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


        [HttpPost(Name="PostFamilias")]
        public IActionResult Post([FromBody] Familias familias)
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

        [HttpPut(Name="PutFamilias")]
        public IActionResult Put([FromBody] Familias familias)
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
        
        [HttpDelete(Name="DeleteFamilias")]
        public IActionResult Delete(int id)
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

