using System;
using LauncherControl.HidApi;

namespace LauncherControl
{
	public class LeftCommand : TimedCommand
	{
		public LeftCommand (USBDevice dev, int ticks):base(dev, ticks){}
		
		public override void execute ()
		{
		device.left();	
	
		}
		
	}
}
