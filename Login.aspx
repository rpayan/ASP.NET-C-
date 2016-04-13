﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/SihPublica.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Ine.SihPublico.UI.Web.Login" %>
<%@ Register assembly="DevExpress.Web.v14.2, Version=14.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ MasterType VirtualPath="~/PaginasMaestras/SihPublica.Master" %> 


<asp:Content ID="Content1" ContentPlaceHolderID="CphEncabezado" runat="server">    
    <link href="Estilos/Login.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
        .style7
        {
            height: 23px;
        }
        .style10
        {
            width: 43px;
        }
        .style13
        {
            width: 43px;
            height: 23px;
            text-align: right;
        }
        .style15
        {
            width: 102px;
        }
        .style17
        {
            width: 102px;
            text-align: left;
        }
        .style18
        {
            width: 43px;
            text-align: right;
        }
        .style19
        {
            width: 176px;
            text-align: right;
        font-family: Tahoma;
            font-size: 11pt;
        }
    .style20
    {
        font-family: Tahoma;
    }
        .style23
        {
            width: 176px;
        }
        .style24
        {
            width: 176px;
            height: 23px;
            text-align: right;
            font-family: Tahoma;
            font-size: 11pt;
        }
        .style26
        {
            width: 176px;
            height: 21px;
            text-align: right;
            font-family: Tahoma;
            font-size: 11pt;
        }
        .style29
    {
        width: 43px;
        height: 21px;
        text-align: right;
    }
        .style32
        {
            width: 102px;
            text-align: center;
            height: 23px;
        }
    </style>
    
     <script src="../../Scripts/Base/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../../Scripts/Base/jquery.blockUI.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">

