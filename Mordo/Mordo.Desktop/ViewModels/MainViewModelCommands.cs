using Mordo.Desktop.MessageProcessing;
using Mordo.Utils;
using System;

namespace Mordo.Desktop.ViewModels
{
    partial class MainViewModel
    {
        public RelayCommand ConnectCommand { get; set; }
        public RelayCommand DisconnectCommand { get; set; }
        public RelayCommand SendStartAutoCommand { get; set; }
        public RelayCommand SendStopAutoCommand { get; set; }
        public RelayCommand SendResetCommand { get; set; }
        public RelayCommand SendManualCommand { get; set; }
        public RelayCommand SendOpenFrameCommand { get; set; }
        public RelayCommand SendCloseFrameCommand { get; set; }
        public RelayCommand SendManualForwardCommand { get; set; }
        public RelayCommand SendManualRightCommand { get; set; }
        public RelayCommand SendManualBackwardCommand { get; set; }
        public RelayCommand SendManualLeftCommand { get; set; }
        public RelayCommand SendManualStopCommand { get; set; }
        public RelayCommand SendPidForwardCommand { get; set; }
        public RelayCommand SendPidBackWardCommand { get; set; }
        public RelayCommand SendPidWheelVelocityCommand { get; set; }
        public RelayCommand SendPidKtir { get; set; }
        public RelayCommand SendPwmCommand { get; set; }
        public RelayCommand SendStopFastCommand { get; set; }
        public RelayCommand SendStopSlowCommand { get; set; }
        public RelayCommand SendPidSettingsCommand { get; set; }

        public void RegisterCommands()
        {
            ConnectCommand = new RelayCommand(ExecuteConnectCommand, CanExecuteConnectCommand);
            DisconnectCommand = new RelayCommand(ExecuteDisconnectCommand, CanExecuteDisconnectCommand);
            SendStartAutoCommand = SendMessageCommand(b => b.StartAuto());
            SendStopAutoCommand = SendMessageCommand(b => b.StopAuto());
            SendResetCommand = SendMessageCommand(b => b.Reset());
            SendManualCommand = SendMessageCommand(b => b.Manual());
            SendOpenFrameCommand = SendMessageCommand(b => b.OpenFrame());
            SendCloseFrameCommand = SendMessageCommand(b => b.CloseFrame());
            SendManualForwardCommand = SendMessageCommand(b => b.ManualForward());
            SendManualRightCommand = SendMessageCommand(b => b.ManualRight());
            SendManualBackwardCommand = SendMessageCommand(b => b.ManualBackward());
            SendManualLeftCommand = SendMessageCommand(b => b.ManualLeft());
            SendManualStopCommand = SendMessageCommand(b => b.ManualStop());
            SendPidForwardCommand = SendMessageCommand(b => b.DrivePidForward(0));
            SendPidBackWardCommand = SendMessageCommand(b => b.DrivePidBackward(0));
            SendPidWheelVelocityCommand = SendMessageCommand(b => b.DriveConsantWheelVelocity(0, 0));
            SendPidKtir = SendMessageCommand(b => b.SideKtir());
            SendPwmCommand = SendMessageCommand(b => b.Pwm(0, 0));
            SendStopFastCommand = SendMessageCommand(b => b.StopFast());
            SendStopSlowCommand = SendMessageCommand(b => b.StopSlow());
            SendPidSettingsCommand = SendMessageCommand(b => b.SetSettings());
        }

        public RelayCommand SendMessageCommand(Func<IMessageBuilder, string> func)
        {
            return new RelayCommand(
                o =>
                {
                    var msg = func(_messageBuilder);
                    _communicator.SendMessage(msg);
                },
                o => _communicator.IsConnected);
        }

        private bool CanExecuteDisconnectCommand(object o)
        {
            return _communicator.IsConnected;
        }

        private void ExecuteDisconnectCommand(object o)
        {
            _communicator.Disconnect();
        }

        private bool CanExecuteConnectCommand(object o)
        {
            return !_communicator.IsConnected;
        }

        private void ExecuteConnectCommand(object o)
        {
            _communicator.Connect(0, "");
        }
    }
}
