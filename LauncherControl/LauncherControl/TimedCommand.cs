using System;
using LauncherControl.HidApi;

namespace LauncherControl
{
	public abstract class TimedCommand
	{
		public int Ticks{get;protected set;}
		
	protected USBDevice device;
		
		public TimedCommand (USBDevice dev, int ticks)
		{
			device=dev;
			Ticks=ticks;
		}
		
		public abstract void execute();
	}
}

