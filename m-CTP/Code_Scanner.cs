using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m_CTP
{
    class Code_Scanner
    {
        public static SerialPort serialPort;



        public static  void LinkPort() 
        {
            serialPort = new SerialPort();
            serialPort.PortName = "COM5";
            serialPort.BaudRate = 9600;
            serialPort.DataBits = 8;
            serialPort.StopBits = StopBits.One;
            serialPort.Parity = Parity.None;
            serialPort.DataReceived += serialPort1_DataReceived;
        }

        public static void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e) 
        {

        }
    }
}
