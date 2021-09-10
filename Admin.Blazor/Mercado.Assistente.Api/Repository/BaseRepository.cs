using Ma.MercadoAssistente.Api.Contexto;
using Ma.Interfaces;
using Ma.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;


namespace MercadoAssistente.Data.Layer.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {

        private MaContext Context = null;// ConnectionParams.AutoCreateContext ? new MaContext() :

        public BaseRepository(MaContext context)
        {
            Context = context;
        }

        public BaseRepository()
        {
            Context = new MaContext(MakeContextOptions.Build().Options);
        }


        public string GetInfo()
        {
            return string.Empty;// Context.InfoConn; //  .Database.GetDbConnection().ConnectionString;
        }


        public bool NoTracking {
            get {
                return Context != null ? Context.ChangeTracker.QueryTrackingBehavior == QueryTrackingBehavior.NoTracking
                    : false;
            }
            set {
                if (value == false)
                   Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
                else
                   Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            }
        }

        public void Insert(T obj)
        {
            
            Context.Set<T>().Add(obj);
            Context.SaveChanges();
        }

        public void Update(T obj)
        {
            Context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
        }

        
        public void Delete(Int32 id)
        {
            Context.Set<T>().Remove(Select(id));
            Context.SaveChanges();
        }

        public void Delete(long id)
        {
            Context.Set<T>().Remove(Select(id));
            Context.SaveChanges();
        }

        public IList<T> Select()
        {
            
            return Context.Set<T>().ToList();
        }

        private void DefineTracking()
        {
            if (NoTracking)
                Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            else
                Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
        }

        public IEnumerable<T> SelectIEnumerable(Expression<Func<T, bool>> predicate)
        {            
            return Context.Set<T>().Where(predicate);
        }

        public T Select(Int32 id)
        {
            return Context.Set<T>().Find(id);
        }

        public T Select(long id)
        {
            return Context.Set<T>().Find(id);
        }



        public void Delete(Expression<Func<T, bool>> predicate)
        {
           var itemToDelete = Context.Set<T>().Where(predicate).FirstOrDefault();
            if(itemToDelete!=null)
            {
                Context.Set<T>().Remove(itemToDelete);
                Context.SaveChanges();
            }
        }

        public T Select(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).FirstOrDefault();
        }

        public T InsertReturn(T obj)
        {
            Context.Set<T>().Add(obj);
            Context.SaveChanges();
            return obj;
        }

        public T UpdateReturn(T obj)
        {
            Context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
            return obj;
        }


        public bool DeleteReturn(long id)
        {
            Object objRemove = Select(id);
            if (objRemove != null)
            {
                Context.Set<T>().Remove((T)objRemove);
                return Context.SaveChanges() > 0;
            }
            else return false;
        }

        public bool DeleteReturn(int id)
        {
            Object objRemove = Select(id);
            if (objRemove != null)
            {
                Context.Set<T>().Remove((T)objRemove);
                return Context.SaveChanges() > 0;
            }
            else return false;
        }

        public bool DeleteReturn(Expression<Func<T, bool>> predicate)
        {
            var itemToDelete = Context.Set<T>().Where(predicate).FirstOrDefault();
            if (itemToDelete != null)
            {
                Context.Set<T>().Remove(itemToDelete);
                return Context.SaveChanges() > 0;
            }
            else return false;
        }

        public DbSet<T> GetDbSet()
        {
            return Context.Set<T>();
        }
    }
}
