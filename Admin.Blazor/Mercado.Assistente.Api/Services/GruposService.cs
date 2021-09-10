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
    public class GruposService
    {
        private BaseService<Grupos> service;



        public GruposService(MaContext Context)
        {
             service = new BaseService<Grupos>(Context);
        }

        public Int32 IdUsrUltEdicao {get; set;}

        
        
        

        
 
        /// <summary>
        /// Construtor da Classe
        /// </summary>
        public GruposService()
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
        /// insere uma entidade da classe Grupos
        /// </summary>
        /// <param name="grupos"></param>
        /// <returns></returns>
        public Grupos Post(Grupos grupos)
        {
            
            return service.PostReturn<GruposValidator>(grupos);
        }

        /// <summary>
        /// Edita uma entidade da classe Grupos
        /// </summary>
        /// <param name="grupos"></param>
        /// <returns></returns>
        public Grupos Put(Grupos grupos)
        {
                
                return service.PutReturn<GruposValidator>(grupos);
        }

        /// <summary>
        /// Exclui uma entidade da classe Grupos
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>        
        public Boolean Delete(int Id)
        {       
            return service.DeleteReturn(Id);
        }

        /// <summary>
        /// Faz um select "All" na tabela da classe Grupos
        /// </summary>
        /// <returns></returns>
        public List<Grupos> GetAllGruposs()
        {
            return service.Get().ToList();
        }

        /// <summary>
        /// Retorna um único registro da classe Grupos a partir da PK
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Grupos GetGruposById(int  Id)
        {
            return service.Get(Id);
        }

        /// <summary>
        /// Permite realizar uma consulta usando Linq na tabela Grupos
        /// </summary>
        /// <param name="predicate">um predicado Lambda para montar uma consulta parametrizada</param>
        /// <returns></returns>
        public IEnumerable<Grupos> SelectIEnumerable(Expression<Func<Grupos, bool>> predicate)
        {
            return service.SelectIEnumerable(predicate);
        }

    }
}

