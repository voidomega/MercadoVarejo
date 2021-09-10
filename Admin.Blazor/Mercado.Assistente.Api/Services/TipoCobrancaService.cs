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
    public class TipoCobrancaService
    {
        private BaseService<TipoCobranca> service;



        public TipoCobrancaService(MaContext Context)
        {
             service = new BaseService<TipoCobranca>(Context);
        }

        public Int32 IdUsrUltEdicao {get; set;}

        
        
        

        
 
        /// <summary>
        /// Construtor da Classe
        /// </summary>
        public TipoCobrancaService()
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
        /// insere uma entidade da classe TipoCobranca
        /// </summary>
        /// <param name="tipocobranca"></param>
        /// <returns></returns>
        public TipoCobranca Post(TipoCobranca tipocobranca)
        {
            
            return service.PostReturn<TipoCobrancaValidator>(tipocobranca);
        }

        /// <summary>
        /// Edita uma entidade da classe TipoCobranca
        /// </summary>
        /// <param name="tipocobranca"></param>
        /// <returns></returns>
        public TipoCobranca Put(TipoCobranca tipocobranca)
        {
                
                return service.PutReturn<TipoCobrancaValidator>(tipocobranca);
        }

        /// <summary>
        /// Exclui uma entidade da classe TipoCobranca
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>        
        public Boolean Delete(int Id)
        {       
            return service.DeleteReturn(Id);
        }

        /// <summary>
        /// Faz um select "All" na tabela da classe TipoCobranca
        /// </summary>
        /// <returns></returns>
        public List<TipoCobranca> GetAllTipoCobrancas()
        {
            return service.Get().ToList();
        }

        /// <summary>
        /// Retorna um único registro da classe TipoCobranca a partir da PK
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public TipoCobranca GetTipoCobrancaById(int  Id)
        {
            return service.Get(Id);
        }

        /// <summary>
        /// Permite realizar uma consulta usando Linq na tabela TipoCobranca
        /// </summary>
        /// <param name="predicate">um predicado Lambda para montar uma consulta parametrizada</param>
        /// <returns></returns>
        public IEnumerable<TipoCobranca> SelectIEnumerable(Expression<Func<TipoCobranca, bool>> predicate)
        {
            return service.SelectIEnumerable(predicate);
        }

    }
}

