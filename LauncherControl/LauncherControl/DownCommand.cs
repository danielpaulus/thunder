using System;
using LauncherControl.HidApi;

namespace LauncherControl
{
	public class DownCommand : TimedCommand
	{
		public DownCommand (USBDevice dev, int ticks):base(dev, ticks){}
		
		public override void execute ()
		{
			device.down();
		}
		
	}
}
