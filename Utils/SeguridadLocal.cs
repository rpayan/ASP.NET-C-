using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using INE.ServiciosWeb.Base.Excepciones;
using INE.ServiciosWeb.Base.ReglasNegocio;
using Ine.SihPublico.UI.Web.AgenteEconomicoServicio_T;
using Ine.SihPublico.UI.Web.SeguridadServicio_T;

namespace Ine.SihPublico.UI.Web.Utils
{
    public class SeguridadLocal
    {

        public static ResultadoOperacion IniciarSesion(String usuario, String clave)
        {
            JavaScriptSerializer serializador = new JavaScriptSerializer();

            FormsAuthenticationTicket ticket;
          //  Usuario usuarioPagina;
            String datos;

          

          //  AgenteEconomico agente;
           // AgenteEconomicoAgenteTipo agenteEconomicoAgenteTipo;

            String nombreCliente = Red.ObtenerNombreEquipo();
            IPAddress ip = Red.ObtenerIP();
            IPAddress mascaraRed = Red.ObtenerMascaraRed(ip);
            IPAddress red = Red.ObtenerIPRed(ip, mascaraRed);

            SeguridadServicio_T.SeguridadContratoClient seg = new SeguridadContratoClient();


            var resultado = seg.IniciarSesion(red.ToString(), ip.ToString(), nombreCliente, Configuracion.ObtenerCodigoSistema(), usuario, clave);



            if (resultado == null) return new ResultadoOperacion() { EsExitoso = false };
            if (resultado.EsExitoso == true)
            {

                HttpContext.Current.Session["IdSesion"] = resultado.Identificador.Value;

                var sesion = seg.ObtenerSesionPorID(resultado.Identificador.Value);
                var cuenta = seg.ObtenerCuentaPorID(sesion.IdCuenta);
                FormsAuthentication.SetAuthCookie(usuario, true);


              //  usuarioPagina = new Usuario(usuario);
                Usuario usuarioPagina = new Usuario();

                usuarioPagina.IdSesion = sesion.IdSesion;
                usuarioPagina.CodigoSesion = sesion.Codigo;
                usuarioPagina.IdPersona = cuenta.IdPersona;
                usuarioPagina.Alias = usuario;
                usuarioPagina.IdCuenta = cuenta.IdCuenta;


                AgenteEconomicoServicio_T.AgenteEconomicoContratoClient ag = new AgenteEconomicoContratoClient();


                var agente = ag.ObtenerPorPersona(cuenta.IdPersona);

              

                usuarioPagina.IdAgenteEconomico = agente.IdAgenteEconomico;
     
               var agenteEconomicoAgenteTipo = ag.ObtenerAgenteEconomicoAgenteTipo(usuarioPagina.IdAgenteEconomico, 1); //El AgenteTipo 1 es para gasolineras

               usuarioPagina.IdAgenteEconomicoAgenteTipo = agenteEconomicoAgenteTipo.IdAgenteEconomicoAgenteTipo;
       
                datos = serializador.Serialize(usuarioPagina);


              //datos = serializador.Serialize(usuarioPagina);
              //datos = usuarioPagina.Alias;


                //ticket = new FormsAuthenticationTicket(1, FormsAuthentication.FormsCookieName, DateTime.Now,
                //         DateTime.Now.AddMinutes(FormsAuthentication.Timeout.TotalMinutes), false, datos);

                ticket = new FormsAuthenticationTicket(1, usuario, DateTime.Now,
                         DateTime.Now.AddMinutes(FormsAuthentication.Timeout.TotalMinutes), true, datos);

                string encTicket = FormsAuthentication.Encrypt(ticket);


                HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);

                faCookie.Expires = ticket.Expiration;
                faCookie.Path = FormsAuthentication.FormsCookiePath;

                HttpContext.Current.Response.Cookies.Add(faCookie);
                RefrescarContexto();

                return resultado; 
            }
            else
                return resultado;
        }

