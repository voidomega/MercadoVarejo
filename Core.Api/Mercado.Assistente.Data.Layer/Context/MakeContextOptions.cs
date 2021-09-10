using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using MercadoAssistente.Data.Layer.Context;

namespace MercadoAssistente.Data.Layer.Context
{
    public static class MakeContextOptions
    {
        public static void AddDbContextPool(IServiceCollection services)
        {

            string InfoConn;

            string SetServerType = "SqlSrv";

            string ConnectionString = string.Empty; //"data source=189.1.170.38,1500;initial catalog=DicionarioSa2s;User Id=sDicionarioSa2s;Password=BytePrime@1213";// string.Empty;

            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();

            string ServerType = Environment.GetEnvironmentVariable("BOSERVERTYPE", EnvironmentVariableTarget.Process);
            string DataBaseName = Environment.GetEnvironmentVariable("BODATABASENAME", EnvironmentVariableTarget.Process);
            string ServerName = Environment.GetEnvironmentVariable("BOSERVERNAME", EnvironmentVariableTarget.Process);
            string ServerPort = Environment.GetEnvironmentVariable("BOSERVERPORT", EnvironmentVariableTarget.Process);
            string UserName = Environment.GetEnvironmentVariable("BOUSERNAME", EnvironmentVariableTarget.Process);
            string Password = Environment.GetEnvironmentVariable("BOUSERPASS", EnvironmentVariableTarget.Process);
            string ConnStr = Environment.GetEnvironmentVariable("CONNSTRFMT", EnvironmentVariableTarget.Process);




            Console.WriteLine("ServerType=" + ServerType);
            Console.WriteLine("DataBaseName=" + DataBaseName);

            Console.WriteLine("ServerName=" + ServerName + " | ServerPort=" + ServerPort);
            Console.WriteLine("UserName=" + UserName + " | Password=" + Password);
            Console.WriteLine("CONNSTRFMT=" + ConnStr);

            string finalConStr = string.Empty;
            if (string.IsNullOrEmpty(ConnStr))
            {
                if (!string.IsNullOrEmpty(ServerPort))
                {
                    ConnStr = "Host={0};Port={1};Pooling=true;Database={2};Username={3};Password={4};";
                    finalConStr = string.Format(ConnStr, ServerName, ServerPort, DataBaseName, UserName, Password);
                }
                else
                {
                    ConnStr = "Host={0};Pooling=true;Database={1};Username={2};Password={3};";
                    finalConStr = string.Format(ConnStr, ServerName, DataBaseName, UserName, Password);
                }
            }
            else
            {
                finalConStr = ConnStr.Replace("SRVNAM", ServerName).Replace("SRVPOR", ServerPort).Replace("DATNAM", DataBaseName).Replace("USRNAM", UserName).Replace("USRPWD", Password);
            }


            if (ConnectionString != string.Empty)
            {
                UserName = ConnectionParams.UserName;
                Password = ConnectionParams.Password;
                ServerType = ConnectionParams.ServerType;

                finalConStr = ConnectionString.Replace("USUARIO", UserName).Replace("SENHA", Password);
            }



            InfoConn = finalConStr;


            if (ConnectionParams.GetDataFromLocalCfg && ConnectionParams.DevConnectionString != string.Empty)
            {
                finalConStr = ConnectionParams.DevConnectionString;
                ServerType = ConnectionParams.ServerType;
            }


            //     throw new Exception(">>>>>>>>>>>>>>>>>>>>>>conn_STR=" + finalConStr +" <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");

            if (ServerType == "PostGreSql")
            {
                if (!optionsBuilder.IsConfigured)
                    services.AddDbContextPool<DefaultContext>(options => options.UseNpgsql(finalConStr));
               
            }
            else if (ServerType == "MySql")
            {
                if (!optionsBuilder.IsConfigured)
                    services.AddDbContextPool<DefaultContext>(options => options.UseMySql(finalConStr));
            }
            else if (ServerType == "SqlSrv")
            {
                if (!optionsBuilder.IsConfigured)
                    services.AddDbContextPool<DefaultContext>(options => options.UseSqlServer(finalConStr));

            }

          


            
           // return optionsBuilder;

        }

        public static DbContextOptionsBuilder Build()
        {

            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
            string ServerType = Environment.GetEnvironmentVariable("BOSERVERTYPE", EnvironmentVariableTarget.Process);
            string DataBaseName = Environment.GetEnvironmentVariable("BODATABASENAME", EnvironmentVariableTarget.Process);
            string ServerName = Environment.GetEnvironmentVariable("BOSERVERNAME", EnvironmentVariableTarget.Process);
            string ServerPort = Environment.GetEnvironmentVariable("BOSERVERPORT", EnvironmentVariableTarget.Process);
            string UserName = Environment.GetEnvironmentVariable("BOUSERNAME", EnvironmentVariableTarget.Process);
            string Password = Environment.GetEnvironmentVariable("BOUSERPASS", EnvironmentVariableTarget.Process);
            string ConnStr = Environment.GetEnvironmentVariable("BOCONNSTRFMT", EnvironmentVariableTarget.Process);

            string finalConStr = string.Empty;
            if (string.IsNullOrEmpty(ConnStr))
            {
                if (!string.IsNullOrEmpty(ServerPort))
                {
                    ConnStr = "Host={0};Port={1};Pooling=true;Database={2};Username={3};Password={4};";
                    finalConStr = string.Format(ConnStr, ServerName, ServerPort, DataBaseName, UserName, Password);
                }
                else
                {
                    ConnStr = "Host={0};Pooling=true;Database={1};Username={2};Password={3};";
                    finalConStr = string.Format(ConnStr, ServerName, DataBaseName, UserName, Password);
                }
            }
            else
            {
                finalConStr = ConnStr.Replace("SRVNAM", ServerName).Replace("SRVPOR", ServerName).Replace("DATNAM", ServerName).Replace("USRNAM", ServerName).Replace("USRPWD", ServerName);
            }


            if (ConnectionParams.GetDataFromLocalCfg && ConnectionParams.DevConnectionString != string.Empty)
            {
                finalConStr = ConnectionParams.DevConnectionString;
                ServerType = ConnectionParams.ServerType;
            }



            if (ServerType == "PostGreSql")
            {
                if (!optionsBuilder.IsConfigured)
                    optionsBuilder.UseNpgsql(finalConStr);
            }
            else if (ServerType == "MySql")
            {
                if (!optionsBuilder.IsConfigured)
                    optionsBuilder.UseMySql(finalConStr);
            }
            else if (ServerType == "SqlSrv")
            {
                if (!optionsBuilder.IsConfigured)                   
                   optionsBuilder.UseSqlServer(finalConStr);
            }



             return optionsBuilder;

        }
    }
    
}
