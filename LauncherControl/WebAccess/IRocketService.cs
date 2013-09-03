using System;
using System.ServiceModel.Web;
using System.ServiceModel;

namespace LauncherControl
{
	[ServiceContract(Name = "RocketService")]
	public interface IRocketService
	{
		 [OperationContract]
		[WebGet(UriTemplate = "/fire", BodyStyle = WebMessageBodyStyle.Bare)]
		 string fire();
	
	[OperationContract]
		[WebGet(UriTemplate = "/up", BodyStyle = WebMessageBodyStyle.Bare)]
		 string up();
		
		[OperationContract]
		[WebGet(UriTemplate = "/down", BodyStyle = WebMessageBodyStyle.Bare)]
		 string down();
		
		[OperationContract]
		[WebGet(UriTemplate = "/left", BodyStyle = WebMessageBodyStyle.Bare)]
		 string left();
		
		[OperationContract]
		[WebGet(UriTemplate = "/right", BodyStyle = WebMessageBodyStyle.Bare)]
		 string right();
		
		[OperationContract]
		[WebGet(UriTemplate = "/status", BodyStyle = WebMessageBodyStyle.Bare)]
		 string status();
		
		[OperationContract]
		[WebGet(UriTemplate = "/stop", BodyStyle = WebMessageBodyStyle.Bare)]
		 string stop();
	
	}
}

