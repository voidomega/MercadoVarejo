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
    public class HistoricoPedidosService
    {
        private BaseService<HistoricoPedidos> service;



        public HistoricoPedidosService(DefaultContext Context)
        {
             service = new BaseService<HistoricoPedidos>(Context);
        }

        public Int32 IdUsrUltEdicao {get; set;}

        
        
        

        
 
        /// <summary>
        /// Construtor da Classe
        /// </summary>
        public HistoricoPedidosService()
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
        /// insere uma entidade da classe HistoricoPedidos
        /// </summary>
        /// <param name="historicopedidos"></param>
        /// <returns></returns>
        public HistoricoPedidos Post(HistoricoPedidos historicopedidos)
        {
            
            return service.PostReturn<HistoricoPedidosValidator>(historicopedidos);
        }

        /// <summary>
        /// Edita uma entidade da classe HistoricoPedidos
        /// </summary>
        /// <param name="historicopedidos"></param>
        /// <returns></returns>
        public HistoricoPedidos Put(HistoricoPedidos historicopedidos)
        {
                
                return service.PutReturn<HistoricoPedidosValidator>(historicopedidos);
        }

        /// <summary>
        /// Exclui uma entidade da classe HistoricoPedidos
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>        
        public Boolean Delete(int Id)
        {       
            return service.DeleteReturn(Id);
        }

        /// <summary>
        /// Faz um select "All" na tabela da classe HistoricoPedidos
        /// </summary>
        /// <returns></returns>
        public List<HistoricoPedidos> GetAllHistoricoPedidoss()
        {
            return service.Get().ToList();
        }

        /// <summary>
        /// Retorna um único registro da classe HistoricoPedidos a partir da PK
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public HistoricoPedidos GetHistoricoPedidosById(int  Id)
        {
            return service.Get(Id);
        }

        /// <summary>
        /// Permite realizar uma consulta usando Linq na tabela HistoricoPedidos
        /// </summary>
        /// <param name="predicate">um predicado Lambda para montar uma consulta parametrizada</param>
        /// <returns></returns>
        public IEnumerable<HistoricoPedidos> SelectIEnumerable(Expression<Func<HistoricoPedidos, bool>> predicate)
        {
            return service.SelectIEnumerable(predicate);
        }

    }
}

