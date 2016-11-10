using Mordo.Bluetooth;
using Mordo.Desktop.MessageProcessing;
using Mordo.Desktop.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

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

        private ObservableCollection<string> _possiblePorts = new ObservableCollection<string>();
        public ObservableCollection<string> PossiblePorts
        {
            get { return _possiblePorts; }
            set { _possiblePorts = value; OnPropertyChanged(); }
        }

        private ObservableCollection<int> _possibleBauds = new ObservableCollection<int>();
        public ObservableCollection<int> PossibleBauds
        {
            get { return _possibleBauds; }
            set { _possibleBauds = value; OnPropertyChanged(); }
        }

        private CommandSettings _commandSettings;
        public CommandSettings CommandSettings
        {
            get { return _commandSettings; }
            set { _commandSettings = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Controller> Controllers { get; } = new ObservableCollection<Controller>();

        private Controller _selectedController;
        public Controller SelectedController
        {
            get { return _selectedController; }
            set { _selectedController = value; OnPropertyChanged(); }
        }

        private ConnectionSettings _connectionSettings = new ConnectionSettings();
        public ConnectionSettings ConnectionSettings
        {
            get { return _connectionSettings; }
            set { _connectionSettings = value; OnPropertyChanged(); }
        }

        private readonly ICommunicator _communicator;
        private readonly IMessageProcessor _messageProcessor;
        private readonly IMessageBuilder _messageBuilder;


        public MainViewModel(ICommunicator communicator, IMessageBuilder messageBuilder, IMessageProcessor messageProcessor)
        {
            _messageBuilder = messageBuilder;
            _messageProcessor = messageProcessor;
            _communicator = communicator;

            _communicator.DataReceived += CommunicatorOnDataReceived;

            BuildControllers();
            GetPossibleConnectionSettings();
            RegisterCommands();
        }

        public MainViewModel()
        {
            if (!DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                throw new Exception("Default constructor called outside design mode. Check your IOC container");
        }

        private void GetPossibleConnectionSettings()
        {
            PossibleBauds.Add(1000000);
            ConnectionSettings.BaudRate = PossibleBauds.FirstOrDefault();

            foreach (var s in System.IO.Ports.SerialPort.GetPortNames())
            {
                PossiblePorts.Add(s);
            }
            ConnectionSettings.Port = PossiblePorts.FirstOrDefault();
        }

        private void BuildControllers()
        {
            Controllers.Add(new Controller("Controller1", 100));
            Controllers.Add(new Controller("Controller2", 100));
            Controllers.Add(new Controller("Controller3", 100));
            Controllers.Add(new Controller("Controller3", 100));

            SelectedController = Controllers.FirstOrDefault();

        }

        private void CommunicatorOnDataReceived(object sender, string s)
        {
            _messageProcessor.ProcessMessage(s, RobotState, Controllers);
        }
    }
}
