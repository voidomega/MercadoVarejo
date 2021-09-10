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
    public class TipoCobrancaController : ControllerBase
    {
        private TipoCobrancaService serviceTipoCobranca;


        


        public TipoCobrancaController(IHttpContextAccessor httpContextAccessor,DefaultContext Context)
        {
               

                serviceTipoCobranca = new TipoCobrancaService(Context);
 
                
StringValues vIdUsrUltEdicao;
                httpContextAccessor.HttpContext.Request.Headers.TryGetValue("IdUsrUltEdicao", out vIdUsrUltEdicao);
                var sIdUsrUltEdicao = vIdUsrUltEdicao.FirstOrDefault();
                if (!string.IsNullOrEmpty(sIdUsrUltEdicao)){
                                  serviceTipoCobranca.IdUsrUltEdicao = Convert.ToInt32(sIdUsrUltEdicao);
                              }else{ serviceTipoCobranca.IdUsrUltEdicao = 0;}
            
        }

        [HttpGet(Name ="GetTipoCobrancas")]        
        public IActionResult GetTipoCobrancas()
        {
            try
            {
                return new ObjectResult(serviceTipoCobranca.GetAllTipoCobrancas());
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

        [HttpGet(Name ="GetTipoCobrancaById")]        
        public IActionResult GetTipoCobrancaById(int id)
        {
            try
            {
                return new ObjectResult(serviceTipoCobranca.GetTipoCobrancaById(id));
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


        [HttpPost(Name="PostTipoCobranca")]
        public IActionResult Post([FromBody] TipoCobranca tipocobranca)
        {                   
            try
            {  
                return new ObjectResult(serviceTipoCobranca.Post(tipocobranca));
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

        [HttpPut(Name="PutTipoCobranca")]
        public IActionResult Put([FromBody] TipoCobranca tipocobranca)
        {      
            try
            {  
                return new ObjectResult(serviceTipoCobranca.Put(tipocobranca));
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
        
        [HttpDelete(Name="DeleteTipoCobranca")]
        public IActionResult Delete(int id)
        {
            try
            {
                return new ObjectResult(serviceTipoCobranca.Delete(id));
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

