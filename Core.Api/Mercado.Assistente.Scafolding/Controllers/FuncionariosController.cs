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
    public class FuncionariosController : ControllerBase
    {
        private FuncionariosService serviceFuncionarios;


        


        public FuncionariosController(IHttpContextAccessor httpContextAccessor,DefaultContext Context)
        {
               

                serviceFuncionarios = new FuncionariosService(Context);
 
                
StringValues vIdUsrUltEdicao;
                httpContextAccessor.HttpContext.Request.Headers.TryGetValue("IdUsrUltEdicao", out vIdUsrUltEdicao);
                var sIdUsrUltEdicao = vIdUsrUltEdicao.FirstOrDefault();
                if (!string.IsNullOrEmpty(sIdUsrUltEdicao)){
                                  serviceFuncionarios.IdUsrUltEdicao = Convert.ToInt32(sIdUsrUltEdicao);
                              }else{ serviceFuncionarios.IdUsrUltEdicao = 0;}
            
        }

        [HttpGet(Name ="GetFuncionarioss")]        
        public IActionResult GetFuncionarioss()
        {
            try
            {
                return new ObjectResult(serviceFuncionarios.GetAllFuncionarioss());
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

        [HttpGet(Name ="GetFuncionariosById")]        
        public IActionResult GetFuncionariosById(int id)
        {
            try
            {
                return new ObjectResult(serviceFuncionarios.GetFuncionariosById(id));
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


        [HttpPost(Name="PostFuncionarios")]
        public IActionResult Post([FromBody] Funcionarios funcionarios)
        {                   
            try
            {  
                return new ObjectResult(serviceFuncionarios.Post(funcionarios));
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

        [HttpPut(Name="PutFuncionarios")]
        public IActionResult Put([FromBody] Funcionarios funcionarios)
        {      
            try
            {  
                return new ObjectResult(serviceFuncionarios.Put(funcionarios));
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
        
        [HttpDelete(Name="DeleteFuncionarios")]
        public IActionResult Delete(int id)
        {
            try
            {
                return new ObjectResult(serviceFuncionarios.Delete(id));
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

