﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalProject_RMTApp.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Connect", ReplyAction="http://tempuri.org/IService1/ConnectResponse")]
        System.Data.DataSet Connect(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Connect", ReplyAction="http://tempuri.org/IService1/ConnectResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> ConnectAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SelectWithInt", ReplyAction="http://tempuri.org/IService1/SelectWithIntResponse")]
        System.Data.DataSet SelectWithInt(string name, string parameter, int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SelectWithInt", ReplyAction="http://tempuri.org/IService1/SelectWithIntResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> SelectWithIntAsync(string name, string parameter, int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SelectWithString", ReplyAction="http://tempuri.org/IService1/SelectWithStringResponse")]
        System.Data.DataSet SelectWithString(string name, string parameter, string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SelectWithString", ReplyAction="http://tempuri.org/IService1/SelectWithStringResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> SelectWithStringAsync(string name, string parameter, string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/InsertTransactionBuy", ReplyAction="http://tempuri.org/IService1/InsertTransactionBuyResponse")]
        bool InsertTransactionBuy(string userID, string price, string purchase, string sellerID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/InsertTransactionBuy", ReplyAction="http://tempuri.org/IService1/InsertTransactionBuyResponse")]
        System.Threading.Tasks.Task<bool> InsertTransactionBuyAsync(string userID, string price, string purchase, string sellerID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DeleteByID", ReplyAction="http://tempuri.org/IService1/DeleteByIDResponse")]
        bool DeleteByID(string name, string id, string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DeleteByID", ReplyAction="http://tempuri.org/IService1/DeleteByIDResponse")]
        System.Threading.Tasks.Task<bool> DeleteByIDAsync(string name, string id, string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UpdateWithField", ReplyAction="http://tempuri.org/IService1/UpdateWithFieldResponse")]
        void UpdateWithField(string table, string fieldName, string value, string idfield, string idvalue);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UpdateWithField", ReplyAction="http://tempuri.org/IService1/UpdateWithFieldResponse")]
        System.Threading.Tasks.Task UpdateWithFieldAsync(string table, string fieldName, string value, string idfield, string idvalue);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/execute", ReplyAction="http://tempuri.org/IService1/executeResponse")]
        void execute(string query);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/execute", ReplyAction="http://tempuri.org/IService1/executeResponse")]
        System.Threading.Tasks.Task executeAsync(string query);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UpdateWithDouble", ReplyAction="http://tempuri.org/IService1/UpdateWithDoubleResponse")]
        void UpdateWithDouble(string table, string fieldName, double value, string idfield, string idvalue);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UpdateWithDouble", ReplyAction="http://tempuri.org/IService1/UpdateWithDoubleResponse")]
        System.Threading.Tasks.Task UpdateWithDoubleAsync(string table, string fieldName, double value, string idfield, string idvalue);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : FinalProject_RMTApp.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<FinalProject_RMTApp.ServiceReference1.IService1>, FinalProject_RMTApp.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataSet Connect(string name) {
            return base.Channel.Connect(name);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ConnectAsync(string name) {
            return base.Channel.ConnectAsync(name);
        }
        
        public System.Data.DataSet SelectWithInt(string name, string parameter, int value) {
            return base.Channel.SelectWithInt(name, parameter, value);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> SelectWithIntAsync(string name, string parameter, int value) {
            return base.Channel.SelectWithIntAsync(name, parameter, value);
        }
        
        public System.Data.DataSet SelectWithString(string name, string parameter, string value) {
            return base.Channel.SelectWithString(name, parameter, value);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> SelectWithStringAsync(string name, string parameter, string value) {
            return base.Channel.SelectWithStringAsync(name, parameter, value);
        }
        
        public bool InsertTransactionBuy(string userID, string price, string purchase, string sellerID) {
            return base.Channel.InsertTransactionBuy(userID, price, purchase, sellerID);
        }
        
        public System.Threading.Tasks.Task<bool> InsertTransactionBuyAsync(string userID, string price, string purchase, string sellerID) {
            return base.Channel.InsertTransactionBuyAsync(userID, price, purchase, sellerID);
        }
        
        public bool DeleteByID(string name, string id, string value) {
            return base.Channel.DeleteByID(name, id, value);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteByIDAsync(string name, string id, string value) {
            return base.Channel.DeleteByIDAsync(name, id, value);
        }
        
        public void UpdateWithField(string table, string fieldName, string value, string idfield, string idvalue) {
            base.Channel.UpdateWithField(table, fieldName, value, idfield, idvalue);
        }
        
        public System.Threading.Tasks.Task UpdateWithFieldAsync(string table, string fieldName, string value, string idfield, string idvalue) {
            return base.Channel.UpdateWithFieldAsync(table, fieldName, value, idfield, idvalue);
        }
        
        public void execute(string query) {
            base.Channel.execute(query);
        }
        
        public System.Threading.Tasks.Task executeAsync(string query) {
            return base.Channel.executeAsync(query);
        }
        
        public void UpdateWithDouble(string table, string fieldName, double value, string idfield, string idvalue) {
            base.Channel.UpdateWithDouble(table, fieldName, value, idfield, idvalue);
        }
        
        public System.Threading.Tasks.Task UpdateWithDoubleAsync(string table, string fieldName, double value, string idfield, string idvalue) {
            return base.Channel.UpdateWithDoubleAsync(table, fieldName, value, idfield, idvalue);
        }
    }
}