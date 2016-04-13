using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INE.ServiciosWeb.Base.ReglasNegocio;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.Script.Serialization;

using System.ServiceModel;
using INE.ServiciosWeb.Base.Excepciones;
using Ine.SihPublico.UI.Web.SeguridadServicio_T;
using  Ine.SihPublico.UI.Web.Utils;



namespace Ine.SihPublico.UI.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.HyperCambiarContrasenaVisibilidad = false;

            if (!Page.IsPostBack)
            {
                //   Master.HyperCambiarContrasenaVisibilidad = false;
                PanCambioCorreo.Visible = false;
                TxtPreguntaPersonal.Enabled = false;
                LinkButtonOlvidoContrasena.Visible = false;
                PanSolicitudClaveTemporal.Visible = false;
                LinkButton1.Visible = false;
              
              //  TxtPreguntaPersonalCT.ReadOnly = true;
                LabelMensajeClave.Visible = false;
                BtnSolicitarClaveTemporal.Enabled = true;


                ASPxComboBoxPregunta.Items.Add("Dónde nació tu mamá?");
                ASPxComboBoxPregunta.Items.Add("Cuál es el nombre de tu mascota?");
                ASPxComboBoxPregunta.Items.Add("Cuál es tu película favorita?");
                ASPxComboBoxPregunta.Items.Add("Pregunta Personal");

            }


        }

        protected void BtnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                LblMensaje.Visible = true;

                var resultado = SeguridadLocal.IniciarSesion(TxtNombreUsuario.Text, TxtPassword.Text);

                if (resultado.EsExitoso)
                {

                    SeguridadServicio_T.SeguridadContratoClient seg = new SeguridadContratoClient();
                    

                    var sistemas =  seg.ObtenerListadoSistemasPorCuenta(TxtNombreUsuario.Text);
                    if (sistemas.Where(s => s.Codigo == Configuracion.ObtenerCodigoSistema()).Count() > 0)
                    {
                        Response.Redirect("~/RegistroCentral/CSI/Inventario.aspx");
                    }
                    else
                        LblMensaje.Text = "* No tiene permisos para acceder a esta interfaz.";

                }
                else
                {
                    LblMensaje.Visible = true;
                    //  ImgError.Visible = true;
                    //      LblMensaje.Text = "* Intento de conexión incorrecto. ";
                    foreach (var item in resultado.Infracciones)
                    {
                        if (item.Mensaje.Equals("La contraseña ha expirado, favor especificar una nueva contraseña."))
                        {
                            PanInicioSesion.Visible = false;
                            PanCambioCorreo.Visible = true;
                        }
                        else
                        {
                            LblMensaje.Text = "* Intento de conexión incorrecto. ";
                            LblMensaje.Text += "<br>- " + item.Mensaje;



                            if (TxtNombreUsuario.Text != "")   //Esto descomentariarlo y componerlo luego
                            {
                                LinkButtonOlvidoContrasena.Visible = true;
                            }
                            else
                            {
                                LinkButtonOlvidoContrasena.Visible = false;
                            }



                        }
                    }

                }
            }
            catch (FaultException<ExcepcionServicio> ex)
            {
                LblMensaje.Text = "* " + ex.Detail.Mensaje;
            }
        }

        protected void ASPxComboBoxPregunta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ASPxComboBoxPregunta.Text == "Pregunta Personal")
            {
                TxtPreguntaPersonal.Enabled = true;
            }
            else
            {
                TxtPreguntaPersonal.Enabled = false;
                
                
                TxtPreguntaPersonal.Text = "";
            }
        }

        protected void BtnCambiarContrasena_Click1(object sender, EventArgs e)
        {
            string PreguntaSec;

            

            if (ASPxComboBoxPregunta.Text == "Pregunta Personal")
            {
                if (TxtPreguntaPersonal.Text == "" | TxtRepuesta.Text == "")
                {
                    LblMensaje2.Text = "* Contraseña no fue actualizada. <br>- Debe especificar los campos mínimos.";
                    return;
                }
            }
            else 
            {
                if (ASPxComboBoxPregunta.Text == "" | TxtRepuesta.Text == "")
                {
                    LblMensaje2.Text = "* Contraseña no fue actualizada. <br>- Debe especificar los campos mínimos.";
                    return;
                }

            }

            if(ASPxComboBoxPregunta.Text == "Pregunta Personal")
            {
                PreguntaSec = TxtPreguntaPersonal.Text;
            }
            else
            {
                PreguntaSec = ASPxComboBoxPregunta.Text;
            }


            if(TxtClaveActual.Text == "" | TxtClaveNueva.Text == "" | TxtClaveNuevaConfirmacion.Text == "")
            {
                 LblMensaje2.Text = "* Contraseña no fue actualizada. <br>- Debe especificar los campos mínimos.";
                 return;
            }


            try
            {

                LblMensaje2.Visible = true;
                // ImgError.Visible = false;
                //var resultado = SI.CambiarContrasena(Page.User.Identity.Name, TxtClaveActual.Text, TxtClaveNueva.Text, TxtClaveNuevaConfirmacion.Text);

                SeguridadServicio_T.SeguridadContratoClient seg = new SeguridadContratoClient();


                var resultado = seg.CambiarContrasena(TxtNombreUsuario.Text, TxtClaveActual.Text, TxtClaveNueva.Text, TxtClaveNuevaConfirmacion.Text);
                if (resultado.EsExitoso)
                {
                    LblMensaje2.Text = "* Contraseña actualizada.";
                    HdfMensaje.Value = "Contraseña actualizada.";             
                }
                else
                {

                     foreach (var item in resultado.Infracciones)
                     {
                        if (item.Mensaje.Equals("Debe especificar los campos mínimos."))
                        {
                            LblMensaje2.Text = "Debe especificar los campos mínimos.";
                            return;
                        }
                        else if (item.Mensaje.Equals("La clave debe tener como mínimo 6 carácteres"))
                        {
                            LblMensaje2.Text = "La clave debe tener como mínimo 6 carácteres";
                            return;
                        }

                            else if (item.Mensaje.Equals("Formato de Clave Inválido.")) //Msg0010
                        {
                            LblMensaje2.Text = "Formato de Clave Inválido.";
                            return;
                        }


                              else if (item.Mensaje.Equals("La cuenta de usuario especificada no existe.")) //Msg0005
                        {
                            LblMensaje2.Text = "La cuenta de usuario especificada no existe.";
                            return;
                        }

                          else if (item.Mensaje.Equals("La clave especificada no coincide con la clave de la cuenta de usuario.")) //Msg0006
                        {
                            LblMensaje2.Text = "La clave especificada no coincide con la clave de la cuenta de usuario.";
                            return;
                        }

                          else if (item.Mensaje.Equals("Las contraseñas no coinciden, favor verificar.")) //Msg0007
                        {
                            LblMensaje2.Text = "Las contraseñas no coinciden, favor verificar.";
                            return;
                        }
                            

                         else if (item.Mensaje.Equals("La nueva contraseña ha sido utilizada anteriormente, favor vuelva a intentarlo.")) //Msg0008
                        {
                            LblMensaje2.Text = "La nueva contraseña ha sido utilizada anteriormente, favor vuelva a intentarlo.";
                            return;
                        }   
                    }

                }

                 //Si la invocacion del primer servicio es exitosa procedemos al segundo:

                    ResultadoOperacion resultado2 = new ResultadoOperacion();
         
                    resultado2 = seg.GuardarPreguntaSecreta(TxtNombreUsuario.Text, TxtClaveNueva.Text,PreguntaSec,TxtRepuesta.Text);


                if(resultado.EsExitoso)
                {
                    Response.Redirect("~/Login.aspx");
                }

                else
                {
                     foreach (var item in resultado2.Infracciones)
                     {
                        LblMensaje2.Visible = true;   
                        LblMensaje2.Text = "* Contraseña no fue actualizada. ";                    
                    }

                }
  
            }
            catch (FaultException<ExcepcionServicio> ex)
            {
                LblMensaje2.Text = "* " + ex.Detail.Mensaje;
            }

        }    

        protected void BtnSolicitarClaveTemporal_Click(object sender, EventArgs e)
        {
            if (txtRespuestaSecretaCT.Text == "")
            {
                LblMensaje3.Text = "Por favor complete los campos requeridos";
                return;
            }


            ResultadoOperacion resultado = new ResultadoOperacion();

            SeguridadServicio_T.SeguridadContratoClient seg = new SeguridadContratoClient();


            try {

                resultado = seg.EnviarClaveTemporal(TxtNombreUsuario.Text, TxtPreguntaSecretaCT.Text, txtRespuestaSecretaCT.Text);
                if (resultado.EsExitoso)
                {
                    BtnSolicitarClaveTemporal.Enabled = false;
                    LblMensaje3.Text = "Se ha enviado una clave temporal a su correo electrónico, inicie sesión";
                    LinkButton1.Visible = true;
                    return;
                 //   System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "Script3", "$.unblockUI()", true);

                }
                else
                {
                    foreach (var item in resultado.Infracciones)
                    {

                        if (item.Mensaje.Equals("Usuario inválido, favor verificar."))
                        {
                            LblMensaje3.Text = "Usuario inválido, favor verificar.";
                            LinkButton1.Visible = true;
                            return;
                        }
                        else if (item.Mensaje != "Usuario inválido, favor verificar." & (!resultado.EsExitoso))
                        {
                            LblMensaje3.Text = "Respuesta Incorrecta, intente de nuevo";
                            LinkButton1.Visible = true;
                            return;
                        }

                    }
                }

            
            }
            catch(Exception ex)
            {
                LblMensaje3.Text = "Ocurrió un problema con la solicitus de la clave, por favor intente más tarde";
                LinkButton1.Visible = true;
                return;

            }
  
                     
        }

        protected void LinkButtonOlvidoContrasena_Click(object sender, EventArgs e)
        {
            PanInicioSesion.Visible = false;
            PanCambioCorreo.Visible = false;
            PanSolicitudClaveTemporal.Visible = true;

            SeguridadServicio_T.SeguridadContratoClient seg = new SeguridadContratoClient();

            string PreguntaSecreta = seg.ObtenerPreguntaSecreta(TxtNombreUsuario.Text);

            if (PreguntaSecreta == "Usuario inválido, por favor verifique" | PreguntaSecreta == "Usuario ivalido, por favor verifique") //Temporal mientras se instala de nuevo el servicio
            {
                LblMensaje3.Text = "Usuario inválido, por favor verifique";
                BtnSolicitarClaveTemporal.Enabled = false;
                LinkButton1.Visible = true;
                return;
            }
            else
            {
                TxtPreguntaSecretaCT.Text = PreguntaSecreta;

            }


        }

        protected void ASPxComboBoxPreguntaCT_SelectedIndexChanged(object sender, EventArgs e)
        {
          

            }
        

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }

    }

}
