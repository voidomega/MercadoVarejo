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
    public class ItemPedidosService
    {
        private BaseService<ItemPedidos> service;



        public ItemPedidosService(MaContext Context)
        {
             service = new BaseService<ItemPedidos>(Context);
        }

        public Int32 IdUsrUltEdicao {get; set;}

        
        
        

        
 
        /// <summary>
        /// Construtor da Classe
        /// </summary>
        public ItemPedidosService()
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
        /// insere uma entidade da classe ItemPedidos
        /// </summary>
        /// <param name="itempedidos"></param>
        /// <returns></returns>
        public ItemPedidos Post(ItemPedidos itempedidos)
        {
            
            return service.PostReturn<ItemPedidosValidator>(itempedidos);
        }

        /// <summary>
        /// Edita uma entidade da classe ItemPedidos
        /// </summary>
        /// <param name="itempedidos"></param>
        /// <returns></returns>
        public ItemPedidos Put(ItemPedidos itempedidos)
        {
                
                return service.PutReturn<ItemPedidosValidator>(itempedidos);
        }

        /// <summary>
        /// Exclui uma entidade da classe ItemPedidos
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>        
        public Boolean Delete(long Id)
        {       
            return service.DeleteReturn(Id);
        }

        /// <summary>
        /// Faz um select "All" na tabela da classe ItemPedidos
        /// </summary>
        /// <returns></returns>
        public List<ItemPedidos> GetAllItemPedidoss()
        {
            return service.Get().ToList();
        }

        /// <summary>
        /// Retorna um único registro da classe ItemPedidos a partir da PK
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ItemPedidos GetItemPedidosById(long  Id)
        {
            return service.Get(Id);
        }

        /// <summary>
        /// Permite realizar uma consulta usando Linq na tabela ItemPedidos
        /// </summary>
        /// <param name="predicate">um predicado Lambda para montar uma consulta parametrizada</param>
        /// <returns></returns>
        public IEnumerable<ItemPedidos> SelectIEnumerable(Expression<Func<ItemPedidos, bool>> predicate)
        {
            return service.SelectIEnumerable(predicate);
        }

    }
}

