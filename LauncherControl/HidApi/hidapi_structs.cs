using System;
using System.Runtime.InteropServices;

namespace LauncherControl.HidApi
{
	[StructLayout(LayoutKind.Sequential,CharSet=CharSet.Ansi)]
		public unsafe struct hid_device_info{
		[MarshalAs (UnmanagedType.LPStr)]
		public string path;
		public ushort vendor_id;
			public ushort product_id;
		[MarshalAs (UnmanagedType.LPWStr)]
       public string serial_number;
		public	ushort release_number;
		[MarshalAs (UnmanagedType.LPWStr)]
		public	string manufacturer_string;
		[MarshalAs (UnmanagedType.LPWStr)]
		public	string product_string;
	public		ushort usge_page;
	public		ushort usage;
	public		int interface_number;
			private IntPtr next;			
		}

}

