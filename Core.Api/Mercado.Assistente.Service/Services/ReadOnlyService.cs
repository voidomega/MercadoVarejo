using Ma.Domain.Entities;
using MercadoAssistente.Data.Layer.Context;
using Ma.Interfaces.Interfaces;
using MercadoAssistente.Data.Layer.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Ma.Service
{
    public class ReadOnlyService<T> : IReadOnlyService<T> where T : BaseEntity
    {

        private BaseRepository<T> repository = new BaseRepository<T>();
        public T Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("O Id não pode ser zero.");

            return repository.Select(id);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return repository.Select(predicate);
        }

        public IList<T> Get() => repository.Select();

        public IEnumerable<T> SelectIEnumerable(Expression<Func<T, bool>> predicate)
        {
            return repository.SelectIEnumerable(predicate);
        }
    }
}
