using System;
using LauncherControl.HidApi;

namespace LauncherControl
{
	public class UpCommand : TimedCommand
	{
		public UpCommand (USBDevice dev, int ticks):base(dev, ticks){}
		
		public override void execute ()
		{
			device.up ();
		}
		
	}
}
