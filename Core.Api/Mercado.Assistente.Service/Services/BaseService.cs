using FluentValidation;
using Ma.Domain.Entities;
using MercadoAssistente.Data.Layer.Context;
using Ma.Interfaces;
using MercadoAssistente.Data.Layer.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;


namespace Ma.Service
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        private BaseRepository<T> repository;

        public void SetDefaultContext(DefaultContext defaultContext)
        {            
             repository = new BaseRepository<T>(defaultContext);
        }

        public BaseService(DefaultContext Context)
        {
            repository = new BaseRepository<T>(Context);
        }



        public BaseService()
        {
            var context = new DefaultContext(MakeContextOptions.Build().Options);
            repository = new BaseRepository<T>(context);
        }


        public bool NoTracking
        {
            get
            {
                return repository.NoTracking;
            }
            set
            {
                repository.NoTracking = value;
            }
        }

        public T Post<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());
            repository.Insert(obj);
            return obj;
        }

        public T Put<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Update(obj);
            return obj;
        }

        public void Delete(Int32 id)
        {
            if (id == 0)
                throw new ArgumentException("O Id não pode ser zero.");

            repository.Delete(id);
        }

        public void Delete(long id)
        {
            if (id == 0)
                throw new ArgumentException("O Id não pode ser zero.");

            repository.Delete(id);
        }

        public IList<T> Get() => repository.Select();

        public T Get(Int32 id)
        {
            if (id == 0)
                throw new ArgumentException("O Id não pode ser zero.");

            return repository.Select(id);
        }

        public T Get(long id)
        {
            if (id == 0)
                throw new ArgumentException("O Id não pode ser zero.");

            return repository.Select(id);
        }

        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("Registros não encontrados!");

            validator.ValidateAndThrow(obj);
        }

        public IEnumerable<T> SelectIEnumerable(Expression<Func<T, bool>> predicate)
        {
            return repository.SelectIEnumerable(predicate);
        }

        public void Delete(Expression<Func<T, bool>> predicate)
        {         
             repository.Delete(predicate);
        }

        public string GetInfo()
        {
            return repository.GetInfo();
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return repository.Select(predicate);
        }

        public bool DeleteReturn(int id)
        {
            return repository.DeleteReturn(id);
        }

        public bool DeleteReturn(long id)
        {
            return repository.DeleteReturn(id);
        }

        public bool DeleteReturn(Expression<Func<T, bool>> predicate)
        {
            return repository.DeleteReturn(predicate);
        }

        public T PostReturn<V>(T obj) where V : AbstractValidator<T>
        {
            return repository.InsertReturn(obj);
        }

        public T PutReturn<V>(T obj) where V : AbstractValidator<T>
        {
            return repository.UpdateReturn(obj);
        }
    }
}
