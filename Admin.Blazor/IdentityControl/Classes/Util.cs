using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IdentityControl.Classes
{
    public static class Util
    {
        #region Security

        /// <summary>
        /// Transforma a string em MD5.
        /// </summary>
        /// <param name="source">String original.</param>
        /// <returns>MD5 Hash.</returns>
        public static string ToMd5(this string source)
        {
            // MD5 Creator.
            using MD5 md5Hash = MD5.Create();
            // Retornando hash.
            return GetMd5Hash(md5Hash, source);
        }

        /// <summary>
        /// Verifica se o Hash é equivalente ao da string.
        /// </summary>
        /// <param name="hash">MD5 String.</param>
        /// <param name="target">Alvo da comparação.</param>
        /// <returns>É hash.</returns>
        public static bool IsHashOf(this string hash, string target)
        {
            // MD5 Creator.
            using MD5 md5Hash = MD5.Create();
            // Alvo.
            string md5Target = GetMd5Hash(md5Hash, target);
            // Comparador.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            // Retornando igualdade.
            return comparer.Compare(md5Target, hash) == 0;
        }

        /// <summary>
        /// Obtem o hash md5.
        /// </summary>
        /// <param name="md5Hash">Hash.</param>
        /// <param name="source">String original.</param>
        /// <returns>MD5 Hash.</returns>
        private static string GetMd5Hash(MD5 md5Hash, string source)
        {
            // Computando o a string em byte.
            byte[] computed = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(source));
            // Builder.
            StringBuilder builder = new StringBuilder();
            // Cada byte para string hexadecimal.
            for (int i = 0; i < computed.Length; i++)
                builder.Append(computed[i].ToString("x2"));
            // Retornando a string hexadecimal.
            return builder.ToString();
        }

        #endregion
    }
}
