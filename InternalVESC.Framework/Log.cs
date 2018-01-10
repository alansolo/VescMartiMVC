using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace VescFramework
{
    /// <summary>
    /// Administra el log 
    /// </summary>
    public class Log
    {
        /// <summary>
        /// Escribe un registro en el log
        /// </summary>
        /// <param name="user"></param>
        /// <param name="error"></param>
        public static void Write(string user, string error)
        {
            try
            {
                error = string.Format("{0} :: {1} :: {2} ", DateTime.Now, user, error);
                StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["pathLog"].ToString(), true);
                sw.WriteLine(error);
                sw.Close();
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// Escribe un registro en el log
        /// </summary>
        /// <param name="user"></param>
        /// <param name="exception"></param>
        public static void WriteException(string user, Exception exception)
        {
            try
            {
                string error = string.Format("{0} :: {1} :: {2} :: {3}", DateTime.Now, user, exception.Message , exception.StackTrace);
                StreamWriter streamWriter = new StreamWriter(ConfigurationManager.AppSettings["pathLog"].ToString(), true);
                streamWriter.WriteLine(error);
                streamWriter.Close();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
