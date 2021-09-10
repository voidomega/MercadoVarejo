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
    public class TipoEnderecosController : ControllerBase
    {
        private TipoEnderecosService serviceTipoEnderecos;


        


        public TipoEnderecosController(IHttpContextAccessor httpContextAccessor,DefaultContext Context)
        {
               

                serviceTipoEnderecos = new TipoEnderecosService(Context);
 
                
StringValues vIdUsrUltEdicao;
                httpContextAccessor.HttpContext.Request.Headers.TryGetValue("IdUsrUltEdicao", out vIdUsrUltEdicao);
                var sIdUsrUltEdicao = vIdUsrUltEdicao.FirstOrDefault();
                if (!string.IsNullOrEmpty(sIdUsrUltEdicao)){
                                  serviceTipoEnderecos.IdUsrUltEdicao = Convert.ToInt32(sIdUsrUltEdicao);
                              }else{ serviceTipoEnderecos.IdUsrUltEdicao = 0;}
            
        }

        [HttpGet(Name ="GetTipoEnderecoss")]        
        public IActionResult GetTipoEnderecoss()
        {
            try
            {
                return new ObjectResult(serviceTipoEnderecos.GetAllTipoEnderecoss());
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

        [HttpGet(Name ="GetTipoEnderecosById")]        
        public IActionResult GetTipoEnderecosById(int id)
        {
            try
            {
                return new ObjectResult(serviceTipoEnderecos.GetTipoEnderecosById(id));
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


        [HttpPost(Name="PostTipoEnderecos")]
        public IActionResult Post([FromBody] TipoEnderecos tipoenderecos)
        {                   
            try
            {  
                return new ObjectResult(serviceTipoEnderecos.Post(tipoenderecos));
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

        [HttpPut(Name="PutTipoEnderecos")]
        public IActionResult Put([FromBody] TipoEnderecos tipoenderecos)
        {      
            try
            {  
                return new ObjectResult(serviceTipoEnderecos.Put(tipoenderecos));
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
        
        [HttpDelete(Name="DeleteTipoEnderecos")]
        public IActionResult Delete(int id)
        {
            try
            {
                return new ObjectResult(serviceTipoEnderecos.Delete(id));
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

