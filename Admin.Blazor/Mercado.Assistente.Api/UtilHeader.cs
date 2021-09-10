using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ByteOn.Data.Layer.Context;
using ByteOn.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace ByteOn.Valor.PortalCliente.Api
{
    public static class UtilHeader
    {

        ////, Int32 IdConexao
        ///
        public static DefaultContext GetDefaultContext(HttpContext contextHttp)
        {

            StringValues vidConexao;
            contextHttp.Request.Headers.TryGetValue("IdConexao", out vidConexao);
            var IdConexao = vidConexao.FirstOrDefault();


            // var IdConexao = contextHttp.Request.Headers.Where(x => x.Key == "IdConexao").FirstOrDefault();


            if (!string.IsNullOrEmpty(IdConexao))
            {
                Int32 IidConexao = Convert.ToInt32(IdConexao);
                Conexao conexao = new ByteOn.Services.ConexaoService().ObterConexao(IidConexao);
                if (conexao != null)
                {
                    string StrConexao = conexao.DsConexao;
                    return new DefaultContext(StrConexao);
                }
                else
                    return new DefaultContext();
            }
            return new DefaultContext();
        }

        public static DefaultContext GetDefaultContext(Int32 IdConexao)
        {
            if (IdConexao>0)
            {
                Int32 IidConexao = Convert.ToInt32(IdConexao);
                Conexao conexao = new ByteOn.Services.ConexaoService().ObterConexao(IidConexao);
                if (conexao != null)
                {
                    string StrConexao = conexao.DsConexao;
                    return new DefaultContext(StrConexao);
                }
                else
                    return new DefaultContext();
            }
            return new DefaultContext();
        }
    }
}
