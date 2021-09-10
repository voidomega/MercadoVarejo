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
    public class PedidosService
    {
        private BaseService<Pedidos> service;



        public PedidosService(DefaultContext Context)
        {
             service = new BaseService<Pedidos>(Context);
        }

        public Int32 IdUsrUltEdicao {get; set;}

        
        
        

        
 
        /// <summary>
        /// Construtor da Classe
        /// </summary>
        public PedidosService()
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
        /// insere uma entidade da classe Pedidos
        /// </summary>
        /// <param name="pedidos"></param>
        /// <returns></returns>
        public Pedidos Post(Pedidos pedidos)
        {
            
            return service.PostReturn<PedidosValidator>(pedidos);
        }

        /// <summary>
        /// Edita uma entidade da classe Pedidos
        /// </summary>
        /// <param name="pedidos"></param>
        /// <returns></returns>
        public Pedidos Put(Pedidos pedidos)
        {
                
                return service.PutReturn<PedidosValidator>(pedidos);
        }

        /// <summary>
        /// Exclui uma entidade da classe Pedidos
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>        
        public Boolean Delete(long Id)
        {       
            return service.DeleteReturn(Id);
        }

        /// <summary>
        /// Faz um select "All" na tabela da classe Pedidos
        /// </summary>
        /// <returns></returns>
        public List<Pedidos> GetAllPedidoss()
        {
            return service.Get().ToList();
        }

        /// <summary>
        /// Retorna um único registro da classe Pedidos a partir da PK
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Pedidos GetPedidosById(long  Id)
        {
            return service.Get(Id);
        }

        /// <summary>
        /// Permite realizar uma consulta usando Linq na tabela Pedidos
        /// </summary>
        /// <param name="predicate">um predicado Lambda para montar uma consulta parametrizada</param>
        /// <returns></returns>
        public IEnumerable<Pedidos> SelectIEnumerable(Expression<Func<Pedidos, bool>> predicate)
        {
            return service.SelectIEnumerable(predicate);
        }

    }
}

