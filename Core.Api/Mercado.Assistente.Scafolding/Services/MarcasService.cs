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
    public class MarcasService
    {
        private BaseService<Marcas> service;



        public MarcasService(DefaultContext Context)
        {
             service = new BaseService<Marcas>(Context);
        }

        public Int32 IdUsrUltEdicao {get; set;}

        
        
        

        
 
        /// <summary>
        /// Construtor da Classe
        /// </summary>
        public MarcasService()
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
        /// insere uma entidade da classe Marcas
        /// </summary>
        /// <param name="marcas"></param>
        /// <returns></returns>
        public Marcas Post(Marcas marcas)
        {
            
            return service.PostReturn<MarcasValidator>(marcas);
        }

        /// <summary>
        /// Edita uma entidade da classe Marcas
        /// </summary>
        /// <param name="marcas"></param>
        /// <returns></returns>
        public Marcas Put(Marcas marcas)
        {
                
                return service.PutReturn<MarcasValidator>(marcas);
        }

        /// <summary>
        /// Exclui uma entidade da classe Marcas
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>        
        public Boolean Delete(int Id)
        {       
            return service.DeleteReturn(Id);
        }

        /// <summary>
        /// Faz um select "All" na tabela da classe Marcas
        /// </summary>
        /// <returns></returns>
        public List<Marcas> GetAllMarcass()
        {
            return service.Get().ToList();
        }

        /// <summary>
        /// Retorna um único registro da classe Marcas a partir da PK
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Marcas GetMarcasById(int  Id)
        {
            return service.Get(Id);
        }

        /// <summary>
        /// Permite realizar uma consulta usando Linq na tabela Marcas
        /// </summary>
        /// <param name="predicate">um predicado Lambda para montar uma consulta parametrizada</param>
        /// <returns></returns>
        public IEnumerable<Marcas> SelectIEnumerable(Expression<Func<Marcas, bool>> predicate)
        {
            return service.SelectIEnumerable(predicate);
        }

    }
}

