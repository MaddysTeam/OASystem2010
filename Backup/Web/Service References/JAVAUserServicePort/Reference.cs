﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:2.0.50727.5485
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dianda.Web.JAVAUserServicePort {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://ws.jypt.dianda.com/", ConfigurationName="JAVAUserServicePort.UserServiceDelegate")]
    public interface UserServiceDelegate {
        
        // CODEGEN: 命名空间  的元素名称 arg0 以后生成的消息协定未标记为 nillable
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        Dianda.Web.JAVAUserServicePort.importUserResponse importUser(Dianda.Web.JAVAUserServicePort.importUserRequest request);
        
        // CODEGEN: 命名空间  的元素名称 arg0 以后生成的消息协定未标记为 nillable
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        Dianda.Web.JAVAUserServicePort.editUserResponse editUser(Dianda.Web.JAVAUserServicePort.editUserRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class importUserRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="importUser", Namespace="http://ws.jypt.dianda.com/", Order=0)]
        public Dianda.Web.JAVAUserServicePort.importUserRequestBody Body;
        
        public importUserRequest() {
        }
        
        public importUserRequest(Dianda.Web.JAVAUserServicePort.importUserRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class importUserRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string arg0;
        
        public importUserRequestBody() {
        }
        
        public importUserRequestBody(string arg0) {
            this.arg0 = arg0;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class importUserResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="importUserResponse", Namespace="http://ws.jypt.dianda.com/", Order=0)]
        public Dianda.Web.JAVAUserServicePort.importUserResponseBody Body;
        
        public importUserResponse() {
        }
        
        public importUserResponse(Dianda.Web.JAVAUserServicePort.importUserResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class importUserResponseBody {
        
        public importUserResponseBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class editUserRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="editUser", Namespace="http://ws.jypt.dianda.com/", Order=0)]
        public Dianda.Web.JAVAUserServicePort.editUserRequestBody Body;
        
        public editUserRequest() {
        }
        
        public editUserRequest(Dianda.Web.JAVAUserServicePort.editUserRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class editUserRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string arg0;
        
        public editUserRequestBody() {
        }
        
        public editUserRequestBody(string arg0) {
            this.arg0 = arg0;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class editUserResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="editUserResponse", Namespace="http://ws.jypt.dianda.com/", Order=0)]
        public Dianda.Web.JAVAUserServicePort.editUserResponseBody Body;
        
        public editUserResponse() {
        }
        
        public editUserResponse(Dianda.Web.JAVAUserServicePort.editUserResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class editUserResponseBody {
        
        public editUserResponseBody() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface UserServiceDelegateChannel : Dianda.Web.JAVAUserServicePort.UserServiceDelegate, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class UserServiceDelegateClient : System.ServiceModel.ClientBase<Dianda.Web.JAVAUserServicePort.UserServiceDelegate>, Dianda.Web.JAVAUserServicePort.UserServiceDelegate {
        
        public UserServiceDelegateClient() {
        }
        
        public UserServiceDelegateClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserServiceDelegateClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceDelegateClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceDelegateClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Dianda.Web.JAVAUserServicePort.importUserResponse Dianda.Web.JAVAUserServicePort.UserServiceDelegate.importUser(Dianda.Web.JAVAUserServicePort.importUserRequest request) {
            return base.Channel.importUser(request);
        }
        
        public void importUser(string arg0) {
            Dianda.Web.JAVAUserServicePort.importUserRequest inValue = new Dianda.Web.JAVAUserServicePort.importUserRequest();
            inValue.Body = new Dianda.Web.JAVAUserServicePort.importUserRequestBody();
            inValue.Body.arg0 = arg0;
            Dianda.Web.JAVAUserServicePort.importUserResponse retVal = ((Dianda.Web.JAVAUserServicePort.UserServiceDelegate)(this)).importUser(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Dianda.Web.JAVAUserServicePort.editUserResponse Dianda.Web.JAVAUserServicePort.UserServiceDelegate.editUser(Dianda.Web.JAVAUserServicePort.editUserRequest request) {
            return base.Channel.editUser(request);
        }
        
        public void editUser(string arg0) {
            Dianda.Web.JAVAUserServicePort.editUserRequest inValue = new Dianda.Web.JAVAUserServicePort.editUserRequest();
            inValue.Body = new Dianda.Web.JAVAUserServicePort.editUserRequestBody();
            inValue.Body.arg0 = arg0;
            Dianda.Web.JAVAUserServicePort.editUserResponse retVal = ((Dianda.Web.JAVAUserServicePort.UserServiceDelegate)(this)).editUser(inValue);
        }
    }
}
