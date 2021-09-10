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
    public class DadosCobrancasService
    {
        private BaseService<DadosCobrancas> service;



        public DadosCobrancasService(MaContext Context)
        {
             service = new BaseService<DadosCobrancas>(Context);
        }

        public Int32 IdUsrUltEdicao {get; set;}

        
        
        

        
 
        /// <summary>
        /// Construtor da Classe
        /// </summary>
        public DadosCobrancasService()
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
        /// insere uma entidade da classe DadosCobrancas
        /// </summary>
        /// <param name="dadoscobrancas"></param>
        /// <returns></returns>
        public DadosCobrancas Post(DadosCobrancas dadoscobrancas)
        {
            
            return service.PostReturn<DadosCobrancasValidator>(dadoscobrancas);
        }

        /// <summary>
        /// Edita uma entidade da classe DadosCobrancas
        /// </summary>
        /// <param name="dadoscobrancas"></param>
        /// <returns></returns>
        public DadosCobrancas Put(DadosCobrancas dadoscobrancas)
        {
                
                return service.PutReturn<DadosCobrancasValidator>(dadoscobrancas);
        }

        /// <summary>
        /// Exclui uma entidade da classe DadosCobrancas
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>        
        public Boolean Delete(long Id)
        {       
            return service.DeleteReturn(Id);
        }

        /// <summary>
        /// Faz um select "All" na tabela da classe DadosCobrancas
        /// </summary>
        /// <returns></returns>
        public List<DadosCobrancas> GetAllDadosCobrancass()
        {
            return service.Get().ToList();
        }

        /// <summary>
        /// Retorna um único registro da classe DadosCobrancas a partir da PK
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public DadosCobrancas GetDadosCobrancasById(long  Id)
        {
            return service.Get(Id);
        }

        /// <summary>
        /// Permite realizar uma consulta usando Linq na tabela DadosCobrancas
        /// </summary>
        /// <param name="predicate">um predicado Lambda para montar uma consulta parametrizada</param>
        /// <returns></returns>
        public IEnumerable<DadosCobrancas> SelectIEnumerable(Expression<Func<DadosCobrancas, bool>> predicate)
        {
            return service.SelectIEnumerable(predicate);
        }

    }
}

