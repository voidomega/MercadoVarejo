﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace ByteOn.Valor.PortalCliente.Api
{
    public static class UtilCrypto
    {
        public static string MD5Crypto(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
 
            byte[] result = md5.Hash;

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                stringBuilder.Append(result[i].ToString("x2"));
            }

            return stringBuilder.ToString();
        }
    }
}