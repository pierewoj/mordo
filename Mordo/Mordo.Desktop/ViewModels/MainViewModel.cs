using Mordo.Bluetooth;
using Mordo.Desktop.MessageProcessing;
using Mordo.Desktop.Models;

namespace Mordo.Desktop.ViewModels
{
    partial class MainViewModel : ViewModel
    {
        private RobotState _robotState;
        public RobotState RobotState
        {
            get { return _robotState; }
            set { _robotState = value; OnPropertyChanged(); }
        }

        private readonly ICommunicator _communicator;
        private readonly IMessageProcessor _messageProcessor;
        private readonly IMessageBuilder _messageBuilder;

        public MainViewModel(ICommunicator communicator, IMessageBuilder messageBuilder, IMessageProcessor messageProcessor)
        {
            _messageBuilder = messageBuilder;
            _messageProcessor = messageProcessor;
            _communicator = communicator;
            RegisterCommands();
        }


    }
}
