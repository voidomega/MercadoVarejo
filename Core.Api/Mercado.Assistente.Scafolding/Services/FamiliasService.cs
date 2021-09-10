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
    public class FamiliasService
    {
        private BaseService<Familias> service;



        public FamiliasService(DefaultContext Context)
        {
             service = new BaseService<Familias>(Context);
        }

        public Int32 IdUsrUltEdicao {get; set;}

        
        
        

        
 
        /// <summary>
        /// Construtor da Classe
        /// </summary>
        public FamiliasService()
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
        /// insere uma entidade da classe Familias
        /// </summary>
        /// <param name="familias"></param>
        /// <returns></returns>
        public Familias Post(Familias familias)
        {
            
            return service.PostReturn<FamiliasValidator>(familias);
        }

        /// <summary>
        /// Edita uma entidade da classe Familias
        /// </summary>
        /// <param name="familias"></param>
        /// <returns></returns>
        public Familias Put(Familias familias)
        {
                
                return service.PutReturn<FamiliasValidator>(familias);
        }

        /// <summary>
        /// Exclui uma entidade da classe Familias
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>        
        public Boolean Delete(int Id)
        {       
            return service.DeleteReturn(Id);
        }

        /// <summary>
        /// Faz um select "All" na tabela da classe Familias
        /// </summary>
        /// <returns></returns>
        public List<Familias> GetAllFamiliass()
        {
            return service.Get().ToList();
        }

        /// <summary>
        /// Retorna um único registro da classe Familias a partir da PK
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Familias GetFamiliasById(int  Id)
        {
            return service.Get(Id);
        }

        /// <summary>
        /// Permite realizar uma consulta usando Linq na tabela Familias
        /// </summary>
        /// <param name="predicate">um predicado Lambda para montar uma consulta parametrizada</param>
        /// <returns></returns>
        public IEnumerable<Familias> SelectIEnumerable(Expression<Func<Familias, bool>> predicate)
        {
            return service.SelectIEnumerable(predicate);
        }

    }
}

