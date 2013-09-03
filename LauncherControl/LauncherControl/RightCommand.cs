using System;
using LauncherControl.HidApi;

namespace LauncherControl
{
	public class RightCommand : TimedCommand
	{
		public RightCommand (USBDevice dev, int ticks):base(dev, ticks){}
		
		public override void execute ()
		{
			device.right();
			
		}
		
	}
}
