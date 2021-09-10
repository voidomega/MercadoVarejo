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
    public class ImagensProdutoService
    {
        private BaseService<ImagensProduto> service;



        public ImagensProdutoService(DefaultContext Context)
        {
             service = new BaseService<ImagensProduto>(Context);
        }

        public Int32 IdUsrUltEdicao {get; set;}

        
        
        

        
 
        /// <summary>
        /// Construtor da Classe
        /// </summary>
        public ImagensProdutoService()
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
        /// insere uma entidade da classe ImagensProduto
        /// </summary>
        /// <param name="imagensproduto"></param>
        /// <returns></returns>
        public ImagensProduto Post(ImagensProduto imagensproduto)
        {
            
            return service.PostReturn<ImagensProdutoValidator>(imagensproduto);
        }

        /// <summary>
        /// Edita uma entidade da classe ImagensProduto
        /// </summary>
        /// <param name="imagensproduto"></param>
        /// <returns></returns>
        public ImagensProduto Put(ImagensProduto imagensproduto)
        {
                
                return service.PutReturn<ImagensProdutoValidator>(imagensproduto);
        }

        /// <summary>
        /// Exclui uma entidade da classe ImagensProduto
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>        
        public Boolean Delete(long Id)
        {       
            return service.DeleteReturn(Id);
        }

        /// <summary>
        /// Faz um select "All" na tabela da classe ImagensProduto
        /// </summary>
        /// <returns></returns>
        public List<ImagensProduto> GetAllImagensProdutos()
        {
            return service.Get().ToList();
        }

        /// <summary>
        /// Retorna um único registro da classe ImagensProduto a partir da PK
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ImagensProduto GetImagensProdutoById(long  Id)
        {
            return service.Get(Id);
        }

        /// <summary>
        /// Permite realizar uma consulta usando Linq na tabela ImagensProduto
        /// </summary>
        /// <param name="predicate">um predicado Lambda para montar uma consulta parametrizada</param>
        /// <returns></returns>
        public IEnumerable<ImagensProduto> SelectIEnumerable(Expression<Func<ImagensProduto, bool>> predicate)
        {
            return service.SelectIEnumerable(predicate);
        }

    }
}