        public static void RefrescarContexto()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie != null)
            {
                if (HttpContext.Current != null)
                {
                    if (HttpContext.Current.User.Identity.Name == ".ASPXAUTH")
                    {
                        FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
                        JavaScriptSerializer serializador = new JavaScriptSerializer();
                        Usuario usuarioSerializado = serializador.Deserialize<Usuario>(ticket.UserData);

                        Usuario newUser = new Usuario(usuarioSerializado.Alias);
                        newUser.CodigoSesion = usuarioSerializado.CodigoSesion;
                        newUser.IdSesion = usuarioSerializado.IdSesion;
                        newUser.CodigoSesion = usuarioSerializado.CodigoSesion;
                        newUser.IdPersona = usuarioSerializado.IdPersona;
                        newUser.Alias = usuarioSerializado.Alias;
                        newUser.IdCuenta = usuarioSerializado.IdCuenta;

                        HttpContext.Current.User = newUser;

                    }
                   

        
                }
            }
        }

        public static void CerrarSesion()
        {
            try
            {

                SeguridadServicio_T.SeguridadContratoClient seg = new SeguridadContratoClient();

                if (Convert.ToString(HttpContext.Current.Session["IdSesion"]) != "")
                    seg.CerrarSesionPorID(Convert.ToInt32(HttpContext.Current.Session["IdSesion"]));
                if (HttpContext.Current != null)
                {
                    FormsAuthentication.SignOut();
                }

            }
            catch { }
        }

        public static List<Sistema> ObtenerListadoSistemasPorCuenta(string usuario)
        {

            SeguridadServicio_T.SeguridadContratoClient seg = new SeguridadContratoClient();

            try
            {
               // List<Sistema> resultado;

                List<Sistema> resultado;

                resultado = seg.ObtenerListadoSistemasPorCuenta(usuario).ToList();

               
              
                return resultado;
            }
            catch (FaultException<ExcepcionServicio> ex)
            {
                throw ex;
            }

        }

        public static List<Rol> ObtenerListadoRolesPorCuenta(String usuario, String codigoSistema)
        {
            SeguridadServicio_T.SeguridadContratoClient seg = new SeguridadContratoClient();

            try
            {
                // List<Sistema> resultado;

                List<Rol> resultado;

                resultado = seg.ObtenerListadoRolesPorCuenta(usuario, codigoSistema).ToList();


                return resultado;
            }
            catch (FaultException<ExcepcionServicio> ex)
            {
                throw ex;
            }

        }
       
        public static ResultadoOperacion CambiarContrasena(string nombreUsuario, string claveTemporal, string claveNueva, string claveNuevaConfirmacion)
        {
            SeguridadServicio_T.SeguridadContratoClient seg = new SeguridadContratoClient();
        
          var resultado = seg.CambiarContrasena(nombreUsuario, claveTemporal, claveNueva, claveNuevaConfirmacion);
          return resultado;
           
        }

         public static ResultadoOperacion GuardarPreguntaSecreta(string nombreUsuario, string claveNueva, string preguntaSecreta, string respuestaSecreta)
        {

            SeguridadServicio_T.SeguridadContratoClient seg = new SeguridadContratoClient();

          var resultado = seg.GuardarPreguntaSecreta(nombreUsuario,claveNueva,preguntaSecreta,respuestaSecreta);
          return resultado;
           
        }

         public static ResultadoOperacion EnviarClaveTemporal(string nombreUsuario, string preguntaSecretaCT, string respuestaSecretaCT)
         {
             SeguridadServicio_T.SeguridadContratoClient seg = new SeguridadContratoClient();
             var resultado = seg.EnviarClaveTemporal(nombreUsuario, preguntaSecretaCT, respuestaSecretaCT);
             return resultado;
         }

         public static String ObtenerPreguntaSecreta(string nombreUsuario)
         {
             SeguridadServicio_T.SeguridadContratoClient seg = new SeguridadContratoClient();
             var resultado = seg.ObtenerPreguntaSecreta(nombreUsuario);
             return resultado;
         }



         public static Boolean PoseePermiso(List<Accion> acciones, String valor)
         {
             Int32 resultado = (from t in acciones
                                where t.Codigo == valor
                                select t).Count();
             if (resultado > 0)
                 return true;
             else
                 return false;
         }





    }
}