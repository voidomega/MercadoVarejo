using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ma.MercadoAssistente.Api.Entidades;
using MercadoAssistente.Api.Models;
using MercadoAssistente.Local.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MercadoAssistente.Data.Layer.Repository;
using Ma.MercadoAssistente.Api.Contexto;

namespace Ma.MercadoAssistente.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CtrlAcessoController : ControllerBase
    {

        //CtrlAcesso/ObtemUsuarioAutenticado

        private MaContext lContext = null;


        public CtrlAcessoController(IHttpContextAccessor httpContextAccessor, MaContext Context)
        {
            lContext = Context;
        }


        //[HttpPost(Name = "ObtemUsuarioAutenticado")]
        //public IActionResult ObtemUsuarioAutenticado([FromBody] ParamAcesso UsrAcesso)
        //{
        //    try
        //    {
        //        SqlHelper helper = new SqlHelper();
        //        helper.CreateContext(lContext);

        //        var ctxCliente = helper.LiveContext().Set<Clientes>();
        //        var ctxFuncionario = helper.LiveContext().Set<Funcionarios>();


        //        UsrLogado usrLogado = new UsrLogado();

        //        if (UsrAcesso.TpAcessoUsuario == 'c')
        //        {
        //            usrLogado = (from Clientes cliente in ctxCliente
        //                         where cliente.DsEmail == UsrAcesso.DsEmail
        //                         && cliente.DsSenha == UsrAcesso.DsSenha
        //                         select new UsrLogado()
        //                         {
        //                             IdUsrLogado = cliente.IdCliente,
        //                             DsEmail = cliente.DsEmail,
        //                             DsNmUsuario = cliente.NmCliente,
        //                             NmUsrLogado = cliente.DsNmUsuario,
        //                             TpAcessoUsuario = 'c'
        //                         }).FirstOrDefault();
        //        }
        //        else if (UsrAcesso.TpAcessoUsuario == 'f')
        //        {
        //            usrLogado = (from Funcionarios funciona in ctxFuncionario
        //                         where funciona.DsEmail == UsrAcesso.DsEmail
        //                         && funciona.DsSenha == UsrAcesso.DsSenha
        //                         select new UsrLogado()
        //                         {
        //                             IdUsrLogado = funciona.IdFuncionario,
        //                             DsEmail = funciona.DsEmail,
        //                             DsNmUsuario = funciona.NmFuncionario,
        //                             NmUsrLogado = funciona.DsNmUsuario,
        //                             TpAcessoUsuario = 'f'
        //                         }).FirstOrDefault();
        //        }


        //        return new ObjectResult(usrLogado);
        //    }
        //    catch (ArgumentNullException ex)
        //    {
        //        return NotFound(ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(Ma.Util.Api.NpgSqlErrorTrapper.GetError(ex));
        //    }

        //}

        [HttpPost(Name = "ObtemUsuarioAutenticado")]
        public IActionResult ObtemUsuarioAutenticado([FromBody] ParamAcesso UsrAcesso)
        {
            try
            {
                SqlHelper helper = new SqlHelper();
                helper.CreateContext(lContext);

                var ctxCliente = helper.LiveContext().Set<Clientes>();
                var ctxFuncionario = helper.LiveContext().Set<Funcionarios>();


                Usuario usrLogado = new Usuario();

                if (UsrAcesso.TpAcessoUsuario == 1178)
                {
                    usrLogado = (from Clientes cliente in ctxCliente
                                 where cliente.DsEmail == UsrAcesso.DsEmail
                                 && cliente.DsSenha == UsrAcesso.DsSenha
                                 select new Usuario()
                                 {
                                     IdUsuario = cliente.IdCliente,
                                     DsEmail = cliente.DsEmail,
                                     NmUsuario = cliente.NmCliente,
                                     NmApelido = cliente.DsNmUsuario,
                                     IdFilial = "C",
                                     IdGrupoEmpresa = UsrAcesso.TpAcessoUsuario
                                 }).FirstOrDefault();
                }
                else if (UsrAcesso.TpAcessoUsuario == 1145)
                {
                    usrLogado = (from Funcionarios funciona in ctxFuncionario
                                 where funciona.DsEmail == UsrAcesso.DsEmail
                                 && funciona.DsSenha == UsrAcesso.DsSenha
                                 select new Usuario()
                                 {
                                     IdUsuario = funciona.IdFuncionario,
                                     DsEmail = funciona.DsEmail,
                                     NmUsuario = funciona.NmFuncionario,
                                     NmApelido = funciona.DsNmUsuario,
                                     IdFilial = "F",
                                     IdGrupoEmpresa = UsrAcesso.TpAcessoUsuario
                                 }).FirstOrDefault();
                }


                return new ObjectResult(usrLogado);
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