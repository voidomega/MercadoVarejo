using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ma.Service;

using Ma.MercadoAssistente.Api.Contexto;
using Ma.MercadoAssistente.Api.Entidades;
using Ma.Interfaces;
using Ma.Domain.Entities;
using System.Linq;

using MercadoAssistente.Validators;

using System.Linq.Expressions;
using Ma.MercadoAssistente.Api.Models;
using MercadoAssistente.Data.Layer.Repository;
using System.Security.Cryptography;

namespace MercadoAssistente.Api.Services
{
    public class ProdutosService
    {
        private BaseService<Produtos> service;

        private MaContext LocalContext;

        public ProdutosService(MaContext Context)
        {
            LocalContext = Context;
             service = new BaseService<Produtos>(Context);
        }

        public Int32 IdUsrUltEdicao {get; set;}

        
        
        

        
 
        /// <summary>
        /// Construtor da Classe
        /// </summary>
        public ProdutosService()
        {
            service.NoTracking = false;
           
        }

        /// <summary>
        /// Ativa ou desativa o Tracking das entidades carregadas.
        /// </summary>
        /// <param name="TrackOnOff">Boolean</param>
        public void SetNoTracking(Boolean TrackOnOff)
        {
            service.NoTracking = TrackOnOff;
        }

        /// <summary>
        /// insere uma entidade da classe Produtos
        /// </summary>
        /// <param name="produtos"></param>
        /// <returns></returns>
        public Produtos Post(Produtos produtos)
        {
            
            return service.PostReturn<ProdutosValidator>(produtos);
        }

        /// <summary>
        /// Edita uma entidade da classe Produtos
        /// </summary>
        /// <param name="produtos"></param>
        /// <returns></returns>
        public Produtos Put(Produtos produtos)
        {
                
                return service.PutReturn<ProdutosValidator>(produtos);
        }

        /// <summary>
        /// Exclui uma entidade da classe Produtos
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>        
        public Boolean Delete(long Id)
        {       
            return service.DeleteReturn(Id);
        }

        /// <summary>
        /// Faz um select "All" na tabela da classe Produtos
        /// </summary>
        /// <returns></returns>
        public List<Produtos> GetAllProdutoss()
        {
            return service.Get().ToList();
        }


        public List<Produtos> GetProdutosByParam(ParamProdutos paramProdutos)
        {
            SqlHelper sqlHelper = new SqlHelper();
            sqlHelper.CreateContext(LocalContext);

            var setProdutos = sqlHelper.LiveContext().Set<Produtos>();

            var par = paramProdutos;

            var lstProdutos = (from Produtos prd in setProdutos
                               where (!par.IdProduto.HasValue || (par.IdProduto.HasValue && prd.IdProduto == par.IdProduto.Value))
                                  && (!par.IdMarca.HasValue || (par.IdMarca.HasValue && prd.IdMarca == par.IdMarca.Value))
                                  && (!par.IdFamilia.HasValue || (par.IdFamilia.HasValue && prd.IdFamilia == par.IdFamilia.Value))
                                  && (par.NmProduto == null || (par.NmProduto != null && prd.NmProduto.Contains(par.NmProduto)))
                                  && (!par.VlPreco.HasValue || (par.VlPreco.HasValue && (prd.VlPreco >= par.IdFamilia.Value
                                  && prd.VlPreco <= par.IdFamilia.Value)))
                               select prd).OrderBy(x => x.NmProduto).ToList();


            return service.Get().ToList();
        }

        /// <summary>
        /// Retorna um único registro da classe Produtos a partir da PK
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Produtos GetProdutosById(long  Id)
        {
            return service.Get(Id);
        }

        /// <summary>
        /// Permite realizar uma consulta usando Linq na tabela Produtos
        /// </summary>
        /// <param name="predicate">um predicado Lambda para montar uma consulta parametrizada</param>
        /// <returns></returns>
        public IEnumerable<Produtos> SelectIEnumerable(Expression<Func<Produtos, bool>> predicate)
        {
            return service.SelectIEnumerable(predicate);
        }

    }
}

