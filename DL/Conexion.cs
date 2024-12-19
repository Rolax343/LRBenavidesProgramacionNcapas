using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Conexion
    {
        public static string Get()
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["LRBenavidesProgramacionNCapas"].ConnectionString;
        
            return cadenaConexion;
        }
    }
}
