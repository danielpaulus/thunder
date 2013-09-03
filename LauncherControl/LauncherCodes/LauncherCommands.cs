using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace LauncherControl
{
	public class LauncherCommands : IDisposable
	{	
		private byte[] LED_ON;
		private IntPtr p_led_on=IntPtr.Zero;
		public Command Led_On{get{
				if (p_led_on==IntPtr.Zero){
					p_led_on=getBuffer(LED_ON);
				}
				return new Command(p_led_on,LED_ON.Length);
			}}
		
		private byte[] LED_OFF;
		private IntPtr p_led_off=IntPtr.Zero;
		public Command Led_Off{get{
				if (p_led_off==IntPtr.Zero){
					p_led_off=getBuffer(LED_OFF);
				}
				return new Command(p_led_off,LED_OFF.Length);
			}}
		
		public byte[] UP;
		private IntPtr p_up=IntPtr.Zero;
		public Command Up{get{
				if (p_up==IntPtr.Zero){
					p_up=getBuffer(UP);
				}
				return new Command(p_up,UP.Length);
			}}
		
		
		public byte[] DOWN;
		private IntPtr p_down=IntPtr.Zero;
		public Command Down{get{
				if (p_down==IntPtr.Zero){
					p_down=getBuffer(DOWN);
				}
				return new Command(p_down,DOWN.Length);
			}}
		
		public byte[] LEFT;
		private IntPtr p_left=IntPtr.Zero;
		public Command Left{get{
				if (p_left==IntPtr.Zero){
					p_left=getBuffer(LEFT);
				}
				return new Command(p_left,LEFT.Length);
			}}
		
		
		public byte[] RIGHT;
		private IntPtr p_right=IntPtr.Zero;
		public Command Right{get{
				if (p_right==IntPtr.Zero){
					p_right=getBuffer(RIGHT);
				}
				return new Command(p_right,RIGHT.Length);
			}}
		
		public byte[] FIRE;
		private IntPtr p_fire=IntPtr.Zero;
		public Command Fire{get{
				if (p_fire==IntPtr.Zero){
					p_fire=getBuffer(FIRE);
				}
				return new Command(p_fire,FIRE.Length);
			}}
		
		public byte[] STOP;
		private IntPtr p_stop=IntPtr.Zero;
		public Command Stop{get{
				if (p_stop==IntPtr.Zero){
					p_stop=getBuffer(STOP);
				}
				return new Command(p_stop,STOP.Length);
			}}
		
		public byte[] GET_STATUS;
		private IntPtr p_get_status=IntPtr.Zero;
		public Command GetStatus{get{
				if (p_get_status==IntPtr.Zero){
					p_get_status=getBuffer(GET_STATUS);
				}
				return new Command(p_get_status,GET_STATUS.Length);
			}}
		
		private List<GCHandle> handles;
		
		public LauncherCommands ()
		{
			byte[] array = new byte[10];
			array[1] = 2;
			array[2] = 2;
			this.UP = array;
			byte[] array2 = new byte[10];
			array2[1] = 2;
			array2[2] = 1;
			this.DOWN = array2;
			byte[] array3 = new byte[10];
			array3[1] = 2;
			array3[2] = 4;
			this.LEFT = array3;
			byte[] array4 = new byte[10];
			array4[1] = 2;
			array4[2] = 8;
			this.RIGHT = array4;
			byte[] array5 = new byte[10];
			array5[1] = 2;
			array5[2] = 16;
			this.FIRE = array5;
			byte[] array6 = new byte[10];
			array6[1] = 2;
			array6[2] = 32;
			this.STOP = array6;
			byte[] array7 = new byte[9];
			array7[1] = 1;
			this.GET_STATUS = array7;
			byte[] array8 = new byte[9];
			array8[1] = 3;
			array8[2] = 1;
			this.LED_ON = array8;
			byte[] array9 = new byte[9];
			array9[1] = 3;
			this.LED_OFF = array9;
		}
		
		private IntPtr getBuffer(byte[] data){
			if (handles==null) handles = new List<GCHandle>();
			GCHandle pinnedArray= GCHandle.Alloc (data, GCHandleType.Pinned);
			IntPtr pointer = pinnedArray.AddrOfPinnedObject();
			handles.Add(pinnedArray);
			return pointer;
		}
		
		public void Dispose ()
		{
			if (handles==null) return;
			foreach(var handle in handles){
				if (handle==null) continue;
				handle.Free();
			}
			handles.Clear();
		}
	}
}

