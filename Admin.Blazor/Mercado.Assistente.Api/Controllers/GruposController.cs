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
    public class GruposController : ControllerBase
    {
        private GruposService serviceGrupos;

        public GruposController(IHttpContextAccessor httpContextAccessor,MaContext Context)
        {
               

                serviceGrupos = new GruposService(Context);
 
                
StringValues vIdUsrUltEdicao;
            httpContextAccessor.HttpContext.Request.Headers.TryGetValue("IdUsrUltEdicao", out vIdUsrUltEdicao);
                var sIdUsrUltEdicao = vIdUsrUltEdicao.FirstOrDefault();
                if (!string.IsNullOrEmpty(sIdUsrUltEdicao)){
                                  serviceGrupos.IdUsrUltEdicao = Convert.ToInt32(sIdUsrUltEdicao);
                              }else{ serviceGrupos.IdUsrUltEdicao = 0;}
            
        }

        [HttpGet(Name ="GetGruposs")]        
        public IActionResult GetGruposs()
        {
            try
            {
                return new ObjectResult(serviceGrupos.GetAllGruposs());
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

        [HttpGet(Name = "GetGruposById")]        
        public IActionResult GetGruposById(int id)
        {
            try
            {
                return new ObjectResult(serviceGrupos.GetGruposById(id));
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


        [HttpPost(Name= "PostGrupos")]
        public IActionResult PostGrupos([FromBody] Grupos grupos)
        {                   
            try
            {  
                return new ObjectResult(serviceGrupos.Post(grupos));
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

        [HttpPut(Name= "PutGrupos")]
        public IActionResult PutGrupos([FromBody] Grupos grupos)
        {      
            try
            {  
                return new ObjectResult(serviceGrupos.Put(grupos));
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
        
        [HttpDelete(Name= "DeleteGrupos")]
        public IActionResult DeleteGrupos(int id)
        {
            try
            {
                return new ObjectResult(serviceGrupos.Delete(id));
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

