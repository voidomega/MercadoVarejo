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
    public class CategoriasService
    {
        private BaseService<Categorias> service;



        public CategoriasService(MaContext Context)
        {
             service = new BaseService<Categorias>(Context);
        }

        public Int32 IdUsrUltEdicao {get; set;}

        
        
        

        
 
        /// <summary>
        /// Construtor da Classe
        /// </summary>
        public CategoriasService()
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
        /// insere uma entidade da classe Categorias
        /// </summary>
        /// <param name="categorias"></param>
        /// <returns></returns>
        public Categorias Post(Categorias categorias)
        {
            
            return service.PostReturn<CategoriasValidator>(categorias);
        }

        /// <summary>
        /// Edita uma entidade da classe Categorias
        /// </summary>
        /// <param name="categorias"></param>
        /// <returns></returns>
        public Categorias Put(Categorias categorias)
        {
                
                return service.PutReturn<CategoriasValidator>(categorias);
        }

        /// <summary>
        /// Exclui uma entidade da classe Categorias
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>        
        public Boolean Delete(int Id)
        {       
            return service.DeleteReturn(Id);
        }

        /// <summary>
        /// Faz um select "All" na tabela da classe Categorias
        /// </summary>
        /// <returns></returns>
        public List<Categorias> GetAllCategoriass()
        {
            return service.Get().ToList();
        }

        /// <summary>
        /// Retorna um único registro da classe Categorias a partir da PK
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Categorias GetCategoriasById(int  Id)
        {
            return service.Get(Id);
        }

        /// <summary>
        /// Permite realizar uma consulta usando Linq na tabela Categorias
        /// </summary>
        /// <param name="predicate">um predicado Lambda para montar uma consulta parametrizada</param>
        /// <returns></returns>
        public IEnumerable<Categorias> SelectIEnumerable(Expression<Func<Categorias, bool>> predicate)
        {
            return service.SelectIEnumerable(predicate);
        }

    }
}

