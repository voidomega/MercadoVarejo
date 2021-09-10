using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MercadoAssistente.Services;

using MercadoAssistente.Data.Layer.Context;
using Mercado.Assistente.Domain.Entities;
using Ma.Interfaces;
using Ma.Domain.Entities;

using MercadoAssistente.Validators;

using System.Linq.Expressions;

namespace MercadoAssistente.Api.Services
{
    public class ProdutosService
    {
        private BaseService<Produtos> service;



        public ProdutosService(DefaultContext Context)
        {
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

