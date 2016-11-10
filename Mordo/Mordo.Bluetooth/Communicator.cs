using System;
using System.IO.Ports;
using System.Threading;

namespace Mordo.Bluetooth
{
    public class Communicator : ICommunicator
    {
        private readonly object _locker = new object();
        private string _lineRead;
        private readonly SerialPort _serialPort;

        public event EventHandler<string> DataReceived;

        public bool IsConnected => _serialPort.IsOpen;

        public Communicator()
        {
            _serialPort = new SerialPort();
        }

        public void Connect(int baudRate, string portName)
        {
            Disconnect();
            _serialPort.BaudRate = baudRate;
            _serialPort.PortName = portName;
            _serialPort.DataReceived += port_DataReceived;
            _serialPort.ReadTimeout = 100;
            _serialPort.Open();
        }

        public void Disconnect()
        {
            if (IsConnected)
            {
                if (_serialPort != null && _serialPort.IsOpen)
                {
                    _serialPort.DataReceived -= port_DataReceived;
                    while (!(_serialPort.BytesToRead == 0 && _serialPort.BytesToWrite == 0))
                    {
                        _serialPort.DiscardInBuffer();
                        _serialPort.DiscardOutBuffer();
                    }
                    lock (_locker)
                    {
                        _serialPort.Close();
                    }
                }
            }
        }

        public void SendMessage(string msg)
        {
            if (IsConnected)
            {
                try
                {
                    _serialPort.WriteLine(msg);
                }
                catch (TimeoutException)
                {
                    Disconnect();
                }
            }
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            lock (_locker)
            {
                _lineRead = _serialPort.ReadLine();
            }
            ThreadPool.QueueUserWorkItem(DataReceivedPasser);
        }

        private void DataReceivedPasser(object o)
        {
            DataReceived?.Invoke(this, _lineRead);
        }
    }
}
