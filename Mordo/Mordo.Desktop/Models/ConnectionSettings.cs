namespace Mordo.Desktop.Models
{
    public class ConnectionSettings : Model
    {
        private int _baudRate;
        private string _port;

        public int BaudRate
        {
            get { return _baudRate; }
            set { _baudRate = value; OnPropertyChanged(); }
        }

        public string Port
        {
            get { return _port; }
            set { _port = value; OnPropertyChanged(); }
        }
    }
}
