using System;
using System.ServiceModel.Web;
using System.ServiceModel;
using System.ServiceModel.Activation;
namespace LauncherControl
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, 
                 ConcurrencyMode = ConcurrencyMode.Single, IncludeExceptionDetailInFaults = true)]
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	public class RocketService: IRocketService{
		
		public RocketService ()
		{
		}
		private USBMissileLauncher launcher;
		public RocketService(USBMissileLauncher launcher){
			this.launcher=launcher;
		}
		
		public string fire ()
		{
			if (launcher.IsFiring) return "not ok";
			launcher.fire();
			return "ok";
		}
		
		public string up ()
		{
			launcher.up();
			
			return "ok";
		}

		public string down ()
		{
			launcher.down();
			return "ok";
		}

		public string left ()
		{
		launcher.left();
			return "ok";
		}

		public string right ()
		{
		launcher.right ();
			return "ok";
		}

		public string status ()
		{
			throw new NotImplementedException ();
		}
		public string stop ()
		{
			launcher.stop();
			return "ok";
		}
	}
}