function myFunction() {
   
    // document.getElementById("BtnSolicitarClaveTemporal").disabled = true;

    $.blockUI({
        message: '<div style=" width:200px;height:45px;" ><img src="/Imagenes/loading_spinner.gif"  style="position:absolute; left:0px; alt="" width="42" height="44" /><div style="position: absolute; top: 15px; left: 49px;" ><strong><label style="color:#C03736">Procesando Solicitud. Por Favor Espere...</label></strong></div></div>',
        baseZ: 9999999,
        // fadeIn: 700,
        //fadeOut: 700,
        //timeout: 1000,
        //showOverlay: false,
        //centerY: false,
        css: {
            //width: '200px',
            //  left: '',
            //right: '10px',
            //border: 'none',
            //padding: '5px',
            top: '20px'
        }
    });
    return true;
}

        </script>  

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="CphCuerpo" runat="server">   


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate> 

        <asp:Panel ID="PanForm" runat="server">                 
                
            <asp:Image ID="ImgLogin" runat="server" ImageUrl="~/Imagenes/login.jpg" />

            <asp:Panel runat="server" id="PanInicioSesion" style="width: 550px; z-index: 1; left: 240px; top: 10px; position: absolute; height: 175px; background-color: #E5CBBA;">
        
              <table style="position:relative; width:100%; height:100%">
                <tr>
                    <td colspan="3" style="text-align: center; background-color: #5D7B9D" 
                        class="style7">
                        <strong style="color: #FFFFFF; font-size: 11pt;" class="style20">Inicio de Sesión</strong></td>
                </tr>
                <tr>
                    <td>
                        * Usuario:
                    </td>
                    <td>
                        <dx:ASPxTextBox ID="TxtNombreUsuario" runat="server" Width="170px">
                        </dx:ASPxTextBox>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        * Contraseña:
                    </td>
                    <td>
                        <dx:ASPxTextBox ID="TxtPassword" Password="true" runat="server" Width="170px">
                        </dx:ASPxTextBox>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td style="float: left">
                        <dx:ASPxButton ID="BtnIniciarSesion" runat="server" Font-Bold="True" 
                            style="font-weight: 700" Text="Iniciar Sesión" Theme="Default" 
                            Width="170px" onclick="BtnIniciarSesion_Click" Font-Names="Tahoma">
                        </dx:ASPxButton>
                    </td>
                </tr>
                <tr>
                    <td class="style7" colspan="3">

                        <asp:Label ID="LblMensaje" runat="server" ForeColor="#CC0000" 
                            style="font-family: Tahoma" Font-Names="Verdana" ></asp:Label>
                    </td>
                </tr>
                  <tr>
                      <td class="style73" colspan="3" align="right">
                          <asp:LinkButton ID="LinkButtonOlvidoContrasena" runat="server" 
                              onclick="LinkButtonOlvidoContrasena_Click" Font-Names="Verdana" 
                              Font-Size="Small">Click aquí si olvidó su contraseña</asp:LinkButton>
                      </td>
                  </tr>
             </table>

        
           </asp:Panel>
    

            <asp:Panel runat="server" id="PanCambioCorreo" style="width: 550px; z-index: 1; left: 240px; top: 10px; position: absolute; height: 310px; background-color: #E5CBBA;">

             <table style=" width:100%; height:100%">
                <tr>
                    <td colspan="3" style="text-align: center; background-color: #5D7B9D" 
                        class="style7">
                        <strong style="color: #FFFFFF; font-size: 11pt;" class="style20">Clave Expirada - Escriba una nueva</strong></td>
                </tr>
                <tr>
                     <td style="float: right; margin-right: 100px">*Pregunta Secreta:</td>

                    <td>
                        <dx:ASPxComboBox ID="ASPxComboBoxPregunta" runat="server" AutoPostBack="true" 
                            onselectedindexchanged="ASPxComboBoxPregunta_SelectedIndexChanged" 
                            ValueType="System.String" Width="170px">
                        </dx:ASPxComboBox>
                    </td>
                    <td>
                    </td>
                </tr>
                 <tr>
                     <td style="float: right; margin-right: 100px">*Pregunta Personal:</td>
                     <td>
                         <dx:ASPxTextBox ID="TxtPreguntaPersonal" runat="server" Width="170px" 
                             Theme="Default">
                         </dx:ASPxTextBox>
                     </td>
                     <td>
                         </td>
                 </tr>
                <tr>
                    <td style="float: right; margin-right: 100px">*Repuesta:</td>
                    <td>
                        <dx:ASPxTextBox ID="TxtRepuesta" runat="server" Width="170px">
                        </dx:ASPxTextBox>
                    </td>
                    <td>
                    </td>
                </tr>
                 <tr>
                     <td style="float: right; margin-right: 100px">* Clave Actual / Temporal:</td>
                     <td>
                         <dx:ASPxTextBox ID="TxtClaveActual" runat="server" Password="true" 
                             Width="170px">
                         </dx:ASPxTextBox>
                     </td>
                     <td>
                     </td>
                 </tr>
                 <tr>
                    <td style="float: right; margin-right: 100px">* Clave Nueva:</td>
                     <td>
                         <dx:ASPxTextBox ID="TxtClaveNueva" runat="server" Password="true" 
                             ToolTip="La Clave debe tener 6 carácteres como mínimo, y debe contener al menos un número y un símbolo especial. Ejemplo: Estacion14*" 
                             Width="170px">
                         </dx:ASPxTextBox>
                     </td>
                     <td>
                         <asp:Label ID="LabelMensajeClave" runat="server" Text="Label" 
                             Font-Names="Verdana" Font-Size="Small" ForeColor="#CC0000"></asp:Label>
                     </td>
                 </tr>
                 <tr>
                      <td style="float: right; margin-right: 100px">* Confirme Clave:</td>
                     <td>
                         <dx:ASPxTextBox ID="TxtClaveNuevaConfirmacion" runat="server" Password="true" 
                             Width="170px">
                         </dx:ASPxTextBox>
                     </td>
                     <td>
                         </td>
                 </tr>
                <tr>
                    <td>
                       </td>
                    <td style="float: left">
                        <dx:ASPxButton ID="BtnCambiarContrasena" runat="server" Font-Bold="True" 
                            style="font-weight: 700" Text="Cambiar Contraseña" Theme="Default" 
                            Width="170px" onclick="BtnCambiarContrasena_Click1" Font-Names="Tahoma">
                        </dx:ASPxButton>
                    </td>
                    <td>
                        </td>
                </tr>
                <tr>
                    <td class="style7" colspan="3" align="left" style=" padding-left:5px" >

                        <asp:Label ID="LblMensaje2" runat="server" ForeColor="#CC0000" 
                            style="font-family: Tahoma" Font-Names="Verdana" ></asp:Label>



                    </td>
                </tr>
            </table>

             </asp:Panel>


            <asp:Panel runat="server" id="PanSolicitudClaveTemporal" style="width: 550px; z-index: 1; left: 240px; top: 10px; position: absolute; height: 190px; background-color: #E5CBBA;">
        
              <table style="position:relative; width:100%; height:100%">
                <tr>
                    <td colspan="3" style="text-align: center; background-color: #5D7B9D" 
                        class="style7">
                        <strong style="color: #FFFFFF; font-size: 11pt;" class="style20">Obtener Clave Temporal</strong></td>
                </tr>
                <tr>
                    <td>
                        * Pregunta Secreta:</td>
                    <td>
                        <dx:ASPxTextBox ID="TxtPreguntaSecretaCT" runat="server" ReadOnly="True" 
                            Width="170px">
                        </dx:ASPxTextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        * Respuesta Secreta:</td>
                    <td>
                        <dx:ASPxTextBox ID="txtRespuestaSecretaCT" runat="server" 
                            Width="170px">
                        </dx:ASPxTextBox>
                    </td>
                    <td>
                   
                    </td>
                </tr>
                <tr>            
                    <td>
                    
                    </td>
                    <td style="float: left">


                        <asp:Button ID="BtnSolicitarClaveTemporal"  Width="170px" OnClientClick="myFunction();" UseSubmitBehavior="false"
                          ClientIDMode="Static"  OnClick="BtnSolicitarClaveTemporal_Click" runat="server" Text="Obtener Clave Temporal" style="font-weight: 700" />

       
                    </td>
                    <td>
                    
                    </td>
                </tr>
                <tr>
                    <td class="style7" colspan="3">

                        <asp:Label ID="LblMensaje3" runat="server" ForeColor="#CC0000" 
                            style="font-family: Tahoma" Font-Names="Verdana" ></asp:Label>



                    </td>
                </tr>
                  <tr>
                      <td class="style79" colspan="3" align="right">
                          <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
                              Font-Names="Verdana" Font-Size="Small">Inicio</asp:LinkButton>
                      </td>
                  </tr>
             </table>
      
           </asp:Panel>


        </asp:Panel>

     <asp:HiddenField Id="HdfMensaje" runat="server" value="OK"></asp:HiddenField>

       </ContentTemplate>
  </asp:UpdatePanel>

</asp:Content>


