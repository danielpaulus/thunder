using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Timers;


namespace LauncherControl.HidApi
{
	public class USBDevice : IDisposable
	{
		//timer interval tick
		private const byte tick=20;
		
		private const ushort vid=8483;
		private const ushort pid=4112;
		private hid_device_info info;
		private LauncherCommands cmd;
		private IntPtr device=IntPtr.Zero;
		public String ManufacturerString {get; private set;}

		public String Path {get; private set;}
			public String ProductString {get; private set;}
		private Timer statusTimer;
		public USBDevice () 
		{
		
		//string s=	Marshal.PtrToStringAnsi(res.manufacturer_string);
		//	var device = new USBDevice(st);
			
			
			cmd = new LauncherCommands();
			
			initialize();
			openDevice();
			
			
			//InitTimer();
			
			
		}
		
		public void InitTimer ()
		{
        statusTimer = new Timer(50);

        statusTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);

        statusTimer.Enabled = true;
			GC.KeepAlive(statusTimer);
		}
		private byte state=0;
			private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
			state= read ()[1];
			Console.WriteLine("status:"+state);
			
		}
		
		private void openDevice(){
			StringBuilder path= new StringBuilder(info.path,info.path.Length);
			device=NativeHidApiLibAdapter.hid_open_path(path);
		}
		
		private void initialize(){
			var	res=NativeHidApiLibAdapter.hid_enumerate(vid,pid);
			if (res==IntPtr.Zero) throw new DeviceNotConnectedException();
		info=(hid_device_info)	Marshal.PtrToStructure(res, typeof(hid_device_info));
			
		}
		
		public void turnLedOff(){
		int result=NativeHidApiLibAdapter.hid_write(device,cmd.Led_Off.Pointer,new IntPtr(cmd.Led_Off.Length));
			checkResult(result);
		}
		
		public void turnLedOn(){
		int result=NativeHidApiLibAdapter.hid_write(device,cmd.Led_On.Pointer,new IntPtr(cmd.Led_On.Length));
			checkResult(result);
		}
		
		public void fire(){
		int result=NativeHidApiLibAdapter.hid_write(device,cmd.Fire.Pointer,new IntPtr(cmd.Fire.Length));
			checkResult(result);			
		}
		
		public void stop(){
		int result=NativeHidApiLibAdapter.hid_write(device,cmd.Stop.Pointer,new IntPtr(cmd.Stop.Length));
			checkResult(result);			
		}
		public void right(){
		int result=NativeHidApiLibAdapter.hid_write(device,cmd.Right.Pointer,new IntPtr(cmd.Right.Length));
			checkResult(result);			
		}
		public void left(){
		int result=NativeHidApiLibAdapter.hid_write(device,cmd.Left.Pointer,new IntPtr(cmd.Left.Length));
			checkResult(result);			
		}
		public void down(){
		int result=NativeHidApiLibAdapter.hid_write(device,cmd.Down.Pointer,new IntPtr(cmd.Down.Length));
			checkResult(result);			
		}
		public void up(){
		int result=NativeHidApiLibAdapter.hid_write(device,cmd.Up.Pointer,new IntPtr(cmd.Up.Length));
			checkResult(result);			
		}
		public void get_status(){
		int result=NativeHidApiLibAdapter.hid_write(device,cmd.GetStatus.Pointer,new IntPtr(cmd.GetStatus.Length));
			checkResult(result);	
			read ();
		}
		
		private byte[] read(){
			IntPtr length=new IntPtr(32);
			IntPtr data= getBuffer(new byte[32]);
			int result=NativeHidApiLibAdapter.hid_read(device,data,length);
			var arr = new byte[result];
Marshal.Copy(data, arr, 0, result);
		return arr;
		}
		
		//right == 1,4 -- 1,8==right limit
		private IntPtr getBuffer(byte[] data){
			GCHandle pinnedArray= GCHandle.Alloc (data, GCHandleType.Pinned);
			IntPtr pointer = pinnedArray.AddrOfPinnedObject();
			return pointer;
		}
		
		private void checkResult(int result){}
		
		public void Dispose ()
		{
			NativeHidApiLibAdapter.hid_close(device);
			cmd.Dispose();
		}
	}
}

