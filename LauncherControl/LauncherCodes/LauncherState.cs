using System;

namespace LauncherControl
{
	public class LauncherState
	{
		
		private enum STATUS
		{
			IDLE,
			DOWN_LIMIT,
			UP_LIMIT,
			LEFT_LIMIT = 4,
			RIGHT_LIMIT = 8,
			FIRED = 16
		}
		public LauncherState ()
		{
		}
	}
}

