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
    public class TipoEnderecosService
    {
        private BaseService<TipoEnderecos> service;



        public TipoEnderecosService(MaContext Context)
        {
             service = new BaseService<TipoEnderecos>(Context);
        }

        public Int32 IdUsrUltEdicao {get; set;}

        
        
        

        
 
        /// <summary>
        /// Construtor da Classe
        /// </summary>
        public TipoEnderecosService()
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
        /// insere uma entidade da classe TipoEnderecos
        /// </summary>
        /// <param name="tipoenderecos"></param>
        /// <returns></returns>
        public TipoEnderecos Post(TipoEnderecos tipoenderecos)
        {
            
            return service.PostReturn<TipoEnderecosValidator>(tipoenderecos);
        }

        /// <summary>
        /// Edita uma entidade da classe TipoEnderecos
        /// </summary>
        /// <param name="tipoenderecos"></param>
        /// <returns></returns>
        public TipoEnderecos Put(TipoEnderecos tipoenderecos)
        {
                
                return service.PutReturn<TipoEnderecosValidator>(tipoenderecos);
        }

        /// <summary>
        /// Exclui uma entidade da classe TipoEnderecos
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>        
        public Boolean Delete(int Id)
        {       
            return service.DeleteReturn(Id);
        }

        /// <summary>
        /// Faz um select "All" na tabela da classe TipoEnderecos
        /// </summary>
        /// <returns></returns>
        public List<TipoEnderecos> GetAllTipoEnderecoss()
        {
            return service.Get().ToList();
        }

        /// <summary>
        /// Retorna um único registro da classe TipoEnderecos a partir da PK
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public TipoEnderecos GetTipoEnderecosById(int  Id)
        {
            return service.Get(Id);
        }

        /// <summary>
        /// Permite realizar uma consulta usando Linq na tabela TipoEnderecos
        /// </summary>
        /// <param name="predicate">um predicado Lambda para montar uma consulta parametrizada</param>
        /// <returns></returns>
        public IEnumerable<TipoEnderecos> SelectIEnumerable(Expression<Func<TipoEnderecos, bool>> predicate)
        {
            return service.SelectIEnumerable(predicate);
        }

    }
}

