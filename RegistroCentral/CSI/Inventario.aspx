﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/SihPublica.Master" AutoEventWireup="true" CodeBehind="Inventario.aspx.cs" Inherits="Ine.SihPublico.UI.Web.RegistroCentral.CSI.Inventario" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>




<asp:Content ID="Content1" ContentPlaceHolderID="CphEncabezado" runat="server">

    <!-- Estilos -->
    <link href="../../Estilos/RegistroCentral/CSI/Inventario.css" rel="stylesheet" type="text/css" />      
    <link href="../../Estilos/Controles/GridView.css" rel="stylesheet" type="text/css" />
    <link href="../../Estilos/Controles/Boton.css" rel="stylesheet" type="text/css" />
    <!-- Scripts -->
    <script src="../../Scripts/RegistroCentral/CSI/Inventario.js" type="text/javascript"></script>

     <script src="../../Scripts/Base/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../../Scripts/Base/jquery.blockUI.js" type="text/javascript"></script>

    <style type="text/css">
        .style2
        {
            width: 85px;
        }
        .style3
        {
            width: 89px;
        }
        .style4
        {
            width: 114px;
        }
        .style6
        {
            width: 104px;
            height: 24px;
        }
        .style7
        {
            width: 105px;
        }
    </style>


<script type="text/javascript" >

