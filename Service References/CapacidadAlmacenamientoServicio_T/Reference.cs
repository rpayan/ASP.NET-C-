﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.33440
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ine.SihPublico.UI.Web.CapacidadAlmacenamientoServicio_T {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CapacidadAlmacenamiento", Namespace="http://schemas.datacontract.org/2004/07/INE.ServiciosWeb.CapacidadAlmacenamiento." +
        "Contrato", IsReference=true)]
    [System.SerializableAttribute()]
    public partial class CapacidadAlmacenamiento : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool ActivoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<short> AnosVidaUtilTanqueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CapacidadAlmacenamientoTanqueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> DiametroTuberiaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> FechaCierreTanqueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> FechaInstalacionTanqueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> FechaModificacionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime FechaRegistroField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdAgenteEconomicoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdCapacidadAlmacenamientoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdProductoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<short> IdTanqueInstalacionTipoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<short> IdTanqueTipoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<short> IdTuberiaMarcaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<short> IdTuberiaMaterialField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<short> IdTuberiaTipoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> IdUsuarioModificacionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdUsuarioRegistroField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IdentificacionTanqueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MedidasTanqueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ObservacionesField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Activo {
            get {
                return this.ActivoField;
            }
            set {
                if ((this.ActivoField.Equals(value) != true)) {
                    this.ActivoField = value;
                    this.RaisePropertyChanged("Activo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<short> AnosVidaUtilTanque {
            get {
                return this.AnosVidaUtilTanqueField;
            }
            set {
                if ((this.AnosVidaUtilTanqueField.Equals(value) != true)) {
                    this.AnosVidaUtilTanqueField = value;
                    this.RaisePropertyChanged("AnosVidaUtilTanque");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CapacidadAlmacenamientoTanque {
            get {
                return this.CapacidadAlmacenamientoTanqueField;
            }
            set {
                if ((this.CapacidadAlmacenamientoTanqueField.Equals(value) != true)) {
                    this.CapacidadAlmacenamientoTanqueField = value;
                    this.RaisePropertyChanged("CapacidadAlmacenamientoTanque");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> DiametroTuberia {
            get {
                return this.DiametroTuberiaField;
            }
            set {
                if ((this.DiametroTuberiaField.Equals(value) != true)) {
                    this.DiametroTuberiaField = value;
                    this.RaisePropertyChanged("DiametroTuberia");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> FechaCierreTanque {
            get {
                return this.FechaCierreTanqueField;
            }
            set {
                if ((this.FechaCierreTanqueField.Equals(value) != true)) {
                    this.FechaCierreTanqueField = value;
                    this.RaisePropertyChanged("FechaCierreTanque");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> FechaInstalacionTanque {
            get {
                return this.FechaInstalacionTanqueField;
            }
            set {
                if ((this.FechaInstalacionTanqueField.Equals(value) != true)) {
                    this.FechaInstalacionTanqueField = value;
                    this.RaisePropertyChanged("FechaInstalacionTanque");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> FechaModificacion {
            get {
                return this.FechaModificacionField;
            }
            set {
                if ((this.FechaModificacionField.Equals(value) != true)) {
                    this.FechaModificacionField = value;
                    this.RaisePropertyChanged("FechaModificacion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime FechaRegistro {
            get {
                return this.FechaRegistroField;
            }
            set {
                if ((this.FechaRegistroField.Equals(value) != true)) {
                    this.FechaRegistroField = value;
                    this.RaisePropertyChanged("FechaRegistro");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdAgenteEconomico {
            get {
                return this.IdAgenteEconomicoField;
            }
            set {
                if ((this.IdAgenteEconomicoField.Equals(value) != true)) {
                    this.IdAgenteEconomicoField = value;
                    this.RaisePropertyChanged("IdAgenteEconomico");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdCapacidadAlmacenamiento {
            get {
                return this.IdCapacidadAlmacenamientoField;
            }
            set {
                if ((this.IdCapacidadAlmacenamientoField.Equals(value) != true)) {
                    this.IdCapacidadAlmacenamientoField = value;
                    this.RaisePropertyChanged("IdCapacidadAlmacenamiento");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdProducto {
            get {
                return this.IdProductoField;
            }
            set {
                if ((this.IdProductoField.Equals(value) != true)) {
                    this.IdProductoField = value;
                    this.RaisePropertyChanged("IdProducto");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<short> IdTanqueInstalacionTipo {
            get {
                return this.IdTanqueInstalacionTipoField;
            }
            set {
                if ((this.IdTanqueInstalacionTipoField.Equals(value) != true)) {
                    this.IdTanqueInstalacionTipoField = value;
                    this.RaisePropertyChanged("IdTanqueInstalacionTipo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<short> IdTanqueTipo {
            get {
                return this.IdTanqueTipoField;
            }
            set {
                if ((this.IdTanqueTipoField.Equals(value) != true)) {
                    this.IdTanqueTipoField = value;
                    this.RaisePropertyChanged("IdTanqueTipo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<short> IdTuberiaMarca {
            get {
                return this.IdTuberiaMarcaField;
            }
            set {
                if ((this.IdTuberiaMarcaField.Equals(value) != true)) {
                    this.IdTuberiaMarcaField = value;
                    this.RaisePropertyChanged("IdTuberiaMarca");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<short> IdTuberiaMaterial {
            get {
                return this.IdTuberiaMaterialField;
            }
            set {
                if ((this.IdTuberiaMaterialField.Equals(value) != true)) {
                    this.IdTuberiaMaterialField = value;
                    this.RaisePropertyChanged("IdTuberiaMaterial");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<short> IdTuberiaTipo {
            get {
                return this.IdTuberiaTipoField;
            }
            set {
                if ((this.IdTuberiaTipoField.Equals(value) != true)) {
                    this.IdTuberiaTipoField = value;
                    this.RaisePropertyChanged("IdTuberiaTipo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> IdUsuarioModificacion {
            get {
                return this.IdUsuarioModificacionField;
            }
            set {
                if ((this.IdUsuarioModificacionField.Equals(value) != true)) {
                    this.IdUsuarioModificacionField = value;
                    this.RaisePropertyChanged("IdUsuarioModificacion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdUsuarioRegistro {
            get {
                return this.IdUsuarioRegistroField;
            }
            set {
                if ((this.IdUsuarioRegistroField.Equals(value) != true)) {
                    this.IdUsuarioRegistroField = value;
                    this.RaisePropertyChanged("IdUsuarioRegistro");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IdentificacionTanque {
            get {
                return this.IdentificacionTanqueField;
            }
            set {
                if ((object.ReferenceEquals(this.IdentificacionTanqueField, value) != true)) {
                    this.IdentificacionTanqueField = value;
                    this.RaisePropertyChanged("IdentificacionTanque");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MedidasTanque {
            get {
                return this.MedidasTanqueField;
            }
            set {
                if ((object.ReferenceEquals(this.MedidasTanqueField, value) != true)) {
                    this.MedidasTanqueField = value;
                    this.RaisePropertyChanged("MedidasTanque");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Observaciones {
            get {
                return this.ObservacionesField;
            }
            set {
                if ((object.ReferenceEquals(this.ObservacionesField, value) != true)) {
                    this.ObservacionesField = value;
                    this.RaisePropertyChanged("Observaciones");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CapacidadAlmacenamientoServicio_T.ICapacidadAlmacenamientoContrato")]
    public interface ICapacidadAlmacenamientoContrato {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICapacidadAlmacenamientoContrato/Obtener", ReplyAction="http://tempuri.org/ICapacidadAlmacenamientoContrato/ObtenerResponse")]
        Ine.SihPublico.UI.Web.CapacidadAlmacenamientoServicio_T.CapacidadAlmacenamiento Obtener(int idCapacidadAlmacenamiento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICapacidadAlmacenamientoContrato/ObtenerListadoPorAgenteEconom" +
            "ico", ReplyAction="http://tempuri.org/ICapacidadAlmacenamientoContrato/ObtenerListadoPorAgenteEconom" +
            "icoResponse")]
        System.Collections.Generic.List<Ine.SihPublico.UI.Web.CapacidadAlmacenamientoServicio_T.CapacidadAlmacenamiento> ObtenerListadoPorAgenteEconomico(int idAgenteEconomico);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICapacidadAlmacenamientoContratoChannel : Ine.SihPublico.UI.Web.CapacidadAlmacenamientoServicio_T.ICapacidadAlmacenamientoContrato, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CapacidadAlmacenamientoContratoClient : System.ServiceModel.ClientBase<Ine.SihPublico.UI.Web.CapacidadAlmacenamientoServicio_T.ICapacidadAlmacenamientoContrato>, Ine.SihPublico.UI.Web.CapacidadAlmacenamientoServicio_T.ICapacidadAlmacenamientoContrato {
        
        public CapacidadAlmacenamientoContratoClient() {
        }
        
        public CapacidadAlmacenamientoContratoClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CapacidadAlmacenamientoContratoClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CapacidadAlmacenamientoContratoClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CapacidadAlmacenamientoContratoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Ine.SihPublico.UI.Web.CapacidadAlmacenamientoServicio_T.CapacidadAlmacenamiento Obtener(int idCapacidadAlmacenamiento) {
            return base.Channel.Obtener(idCapacidadAlmacenamiento);
        }
        
        public System.Collections.Generic.List<Ine.SihPublico.UI.Web.CapacidadAlmacenamientoServicio_T.CapacidadAlmacenamiento> ObtenerListadoPorAgenteEconomico(int idAgenteEconomico) {
            return base.Channel.ObtenerListadoPorAgenteEconomico(idAgenteEconomico);
        }
    }
}