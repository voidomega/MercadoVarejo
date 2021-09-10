using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using Ma.MercadoAssistente.Api.Contexto;
using Ma.MercadoAssistente.Api.Entidades;
using Ma.Interfaces;
using Ma.Domain.Entities;

using MercadoAssistente.Validators;

using System.Linq.Expressions;
using Ma.Service;

namespace MercadoAssistente.Api.Services
{
    public class FuncionariosService
    {
        private BaseService<Funcionarios> service;



        public FuncionariosService(MaContext Context)
        {
             service = new BaseService<Funcionarios>(Context);
        }

        public Int32 IdUsrUltEdicao {get; set;}

        
        
        

        
 
        /// <summary>
        /// Construtor da Classe
        /// </summary>
        public FuncionariosService()
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
        /// insere uma entidade da classe Funcionarios
        /// </summary>
        /// <param name="funcionarios"></param>
        /// <returns></returns>
        public Funcionarios Post(Funcionarios funcionarios)
        {
            
            return service.PostReturn<FuncionariosValidator>(funcionarios);
        }

        /// <summary>
        /// Edita uma entidade da classe Funcionarios
        /// </summary>
        /// <param name="funcionarios"></param>
        /// <returns></returns>
        public Funcionarios Put(Funcionarios funcionarios)
        {
                
                return service.PutReturn<FuncionariosValidator>(funcionarios);
        }

        /// <summary>
        /// Exclui uma entidade da classe Funcionarios
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>        
        public Boolean Delete(int Id)
        {       
            return service.DeleteReturn(Id);
        }

        /// <summary>
        /// Faz um select "All" na tabela da classe Funcionarios
        /// </summary>
        /// <returns></returns>
        public List<Funcionarios> GetAllFuncionarioss()
        {
            return service.Get().ToList();
        }

        /// <summary>
        /// Retorna um único registro da classe Funcionarios a partir da PK
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Funcionarios GetFuncionariosById(int  Id)
        {
            return service.Get(Id);
        }

        /// <summary>
        /// Permite realizar uma consulta usando Linq na tabela Funcionarios
        /// </summary>
        /// <param name="predicate">um predicado Lambda para montar uma consulta parametrizada</param>
        /// <returns></returns>
        public IEnumerable<Funcionarios> SelectIEnumerable(Expression<Func<Funcionarios, bool>> predicate)
        {
            return service.SelectIEnumerable(predicate);
        }

    }
}

