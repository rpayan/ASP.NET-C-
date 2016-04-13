using System;
using System.Web.Configuration;

namespace Ine.SihPublico.UI.Web.Utils
{
    public class Configuracion
    {
        public static String ObtenerCodigoSistema()
        {
            return WebConfigurationManager.AppSettings["CodigoSistema"];
        }

        public static String ObtenerNombreInterfaz()
        {
            return WebConfigurationManager.AppSettings["NombreInterfaz"];
        }
    }
}