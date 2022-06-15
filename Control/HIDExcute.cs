using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibUsbDotNet;
using LibUsbDotNet.Main;

namespace HOYA_IOT.Control
{
    public class HIDExcute
    {
        public int VID { get; set; }
        public int PID { get; set; }
        private UsbDevice MyUsbDevice;
        private UsbDeviceFinder MyUsbDeviceFinder;
        private UsbEndpointReader MyUsbEndpointReader;
        private UsbEndpointWriter MyUsbEndpointWriter;
        public HIDExcute(int vid, int pid) 
        {
            this.VID = vid;
            this.PID = pid;
        }
    }
}
