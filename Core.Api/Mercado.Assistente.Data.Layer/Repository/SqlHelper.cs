using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Mercado.Assistente.Domain.Entities;
using Ma.Interfaces;
using Ma.Domain.Entities;
using MercadoAssistente.Data.Layer.Context;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Transactions;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.SqlClient;

namespace MercadoAssistente.Data.Layer.Repository
{
    public class SqlHelper : ISqlHelper
    {

        private DefaultContext defaultContext;

        public SqlHelper()
        {
        }


        /// <summary>
        /// Acesso ao Contexto Local
        /// ///  </summary>
        /// <returns></returns>
        public DbContext LiveContext()
        {           
            ValidContext();
            return defaultContext;
        }

        public DbConnection GetInternalConnection()
        {
            return defaultContext.Database.GetDbConnection();
        }
      
        /// <summary>
        /// Aborta a transação cancelando as operações realizadas
        /// </summary>
        public void RollabackTransaction()
        {
            ValidContext();
            if (defaultContext != null)
                defaultContext.Database.RollbackTransaction();
        }
       
        /// <summary>
        /// Inicializa a transação
        /// </summary>
        /// <returns></returns>
        public IDbContextTransaction StartTransaction()
        {
            ValidContext();
            return defaultContext.Database.BeginTransaction();           
        }
       
        /// <summary>
        /// Finaliza a transação gravando as operações realizadas
        /// </summary>
        public void CommitTransaction()
        {
            ValidContext();            
                defaultContext.Database.CommitTransaction();
        }

        /// <summary>
        /// Inicializa o Contexto
        /// </summary>
        /// <returns></returns>
        public bool CreateContext()
        {
            defaultContext = new DefaultContext(MakeContextOptions.Build().Options);
            return true;
        }

        public bool CreateContext(DefaultContext context)
        {
            defaultContext = context;
            return true;
        }



        /// <summary>
        /// Executa comando Sql no Database que não exija parametros
        /// se necessitar de usar parâmetros usar os métodos que suportam parâmetros
        /// </summary>
        /// <param name="SqlString"></param>
        /// <returns></returns>
        [Obsolete]
        public object ExecuteSql(string SqlString)
        {
            ValidContext();
            return defaultContext.Database.ExecuteSqlCommand(SqlString);
        }

        /// <summary>
        /// Executa comando Sql no Database aceita parametros genericos        
        /// </summary>
        /// <param name="SqlString"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        [Obsolete]
        public object ExecuteSql(string SqlString, object[] Parameters)
        {
            ValidContext();
            return defaultContext.Database.ExecuteSqlCommand(SqlString,Parameters);
        }

        /// <summary>
        /// Executa comando Sql no Database aceita parametros do tipo DbParameter
        /// </summary>
        /// <param name="SqlString"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        [Obsolete]
        public object ExecuteSql(string SqlString, DbParameter[] Parameters)
        {
            ValidContext();
            return defaultContext.Database.ExecuteSqlCommand(SqlString, Parameters);
        }

        /// <summary>
        /// Executa comando Sql no Database aceita parametros do tipo MySqlParameter
        /// para ser usando quando o database for MySql
        /// </summary>
        /// <param name="SqlString"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        
        public object ExecuteSql(string SqlString, MySqlParameter[] Parameters)
        {
            ValidContext();
            return defaultContext.Database.ExecuteSqlRaw(SqlString, Parameters);
        }

        /// <summary>
        /// Executa comando Sql no Database aceita parametros do tipo NpgsqlParameter
        /// para ser usando quando o database for PostGreSql
        /// </summary>
        /// <param name="SqlString"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
      
        public object ExecuteSql(string SqlString, NpgsqlParameter[] Parameters)
        {
            
            ValidContext();
            return defaultContext.Database.ExecuteSqlRaw(SqlString, Parameters);
        }

        /// <summary>
        /// Preenche uma coleção do tipo Passado usando uma consulta Sql
        /// não usar esse método com consultas parametrizadas
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="SqlString"></param>
        /// <returns></returns>
        public IQueryable<T> ExecuteSqlFill<T>(string SqlString) where T : BaseEntity
        {
            ValidContext();
            return defaultContext.Set<T>().FromSqlRaw(SqlString);
        }

        /// <summary>
        /// Preenche uma coleção do tipo Passado usando uma consulta Sql
        /// método para consultas parametrizadas, aceita parâmetros genericos
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="SqlString"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public IQueryable<T> ExecuteSqlFill<T>(string SqlString, object[] Parameters) where T : BaseEntity
        {
            ValidContext();
            return defaultContext.Set<T>().FromSqlRaw(SqlString, Parameters);
        }

        /// <summary>
        /// Preenche uma coleção do tipo Passado usando uma consulta Sql método
        /// para consultas parametrizadas, aceita parâmetros do tipo MySqlParameter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="SqlString"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public IQueryable<T> ExecuteSqlFill<T>(string SqlString, MySqlParameter[] Parameters) where T : BaseEntity
        {
            ValidContext();
            return defaultContext.Set<T>().FromSqlRaw(SqlString, Parameters);
        }

        /// <summary>
        /// Preenche uma coleção do tipo Passado usando uma consulta Sql método
        /// para consultas parametrizadas, aceita parâmetros do tipo NpgsqlParameter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="SqlString"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public IQueryable<T> ExecuteSqlFill<T>(string SqlString, NpgsqlParameter[] Parameters) where T : BaseEntity
        {
            ValidContext();
            return defaultContext.Set<T>().FromSqlRaw(SqlString, Parameters);
        }

        private void ValidContext()
        {
            if (defaultContext == null)
                throw new Exception("Contexto não inicializado.");
        }

        public object ExecuteSql(string SqlString, SqlParameter[] Parameters)
        {
            ValidContext();
            return defaultContext.Database.ExecuteSqlRaw(SqlString, Parameters);
        }

        public IQueryable<T> ExecuteSqlFill<T>(string SqlString, SqlParameter[] Parameters) where T : BaseEntity
        {
            ValidContext();
            return defaultContext.Set<T>().FromSqlRaw(SqlString, Parameters);
        }
    }
}
