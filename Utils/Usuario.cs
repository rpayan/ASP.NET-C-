using System;
using System.Security.Principal;

namespace Ine.SihPublico.UI.Web.Utils
{
    public class Usuario : IPrincipal
    {
        #region "Atributos"

        public Int32 IdSesion { get; set; }
        public Guid CodigoSesion { get; set; }
        public String Alias { get; set; }
        public Int32 IdPersona { get; set; }
        public Int32 IdAgenteEconomico { get; set; }
        public Int32 IdCuenta { get; set; }
        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role) { return false; }
        public Int32 IdAgenteEconomicoAgenteTipo { get; set; }





        #endregion

        #region "metodos"

        public Usuario(string user)
        {
            this.Identity = new GenericIdentity(user);
        }

        public Usuario()
        {

        }

        #endregion

    }
}