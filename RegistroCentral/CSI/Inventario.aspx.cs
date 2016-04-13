using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web.Security;
using System.Web.UI.WebControls;
using DevExpress.Web;

using Ine.SihPublico.UI.Web.AgenteEconomicoServicio_T;
using Ine.SihPublico.UI.Web.CapacidadAlmacenamientoServicio_T;
using Ine.SihPublico.UI.Web.InventarioServicio_T;
using Ine.SihPublico.UI.Web.ProductoServicio_T;
using Ine.SihPublico.UI.Web.SeguridadServicio_T;
using Ine.SihPublico.UI.Web.UbicacionGeograficaServicio_T;
using Ine.SihPublico.UI.Web.Utils;
using Ine.SihPublico.UI.Web.VentaServicio_T;

namespace Ine.SihPublico.UI.Web.RegistroCentral.CSI
{
    public partial class Inventario : System.Web.UI.Page
    {
        #region "Eventos"

        private int mesActual;
        private int mesAnterior;
        private int ano;  //= DateTime.Now.Year;
        private int IdAgenteEconomico;
         
        

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarPagina();            
        }

        protected void GrdInventario_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
        {
           DarFormatoFila(e);
        }

        protected void GrdInventario_FocusedRowChanged(object sender, EventArgs e)
        {
            CambioFilaInventario();
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            ConfirmacionGuardado();
        }

   

        #endregion

        #region "Procedimientos"

