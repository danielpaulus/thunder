using System;
using MonoLibUsb.Profile;
using Usb = MonoLibUsb.MonoUsbApi;
using MonoLibUsb;
using System.Runtime.InteropServices;
using System.Text;
using LauncherControl.HidApi;
using System.Threading;
using System.ServiceModel.Web;

namespace LauncherControl
{
    internal class ShowInfo
    {
      
        public static void Main(string[] args)
        {
     using (USBMissileLauncher dev= new USBMissileLauncher()){
    RocketService DemoServices = new RocketService(dev);
    WebServiceHost _serviceHost = new WebServiceHost(DemoServices, 
                                                     new Uri("http://localhost:8000/RocketService"));
    _serviceHost.Open();
    Console.ReadKey();
    _serviceHost.Close();
			}
			//Fire ();
        }

		
		
		
    }
}