function myFunction() {
   
    document.getElementById("ASPxGuardar").disabled = true;
    return true;
}


        </script>  


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CphCuerpo" runat="server">
    <asp:Panel Id="PanForm" runat="server" style="position:relative; top:0px;height:680px; width:890px;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
            <ContentTemplate>                             
                <asp:Panel ID="PanTitulo" runat="server">
                    <asp:Label ID="LblTitulo" runat="server" 
                        Text="Datos Generales del Agente Económico" 
                        style="font-family: Tahoma; font-weight: 700"></asp:Label>    
                </asp:Panel>
                <asp:Panel ID="PanAgenteEconomico" runat="server" >                    
                    <asp:Label ID="LblNombreEstacion" runat="server" Text="Nombre del Agente Económico:" CssClass="LblEstandar LblNegrilla"></asp:Label>    
                    <asp:Label ID="LblNombreEstacionValor" runat="server" CssClass="LblEstandar"></asp:Label>
                    <asp:Label ID="LblDepartamento" runat="server" Text="Departamento:" CssClass="LblEstandar LblNegrilla"></asp:Label>                       
                    <asp:Label ID="LblDepartamentoValor" runat="server" CssClass="LblEstandar"></asp:Label>                       
                    <asp:Label ID="LblMunicipio" runat="server" Text="Municipio:" CssClass="LblEstandar LblNegrilla"></asp:Label>                    
                    <asp:Label ID="LblMunicipioValor" runat="server" CssClass="LblEstandar"></asp:Label>
                    <asp:Label ID="LblNombreResponsable" runat="server" Text="Administrador:" CssClass="LblEstandar LblNegrilla"></asp:Label> 
                    <asp:Label ID="LblNombreResponsableValor" runat="server" CssClass="LblEstandar"></asp:Label> 
                                 
                    <asp:Label ID="LblCorreoElectronico" runat="server" Text="Correo Electrónico:" CssClass="LblEstandar LblNegrilla"></asp:Label> 
                    <asp:Label ID="LblCorreoElectronicoValor" runat="server" CssClass="LblEstandar"></asp:Label> 
                    


                </asp:Panel>
                
                <asp:Panel ID="PanFiltro" runat="server">
                                  
                     <asp:Label ID="Label2" runat="server" Text="Mes:" style="z-index: 1; font-family: Tahoma; font-size: 15px; left: 580px; top: 20px; position: absolute"></asp:Label>
                    <asp:DropDownList ID="DropDownListMes" AutoPostBack="True" Width="100px" runat="server" style="z-index: 1; left: 620px; top: 16px; 
                    position: absolute" OnSelectedIndexChanged="DropDownListMes_SelectedIndexChanged">
                    </asp:DropDownList>
                    

                <asp:Label ID="Label4" runat="server" Text="Año:" style="z-index: 1; font-family: Tahoma; font-size: 15px;left: 760px; top: 20px; position: absolute"></asp:Label>
                    <asp:DropDownList ID="DropDownListAno" Width="70px" runat="server" style="z-index: 1; left: 800px; top: 16px; position: absolute"></asp:DropDownList>

                </asp:Panel>     
                


                <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/Alerta.png" style="z-index: 1; left: 3px; top: 110px; position: absolute; height: 27px; width: 29px;" />
                <asp:Panel ID="PanAlerta" runat="server">
                <asp:Label ID="LblAlerta" runat="server" CssClass="LblAlerta"></asp:Label> 
                  

                </asp:Panel>                
                <asp:Panel ID="PanGrid" runat="server" >
                    <dx:ASPxGridView ID="GrdInventario" runat="server" 
                        AutoGenerateColumns="False" KeyFieldName="IdInventario" EnableCallBacks="False" 
                        OnHtmlRowCreated="GrdInventario_HtmlRowCreated" OnFocusedRowChanged="GrdInventario_FocusedRowChanged"
                        Width="890px" EnableRowsCache="false" 
                        style="position: relative; top: 0px; left: 0px;" Font-Names="Tahoma" >
                        <Columns>
                            <dx:GridViewDataColumn FieldName="IdInventario" Width="100" Visible="false"  UnboundType="Integer" />
                            <dx:GridViewDataColumn FieldName="IdVenta" Width="100" Visible="false" UnboundType="Integer" />
                            <dx:GridViewDataDateColumn FieldName="Fecha" VisibleIndex="0" Width="60px" >
                                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy"></PropertiesDateEdit>
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataColumn FieldName="HoraCorte" Width="200px"></dx:GridViewDataColumn>
                        </Columns>            
                        <Settings ShowVerticalScrollBar="True" VerticalScrollableHeight="200" ShowHorizontalScrollBar="true" />
                        <SettingsBehavior AllowFocusedRow="true" ProcessFocusedRowChangedOnServer="true" />              
                        <SettingsPager PageSize="31"></SettingsPager>
                        <SettingsLoadingPanel Text="Cargando&amp;hellip;"></SettingsLoadingPanel>
                    </dx:ASPxGridView>                        
                </asp:Panel>

                <asp:Panel ID="PanDetalle" runat="server" style="position: relative;">

                    <asp:GridView ID="GrdDetalle" runat="server" AutoGenerateColumns="False" GridLines="None" 
                        Visible="true" BackColor="#CAC6BF" 
                        style="font-family: Tahoma; font-size: smaller" Font-Names="Tahoma">
                        <Columns>
                            <asp:BoundField HeaderText ="Id"  DataField="Id" Visible="false" />
                            <asp:BoundField HeaderText ="Concepto"  DataField="Concepto" ItemStyle-HorizontalAlign="Left" />
                                                        
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtCampo2" runat="server"  Width="115px" CssClass="TxtEstandar TxtNumero" ReadOnly="true"
                                        style="margin-left: 0px; text-align:right;" ></asp:TextBox>                        
                                    <asp:FilteredTextBoxExtender ID="FtbCampo2" runat="server"
                                        TargetControlID="TxtCampo2" FilterType="Custom, Numbers" ValidChars=".," />
                                    <asp:HiddenField ID="HdfIdProducto2" runat="server" />
                                    <asp:HiddenField ID="HdfIdProductoXPresentacion2" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtCampo3" runat="server"  Width="115px" CssClass="TxtEstandar TxtNumero" ReadOnly="true"
                                        style="margin-left: 0px; text-align:right;" ></asp:TextBox>                        
                                    <asp:FilteredTextBoxExtender ID="FtbCampo3" runat="server"
                                        TargetControlID="TxtCampo3" FilterType="Custom, Numbers" ValidChars=".," />
                                    <asp:HiddenField ID="HdfIdProducto3" runat="server" />
                                    <asp:HiddenField ID="HdfIdProductoXPresentacion3" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtCampo4" runat="server"  Width="115px" CssClass="TxtEstandar TxtNumero" ReadOnly="true"
                                        style="margin-left: 0px; text-align:right;" ></asp:TextBox>                        
                                    <asp:FilteredTextBoxExtender ID="FtbCampo4" runat="server"
                                        TargetControlID="TxtCampo4" FilterType="Custom, Numbers" ValidChars=".," />
                                    <asp:HiddenField ID="HdfIdProducto4" runat="server" />
                                    <asp:HiddenField ID="HdfIdProductoXPresentacion4" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>


                           <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtCampo5" runat="server"  Width="115px" CssClass="TxtEstandar TxtNumero" ReadOnly="true"
                                        style="margin-left: 0px; text-align:right;" ></asp:TextBox>                        
                                    <asp:FilteredTextBoxExtender ID="FtbCampo5" runat="server"
                                        TargetControlID="TxtCampo5" FilterType="Custom, Numbers" ValidChars=".," />
                                    <asp:HiddenField ID="HdfIdProducto5" runat="server" />
                                    <asp:HiddenField ID="HdfIdProductoXPresentacion5" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtCampo6" runat="server"  Width="115px" CssClass="TxtEstandar TxtNumero" ReadOnly="true"
                                        style="margin-left: 0px; text-align:right;" ></asp:TextBox>                        
                                    <asp:FilteredTextBoxExtender ID="FtbCampo6" runat="server"
                                        TargetControlID="TxtCampo6" FilterType="Custom, Numbers" ValidChars=".," />
                                    <asp:HiddenField ID="HdfIdProducto6" runat="server" />
                                    <asp:HiddenField ID="HdfIdProductoXPresentacion6" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtCampo7" runat="server"  Width="115px" CssClass="TxtEstandar TxtNumero" ReadOnly="true"
                                        style="margin-left: 0px; text-align:right;" ></asp:TextBox>                        
                                    <asp:FilteredTextBoxExtender ID="FtbCampo7" runat="server"
                                        TargetControlID="TxtCampo7" FilterType="Custom, Numbers" ValidChars=".," />
                                    <asp:HiddenField ID="HdfIdProducto7" runat="server" />
                                    <asp:HiddenField ID="HdfIdProductoXPresentacion7" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>


                             <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtCampo8" runat="server"  Width="115px" CssClass="TxtEstandar TxtNumero" ReadOnly="true"
                                        style="margin-left: 0px; text-align:right;" ></asp:TextBox>                        
                                    <asp:FilteredTextBoxExtender ID="FtbCampo8" runat="server"
                                        TargetControlID="TxtCampo8" FilterType="Custom, Numbers" ValidChars=".," />
                                    <asp:HiddenField ID="HdfIdProducto8" runat="server" />
                                    <asp:HiddenField ID="HdfIdProductoXPresentacion8" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtCampo9" runat="server"  Width="115px" CssClass="TxtEstandar TxtNumero" ReadOnly="true"
                                        style="margin-left: 0px; text-align:right;" ></asp:TextBox>                        
                                    <asp:FilteredTextBoxExtender ID="FtbCampo9" runat="server"
                                        TargetControlID="TxtCampo9" FilterType="Custom, Numbers" ValidChars=".," />
                                    <asp:HiddenField ID="HdfIdProducto9" runat="server" />
                                    <asp:HiddenField ID="HdfIdProductoXPresentacion9" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>


                             <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtCampo10" runat="server"  Width="115px" CssClass="TxtEstandar TxtNumero" ReadOnly="true"
                                        style="margin-left: 0px; text-align:right;" ></asp:TextBox>                        
                                    <asp:FilteredTextBoxExtender ID="FtbCampo10" runat="server"
                                        TargetControlID="TxtCampo10" FilterType="Custom, Numbers" ValidChars=".," />
                                    <asp:HiddenField ID="HdfIdProducto10" runat="server" />
                                    <asp:HiddenField ID="HdfIdProductoXPresentacion10" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>


                             <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtCampo11" runat="server"  Width="115px" CssClass="TxtEstandar TxtNumero" ReadOnly="true"
                                        style="margin-left: 0px; text-align:right;" ></asp:TextBox>                        
                                    <asp:FilteredTextBoxExtender ID="FtbCampo11" runat="server"
                                        TargetControlID="TxtCampo11" FilterType="Custom, Numbers" ValidChars=".," />
                                    <asp:HiddenField ID="HdfIdProducto11" runat="server" />
                                    <asp:HiddenField ID="HdfIdProductoXPresentacion11" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>


                             <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtCampo12" runat="server"  Width="115px" CssClass="TxtEstandar TxtNumero" ReadOnly="true"
                                        style="margin-left: 0px; text-align:right;" ></asp:TextBox>                        
                                    <asp:FilteredTextBoxExtender ID="FtbCampo12" runat="server"
                                        TargetControlID="TxtCampo12" FilterType="Custom, Numbers" ValidChars=".," />
                                    <asp:HiddenField ID="HdfIdProducto12" runat="server" />
                                    <asp:HiddenField ID="HdfIdProductoXPresentacion12" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>


                        </Columns>                        
                        
                    </asp:GridView>                   
                   

                    <table style="width: 350px"  runat="server" visible="true" >                      
                        <tr>
                            <td class="style2" style="text-align: left">
                                <asp:Label ID="LblPrecioLtr0" runat="server" Text="Hora de Corte:" CssClass="LblEstandar"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <dx:ASPxTimeEdit ID="ASPxTimeEdit" runat="server"   Width="108px" 
                                    style="position:relative; text-align: left;" Font-Names="Tahoma" >                   
                                </dx:ASPxTimeEdit>
                            </td>
                            <td> &nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <table style="width: 100%; height: 64px;">
                    <tr>
                        <td class="style2">
                            <asp:Label ID="LblObservacion" runat="server" Text="Observación:"  
                                CssClass="LblEstandar"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="TxtObservacion" runat="server" Height="52px" 
                                style="text-align: left;  margin-left: 0px" TextMode="MultiLine" 
                                Width="780px" ReadOnly="True" Font-Names="Tahoma"></asp:TextBox>
                        </td>
                    </tr>
                    </table>        
                    <asp:Label ID="LblMensaje" runat="server" CssClass="LblAlerta"
                        style="width:650px; z-index: 1; left: 35px; top: 192px; text-align: left; position: absolute;" 
                        Font-Names="Tahoma">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </asp:Label>
                    <br />

                    <dx:ASPxButton ID="ASPxGuardar" runat="server" Text="Guardar" Font-Bold="True"
                        Font-Names="Tahoma" Theme="Default" Enabled="False" ClientIDMode="Static" ClientEnabled="true"                    
                        style="z-index: 1; left: 379px; top: 220px; position: absolute; height: 35px; width: 121px" 
                        Font-Size="9pt" onclick="ASPxGuardar_Click" ToolTip="Guardar Inventario" >
                        <BackgroundImage HorizontalPosition="left" ImageUrl="~/Imagenes/Guardar.png" 
                            Repeat="NoRepeat" VerticalPosition="center" />
                         <ClientSideEvents Click="myFunction" />
                    </dx:ASPxButton>


                     <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/Alerta.png" style="z-index: 1; left: 3px; top: 187px; position: absolute; height: 27px; width: 29px;" 
                        Visible="False" />

                </asp:Panel>


                <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server"                      
                        BackgroundCssClass="PupBackground" PopupControlID="PanComprobante" TargetControlID="HfPopup"
                        CancelControlID="btnClose" OnCancelScript="Cancel()">
                </asp:ModalPopupExtender>


                <asp:Panel ID="PanComprobante" runat="server" BackColor="White" Width="800px" Height="350px"
                    BorderWidth="2px">

                <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/Alerta2.png" style="z-index: 10; left: 0px; top: 7px; position: relative; height: 32px; width: 33px" />

                <asp:Label ID="LblTitulo1" runat="server" style="text-align: left; font-weight: 700; color: #404040" 
                        Font-Names="Tahoma" ForeColor="#29166F" ></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="LblTitulo2" runat="server" 
                     style="text-align: left; font-weight: 700; color: #404040; font-size: small;" 
                        Font-Names="Tahoma" ></asp:Label>

                     
                     <br />
                     <br />
             
                        <table id="Table1" style="width: 457px"  runat="server" visible="true" >                      
                        <tr>
                            <td class="style7" style="text-align: left">
                                <asp:Label ID="Label1" runat="server" CssClass="LblEstandar" 
                                    Text="Fecha Inventario:"></asp:Label>
                            </td>
                            <td style="text-align: center" class="style4">
                                <dx:ASPxTextBox ID="TxtFechaInventario" runat="server" Font-Names="Tahoma" 
                                    Height="20px" ReadOnly="true" Theme="Office2010Black" Width="108px">
                                </dx:ASPxTextBox>
                            </td>
                            <td class="style6"> 
                                <asp:Label ID="Label5" runat="server" CssClass="LblEstandar" 
                                    Text="Hora de Corte:"></asp:Label>
                            </td>
                            <td>
                                <dx:ASPxTimeEdit ID="ASPxTimeEdit1" runat="server" Font-Names="Tahoma" 
                                    style="position:relative; text-align: left;" Width="108px">
                                </dx:ASPxTimeEdit>
                            </td>
                        </tr>
                    </table>

                    <br />
                
                     <asp:GridView ID="GrdComprobante" runat="server" AutoGenerateColumns="False"  GridLines="None" 
                        Visible="true" style="font-family:Tahoma; font-size: smaller; position: relative; top: 0px; left: 6px;" 
                        Font-Names="Tahoma">

                        <Columns>
                            <asp:BoundField HeaderText ="Id" DataField="Id" Visible="false"/>
   
                            <asp:BoundField HeaderText ="Concepto"  DataField="Concepto" HeaderStyle-BackColor=#6D6C6E HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Left" />
                                                        
                            <asp:TemplateField HeaderStyle-BackColor=#6D6C6E HeaderStyle-ForeColor="White" >
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtCampo2" runat="server"  Width="100px" CssClass="TxtEstandar TxtNumero" ReadOnly="true"
                                        style="margin-left: 0px; text-align:right;" ></asp:TextBox>                        
                                    <asp:FilteredTextBoxExtender ID="FtbCampo2" runat="server"
                                        TargetControlID="TxtCampo2" FilterType="Custom, Numbers" ValidChars=".,"/>
                                    <asp:HiddenField ID="HdfIdProducto2" runat="server" />
                                    <asp:HiddenField ID="HdfIdProductoXPresentacion2" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderStyle-BackColor=#6D6C6E HeaderStyle-ForeColor="White" >
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtCampo3" runat="server"  Width="100px" CssClass="TxtEstandar TxtNumero" ReadOnly="true"
                                        style="margin-left: 0px; text-align:right;" ></asp:TextBox>                        
                                    <asp:FilteredTextBoxExtender ID="FtbCampo3" runat="server"
                                        TargetControlID="TxtCampo3" FilterType="Custom, Numbers" ValidChars=".," />
                                    <asp:HiddenField ID="HdfIdProducto3" runat="server" />
                                    <asp:HiddenField ID="HdfIdProductoXPresentacion3" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderStyle-BackColor=#6D6C6E HeaderStyle-ForeColor="White" >
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtCampo4" runat="server"  Width="100px" CssClass="TxtEstandar TxtNumero" ReadOnly="true"
                                        style="margin-left: 0px; text-align:right;" ></asp:TextBox>                        
                                    <asp:FilteredTextBoxExtender ID="FtbCampo4" runat="server"
                                        TargetControlID="TxtCampo4" FilterType="Custom, Numbers" ValidChars=".," />
                                    <asp:HiddenField ID="HdfIdProducto4" runat="server" />
                                    <asp:HiddenField ID="HdfIdProductoXPresentacion4" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>


                           <asp:TemplateField HeaderStyle-BackColor=#6D6C6E HeaderStyle-ForeColor="White" >
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtCampo5" runat="server"  Width="100px" CssClass="TxtEstandar TxtNumero" ReadOnly="true"
                                        style="margin-left: 0px; text-align:right;" ></asp:TextBox>                        
                                    <asp:FilteredTextBoxExtender ID="FtbCampo5" runat="server"
                                        TargetControlID="TxtCampo5" FilterType="Custom, Numbers" ValidChars=".," />
                                    <asp:HiddenField ID="HdfIdProducto5" runat="server" />
                                    <asp:HiddenField ID="HdfIdProductoXPresentacion5" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderStyle-BackColor=#6D6C6E HeaderStyle-ForeColor="White" >
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtCampo6" runat="server"  Width="100px" CssClass="TxtEstandar TxtNumero" ReadOnly="true"
                                        style="margin-left: 0px; text-align:right;" ></asp:TextBox>                        
                                    <asp:FilteredTextBoxExtender ID="FtbCampo6" runat="server"
                                        TargetControlID="TxtCampo6" FilterType="Custom, Numbers" ValidChars=".," />
                                    <asp:HiddenField ID="HdfIdProducto6" runat="server" />
                                    <asp:HiddenField ID="HdfIdProductoXPresentacion6" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderStyle-BackColor=#6D6C6E HeaderStyle-ForeColor="White" >
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtCampo7" runat="server"  Width="100px" CssClass="TxtEstandar TxtNumero" ReadOnly="true"
                                        style="margin-left: 0px; text-align:right;" ></asp:TextBox>                        
                                    <asp:FilteredTextBoxExtender ID="FtbCampo7" runat="server"
                                        TargetControlID="TxtCampo7" FilterType="Custom, Numbers" ValidChars=".," />
                                    <asp:HiddenField ID="HdfIdProducto7" runat="server" />
                                    <asp:HiddenField ID="HdfIdProductoXPresentacion7" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>


                             <asp:TemplateField HeaderStyle-BackColor=#6D6C6E HeaderStyle-ForeColor="White" >
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtCampo8" runat="server"  Width="100px" CssClass="TxtEstandar TxtNumero" ReadOnly="true"
                                        style="margin-left: 0px; text-align:right;" ></asp:TextBox>                        
                                    <asp:FilteredTextBoxExtender ID="FtbCampo8" runat="server"
                                        TargetControlID="TxtCampo8" FilterType="Custom, Numbers" ValidChars=".," />
                                    <asp:HiddenField ID="HdfIdProducto8" runat="server" />
                                    <asp:HiddenField ID="HdfIdProductoXPresentacion8" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>


                             <asp:TemplateField HeaderStyle-BackColor=#6D6C6E HeaderStyle-ForeColor="White" >
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtCampo9" runat="server"  Width="100px" CssClass="TxtEstandar TxtNumero" ReadOnly="true"
                                        style="margin-left: 0px; text-align:right;" ></asp:TextBox>                        
                                    <asp:FilteredTextBoxExtender ID="FtbCampo9" runat="server"
                                        TargetControlID="TxtCampo9" FilterType="Custom, Numbers" ValidChars=".," />
                                    <asp:HiddenField ID="HdfIdProducto9" runat="server" />
                                    <asp:HiddenField ID="HdfIdProductoXPresentacion9" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>


                             <asp:TemplateField HeaderStyle-BackColor=#6D6C6E HeaderStyle-ForeColor="White" >
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtCampo10" runat="server"  Width="100px" CssClass="TxtEstandar TxtNumero" ReadOnly="true"
                                        style="margin-left: 0px; text-align:right;" ></asp:TextBox>                        
                                    <asp:FilteredTextBoxExtender ID="FtbCampo10" runat="server"
                                        TargetControlID="TxtCampo10" FilterType="Custom, Numbers" ValidChars=".," />
                                    <asp:HiddenField ID="HdfIdProducto10" runat="server" />
                                    <asp:HiddenField ID="HdfIdProductoXPresentacion10" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>


                             <asp:TemplateField HeaderStyle-BackColor=#6D6C6E HeaderStyle-ForeColor="White" >
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtCampo11" runat="server"  Width="100px" CssClass="TxtEstandar TxtNumero" ReadOnly="true"
                                        style="margin-left: 0px; text-align:right;" ></asp:TextBox>                        
                                    <asp:FilteredTextBoxExtender ID="FtbCampo11" runat="server"
                                        TargetControlID="TxtCampo11" FilterType="Custom, Numbers" ValidChars=".," />
                                    <asp:HiddenField ID="HdfIdProducto11" runat="server" />
                                    <asp:HiddenField ID="HdfIdProductoXPresentacion11" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>


                             <asp:TemplateField HeaderStyle-BackColor=#6D6C6E HeaderStyle-ForeColor="White" >
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtCampo12" runat="server"  Width="100px" CssClass="TxtEstandar TxtNumero" ReadOnly="true"
                                        style="margin-left: 0px; text-align:right;" ></asp:TextBox>                        
                                    <asp:FilteredTextBoxExtender ID="FtbCampo12" runat="server"
                                        TargetControlID="TxtCampo12" FilterType="Custom, Numbers" ValidChars=".," />
                                    <asp:HiddenField ID="HdfIdProducto12" runat="server" />
                                    <asp:HiddenField ID="HdfIdProductoXPresentacion12" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>


                        </Columns>                        
                        
                    </asp:GridView>                   
          
       
                    <asp:Label ID="Label3" runat="server" CssClass="LblAlerta" 
                        style="width:650px; z-index: 1; left: 2px; top: 192px; position: absolute;">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </asp:Label>
                    <br />
                    <table ID="Table2" runat= "server" style="margin-left:auto; margin-right:auto" visible="true" >
                        <tr>
                            <td class="style3" style="text-align: left">

                               

                                <dx:ASPxButton ID="btnOk0" runat="server" Font-Bold="True" Font-Names="Tahoma" ClientInstanceName="btnOk0"  
                                    Font-Size="9pt" Height="35px" onclick="btnOk_Click" Text="Aceptar" BackgroundImage-HorizontalPosition="left"
                                    Theme="Default" Width="121px">
                                    <ClientSideEvents Click="function(s, e) {ConfirmaGuardar(s,e);}" />
                                    <BackgroundImage ImageUrl="~/Imagenes/Accept.png" Repeat="NoRepeat"
                                        VerticalPosition="center" />                                  
                                </dx:ASPxButton>
          

                            </td>
                            <td class="style4" style="text-align: center">
                                <dx:ASPxButton ID="ASPxButton1" runat="server" Font-Bold="True" Font-Names="Tahoma"
                                     Font-Size="9pt" Height="35px" Text="Cancelar" BackgroundImage-HorizontalPosition="left"
                                    Theme="Default" Width="121px">
                                    <BackgroundImage ImageUrl="~/Imagenes/Cancelar.png" Repeat="NoRepeat" 
                                        VerticalPosition="center" />
                                </dx:ASPxButton>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <br />



<%--             <asp:Button ID="btnOk" runat="server" Text="Aceptar" onclick="btnOk_Click" 
                        OnClientClick="return BtnOK_OnClientClick();" BackColor="#D6D4D1" 
                        style="font-weight: 700" Font-Names="Tahoma" /> --%>

            <asp:Button ID="btnClose" runat="server" Text="Cancelar" BackColor="#D6D4D1" 
                        style="  font-weight: 700; position: absolute; top: 882px; left: 621px; z-index: 1;" 
                        Font-Names="Tahoma" Height="0px" 
                        Width="16px" /> 
     

                </asp:Panel>
                
                <asp:HiddenField ID="HfFechaInventario" runat="server" />
                
                <asp:HiddenField ID="HfPopup" runat="server" />                
           </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
