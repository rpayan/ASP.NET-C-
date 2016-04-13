using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Ine.SihPublico.UI.Web.Utils;

namespace Ine.SihPublico.UI.Web.PaginasMaestras
{
    public partial class SihPublica : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.User.Identity.IsAuthenticated)
            {
                LoginStatus1.Visible = false;               
                HyperLinkAyuda.Visible = false;
                ImgAyuda.Visible = false;
                ImgCandado.Visible = false;

                LblNombreCuenta.Visible = false;
                LblSeparador.Visible = false;



            }
            else
            {
            
                LoginStatus1.Visible = true;
                HyperLinkAyuda.Visible = true;
                ImgAyuda.Visible = true;
                ImgCandado.Visible = true;

                LblNombreCuenta.Visible = true;
                LblSeparador.Visible = true;
                LblNombreCuenta.Text = "[" + Page.User.Identity.Name + "]";

   
            }
        }

        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            SeguridadLocal.CerrarSesion();
        }


        //Con este código nos aseguramos que el control HyperLinkCambiarContrasena sea accedido y modificado desde cualquier pagian hija

        public bool HyperCambiarContrasenaVisibilidad 
        {
            get { return HyperLinkCambiarContrasena.Visible; }
            set { HyperLinkCambiarContrasena.Visible = value; }

        }


    }
  

}