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
    public class SituacaoPedidosService
    {
        private BaseService<SituacaoPedidos> service;



        public SituacaoPedidosService(DefaultContext Context)
        {
             service = new BaseService<SituacaoPedidos>(Context);
        }

        public Int32 IdUsrUltEdicao {get; set;}

        
        
        

        
 
        /// <summary>
        /// Construtor da Classe
        /// </summary>
        public SituacaoPedidosService()
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
        /// insere uma entidade da classe SituacaoPedidos
        /// </summary>
        /// <param name="situacaopedidos"></param>
        /// <returns></returns>
        public SituacaoPedidos Post(SituacaoPedidos situacaopedidos)
        {
            
            return service.PostReturn<SituacaoPedidosValidator>(situacaopedidos);
        }

        /// <summary>
        /// Edita uma entidade da classe SituacaoPedidos
        /// </summary>
        /// <param name="situacaopedidos"></param>
        /// <returns></returns>
        public SituacaoPedidos Put(SituacaoPedidos situacaopedidos)
        {
                
                return service.PutReturn<SituacaoPedidosValidator>(situacaopedidos);
        }

        /// <summary>
        /// Exclui uma entidade da classe SituacaoPedidos
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>        
        public Boolean Delete(int Id)
        {       
            return service.DeleteReturn(Id);
        }

        /// <summary>
        /// Faz um select "All" na tabela da classe SituacaoPedidos
        /// </summary>
        /// <returns></returns>
        public List<SituacaoPedidos> GetAllSituacaoPedidoss()
        {
            return service.Get().ToList();
        }

        /// <summary>
        /// Retorna um único registro da classe SituacaoPedidos a partir da PK
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public SituacaoPedidos GetSituacaoPedidosById(int  Id)
        {
            return service.Get(Id);
        }

        /// <summary>
        /// Permite realizar uma consulta usando Linq na tabela SituacaoPedidos
        /// </summary>
        /// <param name="predicate">um predicado Lambda para montar uma consulta parametrizada</param>
        /// <returns></returns>
        public IEnumerable<SituacaoPedidos> SelectIEnumerable(Expression<Func<SituacaoPedidos, bool>> predicate)
        {
            return service.SelectIEnumerable(predicate);
        }

    }
}

