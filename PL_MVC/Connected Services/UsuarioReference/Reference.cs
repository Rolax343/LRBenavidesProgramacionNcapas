﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PL_MVC.UsuarioReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Result", Namespace="http://schemas.datacontract.org/2004/07/SL_WCF")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(System.Exception))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(object[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Usuario))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Direccion))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Colonia))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Municipio))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Estado))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Rol))]
    public partial class Result : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool CorrectField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorMessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Exception ExField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object ObjectField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object[] ObjectsField;
        
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
        public bool Correct {
            get {
                return this.CorrectField;
            }
            set {
                if ((this.CorrectField.Equals(value) != true)) {
                    this.CorrectField = value;
                    this.RaisePropertyChanged("Correct");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ErrorMessage {
            get {
                return this.ErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMessageField, value) != true)) {
                    this.ErrorMessageField = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Exception Ex {
            get {
                return this.ExField;
            }
            set {
                if ((object.ReferenceEquals(this.ExField, value) != true)) {
                    this.ExField = value;
                    this.RaisePropertyChanged("Ex");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object Object {
            get {
                return this.ObjectField;
            }
            set {
                if ((object.ReferenceEquals(this.ObjectField, value) != true)) {
                    this.ObjectField = value;
                    this.RaisePropertyChanged("Object");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object[] Objects {
            get {
                return this.ObjectsField;
            }
            set {
                if ((object.ReferenceEquals(this.ObjectsField, value) != true)) {
                    this.ObjectsField = value;
                    this.RaisePropertyChanged("Objects");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UsuarioReference.IUsuario")]
    public interface IUsuario {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuario/UsuarioAdd", ReplyAction="http://tempuri.org/IUsuario/UsuarioAddResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(PL_MVC.UsuarioReference.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Municipio))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Estado))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Rol))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Colonia))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Direccion))]
        PL_MVC.UsuarioReference.Result UsuarioAdd(ML.Usuario usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuario/UsuarioAdd", ReplyAction="http://tempuri.org/IUsuario/UsuarioAddResponse")]
        System.Threading.Tasks.Task<PL_MVC.UsuarioReference.Result> UsuarioAddAsync(ML.Usuario usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuario/UsuarioGetAll", ReplyAction="http://tempuri.org/IUsuario/UsuarioGetAllResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(PL_MVC.UsuarioReference.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Municipio))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Estado))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Rol))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Colonia))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Direccion))]
        PL_MVC.UsuarioReference.Result UsuarioGetAll(ML.Usuario usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuario/UsuarioGetAll", ReplyAction="http://tempuri.org/IUsuario/UsuarioGetAllResponse")]
        System.Threading.Tasks.Task<PL_MVC.UsuarioReference.Result> UsuarioGetAllAsync(ML.Usuario usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuario/UsuarioUpdate", ReplyAction="http://tempuri.org/IUsuario/UsuarioUpdateResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(PL_MVC.UsuarioReference.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Municipio))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Estado))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Rol))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Colonia))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Direccion))]
        PL_MVC.UsuarioReference.Result UsuarioUpdate(ML.Usuario usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuario/UsuarioUpdate", ReplyAction="http://tempuri.org/IUsuario/UsuarioUpdateResponse")]
        System.Threading.Tasks.Task<PL_MVC.UsuarioReference.Result> UsuarioUpdateAsync(ML.Usuario usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuario/UsuarioDelete", ReplyAction="http://tempuri.org/IUsuario/UsuarioDeleteResponse")]
        PL_MVC.UsuarioReference.Result UsuarioDelete(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuario/UsuarioDelete", ReplyAction="http://tempuri.org/IUsuario/UsuarioDeleteResponse")]
        System.Threading.Tasks.Task<PL_MVC.UsuarioReference.Result> UsuarioDeleteAsync(int Id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUsuarioChannel : PL_MVC.UsuarioReference.IUsuario, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UsuarioClient : System.ServiceModel.ClientBase<PL_MVC.UsuarioReference.IUsuario>, PL_MVC.UsuarioReference.IUsuario {
        
        public UsuarioClient() {
        }
        
        public UsuarioClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UsuarioClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UsuarioClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UsuarioClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public PL_MVC.UsuarioReference.Result UsuarioAdd(ML.Usuario usuario) {
            return base.Channel.UsuarioAdd(usuario);
        }
        
        public System.Threading.Tasks.Task<PL_MVC.UsuarioReference.Result> UsuarioAddAsync(ML.Usuario usuario) {
            return base.Channel.UsuarioAddAsync(usuario);
        }
        
        public PL_MVC.UsuarioReference.Result UsuarioGetAll(ML.Usuario usuario) {
            return base.Channel.UsuarioGetAll(usuario);
        }
        
        public System.Threading.Tasks.Task<PL_MVC.UsuarioReference.Result> UsuarioGetAllAsync(ML.Usuario usuario) {
            return base.Channel.UsuarioGetAllAsync(usuario);
        }
        
        public PL_MVC.UsuarioReference.Result UsuarioUpdate(ML.Usuario usuario) {
            return base.Channel.UsuarioUpdate(usuario);
        }
        
        public System.Threading.Tasks.Task<PL_MVC.UsuarioReference.Result> UsuarioUpdateAsync(ML.Usuario usuario) {
            return base.Channel.UsuarioUpdateAsync(usuario);
        }
        
        public PL_MVC.UsuarioReference.Result UsuarioDelete(int Id) {
            return base.Channel.UsuarioDelete(Id);
        }
        
        public System.Threading.Tasks.Task<PL_MVC.UsuarioReference.Result> UsuarioDeleteAsync(int Id) {
            return base.Channel.UsuarioDeleteAsync(Id);
        }
    }
}
