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
    public class EnderecoClientesService
    {
        private BaseService<EnderecoClientes> service;



        public EnderecoClientesService(MaContext Context)
        {
             service = new BaseService<EnderecoClientes>(Context);
        }

        public Int32 IdUsrUltEdicao {get; set;}

        
        
        

        
 
        /// <summary>
        /// Construtor da Classe
        /// </summary>
        public EnderecoClientesService()
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
        /// insere uma entidade da classe EnderecoClientes
        /// </summary>
        /// <param name="enderecoclientes"></param>
        /// <returns></returns>
        public EnderecoClientes Post(EnderecoClientes enderecoclientes)
        {
            
            return service.PostReturn<EnderecoClientesValidator>(enderecoclientes);
        }

        /// <summary>
        /// Edita uma entidade da classe EnderecoClientes
        /// </summary>
        /// <param name="enderecoclientes"></param>
        /// <returns></returns>
        public EnderecoClientes Put(EnderecoClientes enderecoclientes)
        {
                
                return service.PutReturn<EnderecoClientesValidator>(enderecoclientes);
        }

        /// <summary>
        /// Exclui uma entidade da classe EnderecoClientes
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>        
        public Boolean Delete(int Id)
        {       
            return service.DeleteReturn(Id);
        }

        /// <summary>
        /// Faz um select "All" na tabela da classe EnderecoClientes
        /// </summary>
        /// <returns></returns>
        public List<EnderecoClientes> GetAllEnderecoClientess()
        {
            return service.Get().ToList();
        }

        /// <summary>
        /// Retorna um único registro da classe EnderecoClientes a partir da PK
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public EnderecoClientes GetEnderecoClientesById(int  Id)
        {
            return service.Get(Id);
        }

        /// <summary>
        /// Permite realizar uma consulta usando Linq na tabela EnderecoClientes
        /// </summary>
        /// <param name="predicate">um predicado Lambda para montar uma consulta parametrizada</param>
        /// <returns></returns>
        public IEnumerable<EnderecoClientes> SelectIEnumerable(Expression<Func<EnderecoClientes, bool>> predicate)
        {
            return service.SelectIEnumerable(predicate);
        }

    }
}

