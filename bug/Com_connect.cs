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
        public void Create_connect(string comPort)
        {
            _serialPort = new SerialPort(comPort,
                                         19200,
                                         Parity.None,
                                         8,
                                         StopBits.One);
            _serialPort.Handshake = Handshake.None;
        }

        public void Open_connect()
        {
            _serialPort.Open();
        }
    }
}
