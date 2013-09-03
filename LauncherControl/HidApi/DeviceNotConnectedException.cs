using System;

namespace LauncherControl
{
	public class DeviceNotConnectedException:Exception
	{
		public DeviceNotConnectedException ():base("Missile Launcher not connected!")
		{
			
		}
	}
}

