function grdInventario_OnSelectedIndexChanged(pGridID, pRowID, pRowIndex) {
    var iRow = null;
    iRow = document.getElementById(pRowID);
    gFuncionJS.LimpiarSeleccion(pGridID);
    if (iRow != null) {                
/*        document.getElementById("HfIdSesion").value = iRow.cells[1].innerHTML;*/
       // __doPostBack("GrdInventario", "Select$" + pRowIndex);

    }
}


function BtnOK_OnClientClick() {
    return confirm("Está seguro que desea guardar?");
}

function Cancel() {
    //alert('Has apretado Cancel');
}

function ConfirmaGuardar(s, e) {


        if (confirm("Advertencia: El Registro de sus inventarios puede tomar tiempo según su velocidad de su conexión.\n\n ¿Desea enviar el Inventario?")) {

            $.blockUI({
                message: '<div style=" width:200px;height:45px;" ><img src="../../Imagenes/loading_spinner.gif"  style="position:absolute; left:0px; alt="" width="42" height="44" /><div style="position: absolute; top: 15px; left: 49px;" ><strong><label style="color:#C03736">Procesando Solicitud. Por Favor Espere...</label></strong></div></div>',
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


            e.processOnServer = true;

        } else {
            e.processOnServer = false;
        }

}