        protected void DarFormatoFila(ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != GridViewRowType.Data) return;
            int value = (int)e.GetValue("IdInventario");
            if (value == 0)
            {                
                e.Row.Cells[0].Style.Add("background-color", "LightCoral");
                e.Row.Cells[1].Style.Add("background-color", "LightCoral");                  
            }
        }

        protected void CambioFilaInventario()
        {
            Int32 idInventario;
            Int32 idVenta;
            idInventario = Convert.ToInt32(GrdInventario.GetRowValues(GrdInventario.FocusedRowIndex, "IdInventario"));
            idVenta = Convert.ToInt32(GrdInventario.GetRowValues(GrdInventario.FocusedRowIndex, "IdVenta"));


            DateTime dt = Convert.ToDateTime((GrdInventario.GetRowValues(GrdInventario.FocusedRowIndex, "HoraCorte")).ToString());
            ASPxTimeEdit.Value = dt;

            HfFechaInventario.Value = (GrdInventario.GetRowValues(GrdInventario.FocusedRowIndex, "Fecha")).ToString();            
         
            LimpiarDetalle();            
            CargarDetalle(idInventario,idVenta);

            if (idInventario == 0)
                EnllavarDetalle(false);
            else
                EnllavarDetalle(true);
        }

        protected void CargarPagina()
        {
            if (!Page.IsPostBack)
            {
                ValidarSeguridad();
                CargarAgenteEconomico();

                
              
                mesActual = DateTime.Now.Month;
                if (mesActual == 1)
                {
                    mesAnterior = 12;                   
                }
                else
                {
                    mesAnterior = mesActual - 1;
                }
       
                DropDownListMes.Items.Add((ObtenerNombreMes(mesAnterior)));
                DropDownListMes.Items.Add((ObtenerNombreMes(mesActual)));
                DropDownListMes.Text = ObtenerNombreMes(DateTime.Now.Month);


                DropDownListAno.Items.Add(DateTime.Now.Year.ToString());
                DropDownListAno.Text = DateTime.Now.Year.ToString();

            }

            FormsIdentity id = (FormsIdentity)Context.User.Identity;
            FormsAuthenticationTicket ticket = id.Ticket;
            string data = ticket.UserData;
            Utils.Usuario user = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Utils.Usuario>(data);
            IdAgenteEconomico = user.IdAgenteEconomico;

            CargarGrid(IdAgenteEconomico, ObtenerNumeroMes(DropDownListMes.Text));

            GrdInventario.SettingsBehavior.AllowDragDrop = false;

        }

        protected string ObtenerNombreMes(int mes)
        {
            switch (mes)
            {
                case 1:
                    return "Enero";break;
                case 2:
                    return "Febrero"; break;
                case 3:
                    return "Marzo"; break;
                case 4:
                    return "Abril"; break;
                case 5:
                    return "Mayo"; break;
                case 6:
                    return "Junio"; break;
                case 7:
                    return "Julio"; break;
                case 8:
                    return "Agosto"; break;
                case 9:
                    return "Septiembre"; break;
                case 10:
                    return "Octubre"; break;
                case 11:
                    return "Noviembre"; break;
                case 12:
                    return "Diciembre"; break;
                default:
                    return "";break;

            }

        }


        protected int ObtenerNumeroMes(string nombreMes)
        {
            switch (nombreMes)
            {
                case "Enero":
                    return 1; break;
                case "Febrero":
                    return 2 ; break;
                case "Marzo":
                    return 3 ; break;
                case "Abril":
                    return 4; break;
                case "Mayo":
                    return 5; break;
                case "Junio":
                    return 6; break;
                case "Julio":
                    return 7; break;
                case "Agosto":
                    return 8; break;
                case "Septiembre":
                    return 9; break;
                case "Octubre":
                    return 10; break;
                case "Noviembre":
                    return 11; break;
                case "Diciembre":
                    return 12; break;
                default:
                    return 0; break;

            }

        }





        protected void CargarAgenteEconomico()
        {
           UbicacionGeograficaServicio_T.UbicacionGeograficaContratoClient ug = new UbicacionGeograficaContratoClient();
           AgenteEconomicoServicio_T.AgenteEconomicoContratoClient ae = new AgenteEconomicoContratoClient();

            

            FormsIdentity id = (FormsIdentity)Context.User.Identity;
            FormsAuthenticationTicket ticket = id.Ticket;
            string data = ticket.UserData;
            Utils.Usuario user = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Utils.Usuario>(data);


     
            Int32 idAgenteEconomico = user.IdAgenteEconomico;

           
            var agente = ae.Obtener(idAgenteEconomico);

         //   var xx = agente.IdUbicacion;

            var municipio = ug.DameUbicacionGeograficaPadrePorTipo(Convert.ToInt32(agente.IdUbicacion), 3);
            var departamento = ug.DameUbicacionGeograficaPadrePorTipo(agente.IdUbicacion.Value, 2);
            LblNombreEstacionValor.Text = agente.NombreAgente;
            LblDepartamentoValor.Text = departamento.Nombre;
            LblMunicipioValor.Text = municipio.Nombre;
            LblNombreResponsableValor.Text = agente.Administrador;
            LblCorreoElectronicoValor.Text = agente.Email;


        }

        protected void CargarGrid(Int32 idAgenteEconomico, int mes)
        {
            DateTime fechaInicio;
            DateTime fechaFin;


            List<InventarioServicio_T.Inventario> inventarios;
            List<Venta> ventas;

           
            DataTable datos;
            DataRow fila;


            FormsIdentity id = (FormsIdentity)Context.User.Identity;
            FormsAuthenticationTicket ticket = id.Ticket;
            string data = ticket.UserData;
            Utils.Usuario user = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Utils.Usuario>(data);


           // fechaFin = new DateTime(2012, 06, 30);// DateTime.Now;

         //   fechaFin = new DateTime(ano, mes, DateTime.DaysInMonth(ano,mes));

            ano = Convert.ToInt32(DropDownListAno.Text);


            if (mes != DateTime.Now.Month)
            {
                fechaFin = new DateTime(ano, mes, DateTime.DaysInMonth(ano, mes));
            }
            else
            {
                fechaFin = new DateTime(ano, mes, DateTime.Now.Day);
            }


            
            fechaInicio = new DateTime(fechaFin.Year, fechaFin.Month, 1);

            VentaServicio_T.VentaContratoClient vent = new VentaContratoClient();
            InventarioServicio_T.InventarioContratoClient invent = new InventarioContratoClient();

            inventarios = invent.ObtenerListadoPorFechaActivo(user.IdAgenteEconomicoAgenteTipo, fechaInicio, fechaFin, true);
            ventas = vent.ObtenerListadoPorFechaActivo(user.IdAgenteEconomicoAgenteTipo, fechaInicio.AddDays(-1), fechaFin.AddDays(-1));  //Le restamos uno a cada fecha de inventario porque asi la guardamos en ventas
           //test

            CapacidadAlmacenamientoServicio_T.CapacidadAlmacenamientoContratoClient capa = new CapacidadAlmacenamientoContratoClient();
            ProductoServicio_T.ProductoContratoClient pro = new ProductoContratoClient();

           var capacidades = capa.ObtenerListadoPorAgenteEconomico(idAgenteEconomico);
           var productos = pro.ObtenerListadoPorAgenteEconomicoActivo(idAgenteEconomico);
                   

            datos = new DataTable();
            datos.Columns.Add("IdInventario", typeof(Int32));
            datos.Columns.Add("IdVenta", typeof(Int32));
            datos.Columns.Add("Fecha", typeof(DateTime));
            datos.Columns.Add("HoraCorte");

            foreach (var p in productos)
            {
                
               var productoPresentacionTipo = p.ProductoPresentacionTipos.Where(pp => pp.IdPresentacionTipo == 4).FirstOrDefault();
                if (productoPresentacionTipo != null)
                {
                    datos.Columns.Add("Inv_" + productoPresentacionTipo.IdProductoxPresentacion.ToString());//Galón Chekar como guarda el id de productopresentacion (si es galon o litro)
                    datos.Columns.Add("Ven_" + productoPresentacionTipo.IdProductoxPresentacion.ToString());//Galón Chekar como guarda el id de productopresentacion (si es galon o litro)
                    datos.Columns.Add("Cap_" + productoPresentacionTipo.IdProducto.ToString()); //Galón
                }


            }

            foreach (var inv in inventarios)
            {
                fila = datos.NewRow();
                fila["IdInventario"] = inv.IdInventario;
                fila["IdVenta"] = 0;
                fila["Fecha"] = inv.Fecha;
              //  fila["HoraCorte"] = inv.HoraCorte;

                TimeSpan span = TimeSpan.Parse(inv.HoraCorte.ToString());


                fila["HoraCorte"] = DateTime.Today.Add(span).ToString("hh:mm:ss tt");
   

                foreach (var det in inv.InventarioDetalle)
                {
                    if(datos.Columns.Contains("Inv_" + det.IdProductoxPresentacion.ToString()))//GB
                        fila["Inv_" + det.IdProductoxPresentacion.ToString()] = det.InventarioTotal.ToString("#,##0.00");                    
                }
                //Buscando en tabla ventas
                var agenteVenta = (from t in ventas
                                 where t.IdAgenteEconomicoAgenteTipo == inv.IdAgenteEconomicoAgenteTipo && t.Fecha == inv.Fecha.AddDays(-1)
                                 select t).FirstOrDefault();
                if (agenteVenta != null)
                {
                    fila["IdVenta"] = agenteVenta.IdVenta;
                    foreach (var det in agenteVenta.VentaDetalles)
                    {
                        if (datos.Columns.Contains("Ven_" + det.IdProductoxPresentacion.ToString()))//GB
                            fila["Ven_" + det.IdProductoxPresentacion.ToString()] = det.Volumen.ToString("#,##0.00");
                    }                   
                }
                else
                    fila["IdVenta"] = 0;


                //Capacidades Almacenamiento


                foreach (var p in productos)
                {
                    var productoPresentacionTipo = p.ProductoPresentacionTipos.Where(pp => pp.IdPresentacionTipo == 4).FirstOrDefault();
                    if (productoPresentacionTipo != null)
                    {
                        if (inv.IdInventario != 0 || inv.IdInventario == 0)
                        {
                            var agenteCapacidades = (from t in capacidades
                                                     where t.IdProducto == productoPresentacionTipo.IdProducto
                                                      && t.Activo == true
                                                     select t).ToList();
                            if (agenteCapacidades != null)
                            {
                                var total = 0;
                                foreach (var cap in agenteCapacidades)
                                    total = total + cap.CapacidadAlmacenamientoTanque;
                                if (datos.Columns.Contains("Cap_" + productoPresentacionTipo.IdProducto.ToString()))//GB
                                    fila["Cap_" + productoPresentacionTipo.IdProducto.ToString()] = total.ToString("#,##0");
                            }
                        }
                        else
                        {
                            
                            foreach (var det in inv.InventarioDetalle)
                            {
                                if(det.IdProductoxPresentacion == productoPresentacionTipo.IdProductoxPresentacion)
                                    if (datos.Columns.Contains("Cap_" + productoPresentacionTipo.IdProducto.ToString()))//GB
                                        fila["Cap_" + productoPresentacionTipo.IdProducto.ToString()] = det.CapacidadInstalada.ToString("#,##0");                                                                 
                            }
  
                        }
                    }

                }
   
                datos.Rows.Add(fila);
            }

            
            while (GrdInventario.Columns.Count >= 5)
                GrdInventario.Columns.Remove(GrdInventario.Columns[GrdInventario.Columns.Count - 1]);

            GridViewColumn column;
            foreach (var p in productos)
            {
                 var productoPresentacionTipo = p.ProductoPresentacionTipos.Where(pp => pp.IdPresentacionTipo == 4).FirstOrDefault();
                 if (productoPresentacionTipo != null)
                 {
                     column = new GridViewBandColumn();
                     (column as GridViewBandColumn).Columns.Add(new GridViewDataTextColumn { FieldName = "Cap_" + productoPresentacionTipo.IdProducto.ToString(), Caption = "Capacidad (Gls)"});
                     (column as GridViewBandColumn).Columns[(column as GridViewBandColumn).Columns.Count - 1].HeaderStyle.Wrap = DevExpress.Utils.DefaultBoolean.True;
                     (column as GridViewBandColumn).Columns[(column as GridViewBandColumn).Columns.Count - 1].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                     

                     (column as GridViewBandColumn).Columns.Add(new GridViewDataTextColumn { FieldName = "Inv_" + productoPresentacionTipo.IdProductoxPresentacion.ToString(), Caption = "Inventario Actual (Gls)"});
                     (column as GridViewBandColumn).Columns[(column as GridViewBandColumn).Columns.Count - 1].HeaderStyle.Wrap = DevExpress.Utils.DefaultBoolean.True;
                     (column as GridViewBandColumn).Columns[(column as GridViewBandColumn).Columns.Count - 1].CellStyle.HorizontalAlign = HorizontalAlign.Right;

                     (column as GridViewBandColumn).Columns.Add(new GridViewDataTextColumn { FieldName = "Ven_" + productoPresentacionTipo.IdProductoxPresentacion.ToString(), Caption = "Ventas del Días Anterior (Lts)" });
                     (column as GridViewBandColumn).Columns[(column as GridViewBandColumn).Columns.Count - 1].HeaderStyle.Wrap = DevExpress.Utils.DefaultBoolean.True;
                     (column as GridViewBandColumn).Columns[(column as GridViewBandColumn).Columns.Count - 1].CellStyle.HorizontalAlign = HorizontalAlign.Right;
                     
                     column.Caption = p.NombreComercial;
                    
               
                     column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                     GrdInventario.Columns.Add(column);

                 }

            }


            GrdInventario.DataSource = datos;
            GrdInventario.DataBind();

            GrdInventario.Columns["Fecha"].Width = 80;
            GrdInventario.Columns["HoraCorte"].Width = 90;

            if (inventarios.Where(inv => inv.IdInventario == 0).Count() != 0)
            {
                LblAlerta.Text = String.Format("Tiene {0} día(s) de inventario sin reportar. Por favor, actualice su información.", inventarios.Where(inv => inv.IdInventario == 0).Count());
                Image1.Visible = true;
            }
            else
            {
                LblAlerta.Text = "";
                Image1.Visible = false;
            }

            LblAlerta.Visible = true;
       //     Image1.Visible = true;
            
        }
              
        protected void CargarDetalle(Int32 idInventario, Int32 idVenta)
        {

          //  List<INE.ServiciosWeb.Producto.Contrato.Producto> productos;
            DataTable detalle;
            Int32 i;

            FormsIdentity id = (FormsIdentity)Context.User.Identity;
            FormsAuthenticationTicket ticket = id.Ticket;
            string data = ticket.UserData;
            Utils.Usuario user = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Utils.Usuario>(data);

            ProductoServicio_T.ProductoContratoClient pro = new ProductoContratoClient();
            var productos = pro.ObtenerListadoPorAgenteEconomicoActivo(user.IdAgenteEconomico);
            
               
            detalle = new DataTable();
            detalle.Columns.Add("Id");
            detalle.Columns.Add("Concepto");
            

            i = 2;
            foreach (var p in productos)
            {
                var productoPresentacionTipo = p.ProductoPresentacionTipos.Where(pp => pp.IdPresentacionTipo == 4 && pp.Activo == true).FirstOrDefault();                
                detalle.Columns.Add(productoPresentacionTipo.IdProductoxPresentacion.ToString());                
                GrdDetalle.Columns[i].HeaderText = p.NombreComercial;
                GrdComprobante.Columns[i].HeaderText = p.NombreComercial; //ESTO LO PUSE VEAMOS
                i++;
            }
            

            detalle.Rows.Add(detalle.NewRow());
            detalle.Rows[detalle.Rows.Count - 1]["Concepto"] = "Inventario Actual(Gls): " ;         
            detalle.Rows[detalle.Rows.Count - 1]["Id"] = idInventario;
            detalle.Rows.Add(detalle.NewRow());
            detalle.Rows[detalle.Rows.Count - 1]["Id"] = 2;
            detalle.Rows[detalle.Rows.Count - 1]["Concepto"] = "Ventas del día anterior(Lts):";
            detalle.Rows.Add(detalle.NewRow());
            detalle.Rows[detalle.Rows.Count - 1]["Id"] = 3;
            detalle.Rows[detalle.Rows.Count - 1]["Concepto"] = "Precio x Lts(C$):";


            GrdDetalle.DataSource = detalle;
            GrdDetalle.DataBind();

            GrdComprobante.DataSource = detalle;
            GrdComprobante.DataBind();

           // GrdComprobante.Rows[0].Cells[1].BackColor = Color.FromArgb(109,108,110); //Con esto coloreamos la celdas de la parte izquierda del comprobante
        
                
            
           // ((TextBox)GrdDetalle.Rows[1].FindControl("Txt8") ).Text = "15" ;
          
                
               
            for(i = 0; i < productos.Count(); i++)
            {
                var productoPresentacion = productos[i].ProductoPresentacionTipos.Where(pp => pp.IdPresentacionTipo == 4 && pp.Activo == true).SingleOrDefault();

                if (productoPresentacion != null)
                {
                    if (idInventario != 0)
                    {
                        InventarioServicio_T.InventarioContratoClient invent = new InventarioContratoClient();

                        var inventario = invent.Obtener(idInventario);
                        (GrdDetalle.Rows[0].Cells[i + 2].FindControl("TxtCampo" + (i + 2).ToString()) as TextBox).Text = inventario.InventarioDetalle.Where(det => det.IdProductoxPresentacion == productoPresentacion.IdProductoxPresentacion).SingleOrDefault().InventarioTotal.ToString("#,##0.00");
                       
                        TxtObservacion.Text = inventario.Observaciones;

                        //ASPxTimeEdit.Value = inventario.HoraCorte;
                    
                    }

                    if (idVenta != 0)
                    {
                        VentaServicio_T.VentaContratoClient vent = new VentaContratoClient();


                        var venta = vent.Obtener(idVenta);
                        (GrdDetalle.Rows[1].Cells[i + 2].FindControl("TxtCampo" + (i + 2).ToString()) as TextBox).Text = venta.VentaDetalles.Where(det => det.IdProductoxPresentacion == productoPresentacion.IdProductoxPresentacion).SingleOrDefault().Volumen.ToString("#,##0.00");
                        (GrdDetalle.Rows[2].Cells[i + 2].FindControl("TxtCampo" + (i + 2).ToString()) as TextBox).Text = venta.VentaDetalles.Where(det => det.IdProductoxPresentacion == productoPresentacion.IdProductoxPresentacion).SingleOrDefault().Precio.ToString("#,##0.00");
                    }

                    (GrdDetalle.Rows[0].Cells[i + 2].FindControl("HdfIdProductoXPresentacion" + (i + 2).ToString()) as HiddenField).Value = productoPresentacion.IdProductoxPresentacion.ToString();
                    (GrdDetalle.Rows[1].Cells[i + 2].FindControl("HdfIdProductoXPresentacion" + (i + 2).ToString()) as HiddenField).Value = productoPresentacion.IdProductoxPresentacion.ToString();
                    (GrdDetalle.Rows[2].Cells[i + 2].FindControl("HdfIdProductoXPresentacion" + (i + 2).ToString()) as HiddenField).Value = productoPresentacion.IdProductoxPresentacion.ToString();
                }
                else
                {
                    (GrdDetalle.Rows[0].Cells[i + 2].FindControl("TxtCampo" + (i + 2).ToString()) as TextBox).Text = "0.00";
                   
                    (GrdDetalle.Rows[1].Cells[i + 2].FindControl("TxtCampo" + (i + 2).ToString()) as TextBox).Text = "0.00";
                    (GrdDetalle.Rows[2].Cells[i + 2].FindControl("TxtCampo" + (i + 2).ToString()) as TextBox).Text = "0.00";
                }

                (GrdDetalle.Rows[0].Cells[i + 2].FindControl("HdfIdProducto" + (i + 2).ToString()) as HiddenField).Value = productos[i].IdProducto.ToString();
                (GrdDetalle.Rows[1].Cells[i + 2].FindControl("HdfIdProducto" + (i + 2).ToString()) as HiddenField).Value = productos[i].IdProducto.ToString();
                (GrdDetalle.Rows[2].Cells[i + 2].FindControl("HdfIdProducto" + (i + 2).ToString()) as HiddenField).Value = productos[i].IdProducto.ToString();
                  
            }

            for (i = productos.Count() + 2; i < GrdDetalle.Columns.Count; i++)
            {
                GrdDetalle.Columns[i].Visible = false;
                GrdComprobante.Columns[i].Visible = false;
            }

            if (idVenta > 0)
            {
                VentaServicio_T.VentaContratoClient vent = new VentaContratoClient();
                var venta = vent.Obtener(idVenta);
            }
                    
        }

        protected void EnllavarDetalle(Boolean enllavado)
        {
            String cssClass;
            Int32 r;
            Int32 c;
            
            if (enllavado == false)            
                cssClass = "TxtEstandar TxtEdit";
            else
                cssClass = "TxtEstandar";

            for (r = 0; r < GrdDetalle.Rows.Count; r++)
            {
                for (c = 2; c < GrdDetalle.Columns.Count; c++)
                {
                    if (GrdDetalle.Rows[r].Cells[c].Controls.Count > 0)
                    {
                        (GrdDetalle.Rows[r].Cells[c].Controls[1] as TextBox).ReadOnly = enllavado;
                        (GrdDetalle.Rows[r].Cells[c].Controls[1] as TextBox).CssClass = cssClass;
                    }
                }
            }

            TxtObservacion.ReadOnly = enllavado;
            ASPxTimeEdit.ReadOnly = enllavado;
            
            ASPxGuardar.Enabled = !enllavado;
                    
 
        }

        protected void LimpiarDetalle()
        {
            Int32 c;
            Int32 r;
            for (r = 0; r < GrdDetalle.Rows.Count; r++)
            {
                for (c = 2; c < GrdDetalle.Columns.Count; c++)
                {
                    if (GrdDetalle.Rows[r].Cells[c].Controls.Count > 0)
                    {
                        (GrdDetalle.Rows[r].Cells[c].Controls[1] as TextBox).Text = "0.0000";
                     
                    }
                }
            }

            LblMensaje.Visible = false;
            Image2.Visible = false;
            TxtObservacion.Text = "";
 //           ASPxTimeEdit.Text = "";
        }

        protected void ValidarSeguridad()
        {
            SeguridadServicio_T.SeguridadContratoClient seg = new SeguridadContratoClient();

            var acciones = seg.ObtenerListadoAccionesPorCuenta(Page.User.Identity.Name, Configuracion.ObtenerCodigoSistema(), Configuracion.ObtenerNombreInterfaz(), "Inventario").ToList();


            if (SeguridadLocal.PoseePermiso(acciones, "AgregarInventario"))
            {
            //    BtnGuardar.Enabled = true;
                ASPxGuardar.Enabled = true;
            }
            else
            {

           //     BtnGuardar.Enabled = false;
                ASPxGuardar.Enabled = false;
            }

        }

        protected Int32 ObtenerConteoColVisible(GridView control)
        {
            Int32 cv;
            Int32 c;
            cv = 1;//Se inicializa en 1 dado que no va a contar la primera columna de ID oculta
            for (c = 0; c < control.Columns.Count; c++)
            {
                if (control.Columns[c].Visible == true)
                    cv++;
            }
            return cv;
        }

        private Boolean EsDetalleValido()
        {
            Boolean esValido = true;
            TextBox control;
            Int32 c;
            Int32 r;
            Int32 columnasVisibles;
            Double temp;
            columnasVisibles = ObtenerConteoColVisible(GrdDetalle);

            for (r = 0; r < GrdDetalle.Rows.Count; r++)
            {
                for (c = 2; c < columnasVisibles; c++)
                {
                    if (GrdDetalle.Rows[r].Cells[c].Controls.Count > 0)
                    {
                        control = (GrdDetalle.Rows[r].Cells[c].Controls[1] as TextBox);
                        if (control.Text.Trim() == "")
                        {
                            control.CssClass = "TxtEstandar CampoMinimo";
                            esValido = false;
                        }
                        else if (!Double.TryParse(control.Text.Trim(),out temp))
                        {
                            control.CssClass = "TxtEstandar CampoMinimo";
                            esValido = false;
                        }
                        //else if (Convert.ToDouble(control.Text) == 0) //Aqui no permitimos valores en 0
                        //{
                        //    control.CssClass = "TxtEstandar CampoMinimo";
                        //    esValido = false;
                        //}
                        else
                            control.CssClass = "TxtEstandar";

                    }
                }
            }

            Int32 capacidadAlmacenada = 0;
            double inventarioActual = 0;
            Int32 idProducto = 0;
            double ventaActual = 0;

            string capacidad;

            for (c = 2; c < columnasVisibles; c++)
            {

           


                idProducto = Convert.ToInt32((GrdDetalle.Rows[0].Cells[c].FindControl("HdfIdProducto" + c.ToString()) as HiddenField).Value);
           
                capacidadAlmacenada = Convert.ToInt32((GrdInventario.GetRowValues(GrdInventario.FocusedRowIndex, "Cap_" + idProducto)).ToString().Replace(",",""));

                string inventarioActualTemporal = (GrdDetalle.Rows[0].Cells[c].FindControl("TxtCampo" + c.ToString()) as TextBox).Text;

                if (inventarioActualTemporal == "")
                {
                    inventarioActualTemporal = "0";
                }

                string ventaActualTemporal = (GrdDetalle.Rows[1].Cells[c].FindControl("TxtCampo" + c.ToString()) as TextBox).Text;

                if (ventaActualTemporal == "")
                {
                    ventaActualTemporal = "0";
                }

                inventarioActual = Convert.ToDouble(inventarioActualTemporal.Replace(",", ""));

                ventaActual = Convert.ToDouble(ventaActualTemporal.Replace(",",""));
  
                
                if (inventarioActual > capacidadAlmacenada)
                {
                    LblMensaje.Text = "El Inventario digitado no puede ser mayor que la capacidad de almacenamiento del tanque.";
                    LblMensaje.Visible = true;
                    Image2.Visible = true;
                    return false;

                }

                if ((ventaActual * 0.26417205) > capacidadAlmacenada) //Aqui hay que invocar al servicio de medida
                {
                    LblMensaje.Text = "La Venta en litros no puede superar la capacidad de almacenamiento del tanque.";
                    LblMensaje.Visible = true;
                    Image2.Visible = true;
                    return false;

                }
    
            }
            
            if (esValido == false)
            {
                LblMensaje.Text = "Por favor, verifique la información en los campos señalados.";
                LblMensaje.Visible = true;
                Image2.Visible = true;
                return false;
            }
            else if (ASPxTimeEdit.DateTime.Hour == 0 && ASPxTimeEdit.DateTime.Minute == 0 && ASPxTimeEdit.DateTime.Second == 0)
            {
                LblMensaje.Text = "Por favor, ingrese la hora de corte de la inspección.";
                LblMensaje.Visible = true;
                Image2.Visible = true;
                return false;
            }

  

            else
            {
                LblMensaje.Visible = false;
                Image2.Visible = false;
                return true;
            }
        }


     

        private void GuardarDetalle() //Aqui guardamos el inventario a la base de datos
        {
            GridViewRow fila;


          //  INE.ServiciosWeb.Inventario.Contrato.Inventario inventario = new INE.ServiciosWeb.Inventario.Contrato.Inventario();
          //  INE.ServiciosWeb.Inventario.Contrato.InventarioDetalle inventarioDetalle;

            InventarioServicio_T.Inventario inventario = new InventarioServicio_T.Inventario();
            InventarioServicio_T.InventarioDetalle inventarioDetalle = new InventarioDetalle();

            Venta venta = new Venta();

           // INE.ServiciosWeb.Venta.Contrato.Venta venta = new INE.ServiciosWeb.Venta.Contrato.Venta();
            VentaDetalle ventaDetalle;
          //  INE.ServiciosWeb.Venta.Contrato.VentaDetalle ventaDetalle;
            Int32 c;
            Int32 columnasVisibles;

            FormsIdentity id = (FormsIdentity)Context.User.Identity;
            FormsAuthenticationTicket ticket = id.Ticket;
            string data = ticket.UserData;
            Utils.Usuario user = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Utils.Usuario>(data);


            columnasVisibles = ObtenerConteoColVisible(GrdDetalle);

            #region Inventario

            inventario.IdInventario = 0;
            inventario.IdAgenteEconomicoAgenteTipo = user.IdAgenteEconomicoAgenteTipo;  
           // inventario.Activo = true;
            inventario.Fecha = Convert.ToDateTime(GrdInventario.GetRowValues(GrdInventario.FocusedRowIndex, "Fecha"));
            inventario.Observaciones = TxtObservacion.Text;
            inventario.HoraCorte = Convert.ToDateTime(ASPxTimeEdit.Value).TimeOfDay;


            for (c = 2; c < columnasVisibles; c++)
            {
                fila = GrdDetalle.Rows[0];

                inventarioDetalle = new InventarioDetalle();
                                
                //inventarioDetalle.Activo = true;
                inventarioDetalle.IdProductoxPresentacion = Convert.ToInt32((fila.Cells[c].FindControl("HdfIdProductoXPresentacion" + c.ToString()) as HiddenField).Value);
                inventarioDetalle.CapacidadInstalada = Convert.ToDecimal(GrdInventario.GetRowValues(GrdInventario.FocusedRowIndex, "Cap_" + (fila.Cells[c].FindControl("HdfIdProducto" + c.ToString()) as HiddenField).Value));                
                inventarioDetalle.InventarioTotal = Convert.ToDecimal((fila.Cells[c].FindControl("TxtCampo" + c.ToString()) as TextBox).Text);
                inventario.InventarioDetalle = inventario.InventarioDetalle ?? new List<InventarioDetalle>();
                inventario.InventarioDetalle.Add(inventarioDetalle);
               
            }

            InventarioServicio_T.InventarioContratoClient invent = new InventarioContratoClient();

            if(invent.VerificarInventario(inventario))
            {
             
                LblMensaje.Text = "El día de inventario que está tratando de registrar, ya ha sido guardado en el Sistema";
                Image2.Visible = true;
                LblMensaje.Visible = true;
                ASPxGuardar.Enabled = false;
                
                return;
            }

            invent.Guardar(inventario, user.IdCuenta);

            #region Venta

            venta.IdVenta = 0;
            venta.IdAgenteEconomicoAgenteTipo = user.IdAgenteEconomicoAgenteTipo;
            //venta.IdUsuarioRegistro = (Page.User as Usuario).IdCuenta;
            //venta.FechaRegistro = DateTime.Now;
            //venta.IdUsuarioModificacion = (Page.User as Usuario).IdCuenta;
            //venta.FechaModificacion = DateTime.Now;
            //venta.Activo = true;
            venta.Fecha = Convert.ToDateTime(GrdInventario.GetRowValues(GrdInventario.FocusedRowIndex, "Fecha")).AddDays(-1);
            venta.Observaciones = TxtObservacion.Text;



            for (c = 2; c < columnasVisibles; c++)
            {
                fila = GrdDetalle.Rows[1];
                ventaDetalle = new VentaDetalle();
                //ventaDetalle.Activo = true;
                ventaDetalle.IdProductoxPresentacion = Convert.ToInt32((fila.Cells[c].FindControl("HdfIdProductoXPresentacion" + c.ToString()) as HiddenField).Value);
                //ventaDetalle.FechaModificacion = DateTime.Now;
               // ventaDetalle.IdUsuarioModificacion = (Page.User as Usuario).IdCuenta;
                //ventaDetalle.IdUsuarioRegistro = (Page.User as Usuario).IdCuenta;
                //ventaDetalle.FechaRegistro = DateTime.Now;
                ventaDetalle.Volumen = Convert.ToDecimal((fila.Cells[c].FindControl("TxtCampo" + c.ToString()) as TextBox).Text);
                ventaDetalle.Precio = Convert.ToDecimal((GrdDetalle.Rows[2].Cells[c].FindControl("TxtCampo" + c.ToString()) as TextBox).Text);
                venta.VentaDetalles = venta.VentaDetalles ?? new List<VentaDetalle>();
                venta.VentaDetalles.Add(ventaDetalle);
            }

            VentaServicio_T.VentaContratoClient vent = new VentaContratoClient();
            vent.Guardar(venta, user.IdCuenta);

            #endregion

            CargarGrid(user.IdAgenteEconomico,ObtenerNumeroMes(DropDownListMes.Text));

            ModalPopupExtender1.Hide();

            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "Script2", "$.unblockUI()", true);

            EnllavarDetalle(true);

            #endregion
        }

        private void ConfirmacionGuardado()
        {

            LblTitulo1.Text = "CSI - Verificación de Datos a Enviar";
            LblTitulo2.Text = "Si los datos suministrados están correctos, haga clic en \"Aceptar\", sino clic en \"Cancelar\".";
        
            TxtFechaInventario.Text = String.Format("{0:d}", Convert.ToDateTime(HfFechaInventario.Value)); 

            ASPxTimeEdit1.Value = ASPxTimeEdit.Value;
          

            Int32 c;
            Int32 r;

            if (EsDetalleValido() == false) return;
            for (r = 0; r < GrdDetalle.Rows.Count; r++)
            {
                for (c = 2; c < GrdDetalle.Columns.Count; c++)
                {
                    if (GrdDetalle.Rows[r].Cells[c].Controls.Count > 0)
                    {
                        (GrdComprobante.Rows[r].Cells[c].Controls[1] as TextBox).Text = (GrdDetalle.Rows[r].Cells[c].Controls[1] as TextBox).Text;
                    }
                }
            }

            ASPxTimeEdit1.Value = ASPxTimeEdit.Value;
            ASPxTimeEdit1.ReadOnly = true;


            ModalPopupExtender1.Show();

        }
               

     //   #endregion

        protected void ASPxGuardar_Click(object sender, EventArgs e)
        {
            ConfirmacionGuardado();

        }
            #endregion

        protected void btnOk_Click(object sender, EventArgs e)
        {
            GuardarDetalle();
        }

        protected void DropDownListMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            mesActual = DateTime.Now.Month;

            if (ObtenerNumeroMes(DropDownListMes.Text) == 12 && mesActual == 1)
            {
            ano = DateTime.Now.Year - 1;
            DropDownListAno.Items.Add(ano.ToString());
            DropDownListAno.Text = ano.ToString();
            DropDownListAno.Enabled = false;
            }
            else
            {
            DropDownListAno.Items.Clear();
            DropDownListAno.Items.Add(DateTime.Now.Year.ToString());
            DropDownListAno.Text = DateTime.Now.Year.ToString();
            DropDownListAno.Enabled = true;
            }


            CargarGrid(IdAgenteEconomico, ObtenerNumeroMes(DropDownListMes.Text));
            GrdInventario.FocusedRowIndex = 0;
            CambioFilaInventario();
            GrdInventario.SettingsBehavior.AllowDragDrop = false;

         
    

        }

       
    }

    

}