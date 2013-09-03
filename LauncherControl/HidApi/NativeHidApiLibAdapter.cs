using System;
using System.Runtime.InteropServices;
using System.Text;

namespace LauncherControl.HidApi
{
	public class NativeHidApiLibAdapter
	{
		
		
		[DllImport ("libhidapi-libusb.so")]
 	     public extern static IntPtr hid_enumerate (ushort vendor, ushort product);
		
		[DllImport ("libhidapi-libusb.so")]
 	     public extern static IntPtr hid_open_path (StringBuilder device_path);

		[DllImport ("libhidapi-libusb.so")]
 	     public extern static void hid_close (IntPtr device);
		
		///size_t==IntPtr, platform dependend standard int it seems
		///c unsigned char== c# byte
		[DllImport ("libhidapi-libusb.so")]
 	     public extern static int hid_write (IntPtr device, IntPtr data, IntPtr length);
		
		[DllImport ("libhidapi-libusb.so")]
 	    public extern static int hid_get_feature_report	(IntPtr	device, IntPtr data, IntPtr length );	
		
		[DllImport ("libhidapi-libusb.so")]
 	    public extern static int hid_read	(IntPtr	device, IntPtr data, IntPtr length );	
		
	}
}

