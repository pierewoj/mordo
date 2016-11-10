using Mordo.Bluetooth;
using Mordo.Desktop.Models;

namespace Mordo.Desktop.MessageProcessing
{
    internal interface IMessageProcessor
    {
        RobotState ProcessMessage(Message message);
    }
}