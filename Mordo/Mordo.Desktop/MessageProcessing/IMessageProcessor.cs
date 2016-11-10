using Mordo.Desktop.Models;
using System.Collections.Generic;

namespace Mordo.Desktop.MessageProcessing
{
    internal interface IMessageProcessor
    {
        void ProcessMessage(string message, RobotState state, ICollection<Controller> controllers);
    }
}