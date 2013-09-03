using System;
using System.Text;
using System.Timers;
using LauncherControl.HidApi;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace LauncherControl
{
	public class USBMissileLauncher: IDisposable
	{
		
        private Timer launcherTimer;
		private USBDevice device;
		private ConcurrentQueue<TimedCommand> commandQueue;
		
		public bool IsFiring{get{
				if (commandQueue.Count==0) return false;
				TimedCommand cmd;
				commandQueue.TryPeek(out cmd);
				return cmd.GetType()==typeof(FireCommand); 
			}}
		
		public USBMissileLauncher ()
		{
			commandQueue= new ConcurrentQueue<TimedCommand>();
			device = new USBDevice();
			device.turnLedOn();
			InitTimer();
			

		}

		public void InitTimer ()
		{
        launcherTimer = new Timer(20);

        launcherTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);

        launcherTimer.Enabled = true;
			GC.KeepAlive(launcherTimer);
		}
		
		public void fire(){
			if(!IsFiring){
			device.stop();
			commandQueue.Enqueue(new FireCommand(device,150));
			commandQueue.Enqueue(new StopCommand(device,0));
			}
		}
		
		public void left ()
		{
			stop ();
			commandQueue.Enqueue(new LeftCommand(device,0));
		}
		
		public void right ()
		{
			stop ();
			commandQueue.Enqueue(new RightCommand(device,0));
		}
		
		public void up ()
		{
			stop();
			commandQueue.Enqueue(new UpCommand(device,0));
		}
		
		public void down ()
		{
			stop ();
			commandQueue.Enqueue(new DownCommand(device,0));
		}
		
		
		public void stop ()
		{
				if (!IsFiring) commandQueue= new ConcurrentQueue<TimedCommand>();
			commandQueue.Enqueue(new StopCommand(device,0));
		
		}
		
		
		private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
			if (commandQueue.Count==0) return;
			TimedCommand cmd;
			commandQueue.TryPeek(out cmd);
			
			cmd.execute();
			if (cmd.Ticks==-1) commandQueue.TryDequeue(out cmd);
        
    }
		
		private void ConfVersion(){
			//	this.Vertical = TimeSpan.Parse("00:00:00.1959375");
		//		this.Horizon = TimeSpan.Parse("00:00:02.9640925");
			
		}
			
    

		
		
		private void log(String s){
			Console.WriteLine(s);
		}
		public void Dispose ()
		{
			launcherTimer.Stop();
			commandQueue=null;
			device.stop();
			device.turnLedOff();
			device.Dispose();			               
		}
	}
}

