using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace VescFramework
{
    /// <summary>
    /// Clase para utilidades de password
    /// </summary>
    public class Password
    {
        /// <summary>
        /// Genera un password aleatorio
        /// Al menos 1 mayuscula, 1 minuscula, 1 número y un caracter especial
        /// </summary>
        /// <param name="length">Longitud del password a generar</param>
        /// <returns></returns>
        public static String BuildPassword(int length)
        {
            string password = string.Empty;
            Random rnd = new Random();
            string caracteresValidos = "qazxswedcvfrtgbnhyujmkiolp";
            char[] codigos = caracteresValidos.ToCharArray();
            password += codigos[rnd.Next(codigos.Count())].ToString().ToUpper();
            password += codigos[rnd.Next(codigos.Count())].ToString();
            caracteresValidos = "0123456789";
            codigos = caracteresValidos.ToCharArray();
            password += codigos[rnd.Next(codigos.Count())].ToString();
            caracteresValidos = "!%#?/";
            codigos = caracteresValidos.ToCharArray();
            password += codigos[rnd.Next(codigos.Count())].ToString();
            caracteresValidos = "qazxswedcvfrtgbnhyujmkiolp0123456789!%#?/";
            codigos = caracteresValidos.ToCharArray();
            int fin = length - password.Length;
            while(password.Length <= length)
            {
                password += codigos[rnd.Next(codigos.Count())].ToString();
            }
            return password;
        }
        /// <summary>
        /// Verifica que una contraseña tenga el formato correcto
        /// </summary>
        /// <param name="password">contraseña a validar</param>
        /// <returns></returns>
        public static bool Validate(string password)
        {
            return Regex.IsMatch(password, "^.*(?=.{6,})(?=.*[a-z])(?=.*[A-Z])(?=.*[\\d\\W]).*$");
        }
    }
}
