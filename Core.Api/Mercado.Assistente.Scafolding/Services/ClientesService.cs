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
    public class ClientesService
    {
        private BaseService<Clientes> service;



        public ClientesService(DefaultContext Context)
        {
             service = new BaseService<Clientes>(Context);
        }

        public Int32 IdUsrUltEdicao {get; set;}

        
        
        

        
 
        /// <summary>
        /// Construtor da Classe
        /// </summary>
        public ClientesService()
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
        /// insere uma entidade da classe Clientes
        /// </summary>
        /// <param name="clientes"></param>
        /// <returns></returns>
        public Clientes Post(Clientes clientes)
        {
            
            return service.PostReturn<ClientesValidator>(clientes);
        }

        /// <summary>
        /// Edita uma entidade da classe Clientes
        /// </summary>
        /// <param name="clientes"></param>
        /// <returns></returns>
        public Clientes Put(Clientes clientes)
        {
                
                return service.PutReturn<ClientesValidator>(clientes);
        }

        /// <summary>
        /// Exclui uma entidade da classe Clientes
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>        
        public Boolean Delete(int Id)
        {       
            return service.DeleteReturn(Id);
        }

        /// <summary>
        /// Faz um select "All" na tabela da classe Clientes
        /// </summary>
        /// <returns></returns>
        public List<Clientes> GetAllClientess()
        {
            return service.Get().ToList();
        }

        /// <summary>
        /// Retorna um único registro da classe Clientes a partir da PK
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Clientes GetClientesById(int  Id)
        {
            return service.Get(Id);
        }

        /// <summary>
        /// Permite realizar uma consulta usando Linq na tabela Clientes
        /// </summary>
        /// <param name="predicate">um predicado Lambda para montar uma consulta parametrizada</param>
        /// <returns></returns>
        public IEnumerable<Clientes> SelectIEnumerable(Expression<Func<Clientes, bool>> predicate)
        {
            return service.SelectIEnumerable(predicate);
        }

    }
}

