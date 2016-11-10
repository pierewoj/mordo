using Mordo.Desktop.Models;
using System;
using System.Collections.Generic;

namespace Mordo.Desktop.MessageProcessing
{
    class MessageProcessor : IMessageProcessor
    {
        public void ProcessMessage(string message, RobotState state, ICollection<Controller> controllers)
        {
            throw new NotImplementedException();
        }
    }
}
