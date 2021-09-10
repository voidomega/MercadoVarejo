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
using MercadoAssistente.Data.Layer.Repository;
using Microsoft.EntityFrameworkCore;
using Ma.MercadoAssistente.Api.Models;

namespace Ma.MercadoAssistente.Controllers
{
    // [Authorize(Policy = "mvapi")]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private CategoriasService serviceCategorias;





        public CategoriasController(IHttpContextAccessor httpContextAccessor, MaContext Context)
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
                SqlHelper helper = new SqlHelper();
                helper.CreateContext();
                var lstCategorias = (from Categorias cat in
                                     helper.LiveContext().Set<Categorias>()
                                     from Grupos grp in helper.LiveContext().Set<Grupos>().Where(x => x.IdGrupo == cat.IdGrupo).DefaultIfEmpty()                                    
                                     select new CategoriaGrupo() { 
                                         IdCategoria = cat.IdCategoria, 
                                         DsCategoria = cat.DsCategoria, 
                                         DsGrupo = grp.DsGrupo  }).ToList();
                //serviceCategorias.GetAllCategoriass()

                return new ObjectResult(lstCategorias);
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


        [HttpPost(Name= "PostCategorias")]
        public IActionResult PostCategorias([FromBody] Categorias categorias)
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

        [HttpPut(Name= "PutCategorias")]
        public IActionResult PutCategorias([FromBody] Categorias categorias)
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
        
        [HttpDelete(Name= "DeleteCategorias")]
        public IActionResult DeleteCategorias(int id)
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

