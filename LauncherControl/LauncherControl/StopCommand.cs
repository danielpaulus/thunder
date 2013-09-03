using System;
using LauncherControl.HidApi;

namespace LauncherControl
{
	public class StopCommand : TimedCommand
	{
		public StopCommand (USBDevice dev, int ticks):base(dev, ticks){}
		
		public override void execute ()
		{
			if (Ticks==0) {
				Console.WriteLine("stop");
				device.stop();
				Ticks=-1;
			} else Ticks--;
		}
		
	}
}

