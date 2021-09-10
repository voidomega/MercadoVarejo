using System;
using System.Collections.Generic;
using System.Text;


namespace MercadoAssistente.Data.Layer.Context
{
    public static class ConnectionParams
    {
        public static string UserName = string.Empty;
        public static string Password = string.Empty;
        public static string ServerType = string.Empty;
        public static Boolean AutoCreateContext = true;        
        public static string DevConnectionString = string.Empty;
        public static Boolean GetDataFromLocalCfg = false;        
    }
}
