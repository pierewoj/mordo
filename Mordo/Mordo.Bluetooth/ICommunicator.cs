using System;

namespace Mordo.Bluetooth
{
    public interface ICommunicator
    {
        event EventHandler<string> DataReceived;
        bool IsConnected { get; }
        void Connect(int baudRate, string portName);
        void Disconnect();
        void SendMessage(string msg);
    }
}