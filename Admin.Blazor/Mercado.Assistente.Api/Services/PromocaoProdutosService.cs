using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ma.Service;

using Ma.MercadoAssistente.Api.Contexto;
using Ma.MercadoAssistente.Api.Entidades;
using Ma.Interfaces;
using Ma.Domain.Entities;

using MercadoAssistente.Validators;

using System.Linq.Expressions;

namespace MercadoAssistente.Api.Services
{
    public class PromocaoProdutosService
    {
        private BaseService<PromocaoProdutos> service;



        public PromocaoProdutosService(MaContext Context)
        {
             service = new BaseService<PromocaoProdutos>(Context);
        }

        public Int32 IdUsrUltEdicao {get; set;}

        
        
        

        
 
        /// <summary>
        /// Construtor da Classe
        /// </summary>
        public PromocaoProdutosService()
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
        /// insere uma entidade da classe PromocaoProdutos
        /// </summary>
        /// <param name="promocaoprodutos"></param>
        /// <returns></returns>
        public PromocaoProdutos Post(PromocaoProdutos promocaoprodutos)
        {
            
            return service.PostReturn<PromocaoProdutosValidator>(promocaoprodutos);
        }

        /// <summary>
        /// Edita uma entidade da classe PromocaoProdutos
        /// </summary>
        /// <param name="promocaoprodutos"></param>
        /// <returns></returns>
        public PromocaoProdutos Put(PromocaoProdutos promocaoprodutos)
        {
                
                return service.PutReturn<PromocaoProdutosValidator>(promocaoprodutos);
        }

        /// <summary>
        /// Exclui uma entidade da classe PromocaoProdutos
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>        
        public Boolean Delete(int Id)
        {       
            return service.DeleteReturn(Id);
        }

        /// <summary>
        /// Faz um select "All" na tabela da classe PromocaoProdutos
        /// </summary>
        /// <returns></returns>
        public List<PromocaoProdutos> GetAllPromocaoProdutoss()
        {
            return service.Get().ToList();
        }

        /// <summary>
        /// Retorna um único registro da classe PromocaoProdutos a partir da PK
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public PromocaoProdutos GetPromocaoProdutosById(int  Id)
        {
            return service.Get(Id);
        }

        /// <summary>
        /// Permite realizar uma consulta usando Linq na tabela PromocaoProdutos
        /// </summary>
        /// <param name="predicate">um predicado Lambda para montar uma consulta parametrizada</param>
        /// <returns></returns>
        public IEnumerable<PromocaoProdutos> SelectIEnumerable(Expression<Func<PromocaoProdutos, bool>> predicate)
        {
            return service.SelectIEnumerable(predicate);
        }

    }
}

