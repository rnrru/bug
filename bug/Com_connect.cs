using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace bug
{
    class Com_connect
    {
        // Все опции для последовательного устройства
        // ---- могут быть отправлены через конструктор класса SerialPort
        // ---- PortName = "COM1", Baud Rate = 19200, Parity = None,
        // ---- Data Bits = 8, Stop Bits = One, Handshake = None
        SerialPort _serialPort;
        //string writeStr;
        public void Create_connect(string comPort)
        {
            _serialPort = new SerialPort(comPort,
                                         9600,
                                         Parity.None,
                                         8,
                                         StopBits.One);
            _serialPort.Handshake = Handshake.None;
            _serialPort.ReadTimeout = 500;
        }

        public void Wrire_str(string writeStr)
        {
            _serialPort.Write(writeStr);
        }

        public string Read_str()
        {             
            string readFromPort = _serialPort.ReadLine();            
            return readFromPort;
        }

        public void Open_connect()
        {
            _serialPort.Open();
        }

        public void Close_conncet()
        {
            _serialPort.Close();
        }
    }
}
