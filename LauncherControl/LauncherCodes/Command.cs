using System;
using System.Runtime.InteropServices;
namespace LauncherControl
{
	public class Command
	{
		public IntPtr Pointer{get; private set;}
		public int Length{get; private set;}
		
		public Command (IntPtr p, int length)
		{
			Pointer=p;
			Length=length;
			
			
		}
	}
}

