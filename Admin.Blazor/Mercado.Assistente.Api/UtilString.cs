using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteOn.Valor.PortalCliente.Api
{
    /// <summary>
    /// Classe de Utilitario
    /// s para formatar strings.
    /// </summary>
    public static class UtilString
    {
        /// <summary>
        /// Remove acentos 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="RemoveEspecialChars"></param>
        /// <returns></returns>

        public static string RemoveDiacritics(string text,Boolean RemoveEspecialChars = true)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }
            if (RemoveEspecialChars)
                return UtilString.RemoveSpecialCharacters(stringBuilder.ToString().Normalize(NormalizationForm.FormC));
            else
                return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        /// <summary>
        /// Remove caracteres especiais
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveSpecialCharacters(this string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

    }
}