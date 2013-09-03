using System;
using LauncherControl.HidApi;

namespace LauncherControl
{
	public class FireCommand: TimedCommand
	{
		
		public FireCommand (USBDevice dev, int ticks):base(dev, ticks){}
		
		public override void execute ()
		{
			if (Ticks>-1 && Ticks%2 ==0){ 
				Console.WriteLine("fire");
				device.fire();
					
							
			}
			Ticks--;
		}
	}
}

