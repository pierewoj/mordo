namespace Mordo.Desktop.Models
{
    public class CommandSettings : Model
    {
        private int _pidForward;
        public int PidForward
        {
            get { return _pidForward; }
            set { _pidForward = value; OnPropertyChanged(); }
        }

        private int _pidBackward;
        public int PidBackward
        {
            get { return _pidBackward; }
            set { _pidBackward = value; OnPropertyChanged(); }
        }

        private int _velocityLeft;
        public int VelocityLeft
        {
            get { return _velocityLeft; }
            set { _velocityLeft = value; OnPropertyChanged(); }
        }

        private int _velocityRight;
        public int VelocityRight
        {
            get { return _velocityRight; }
            set { _velocityRight = value; OnPropertyChanged(); }
        }

        private int _pwmL;
        public int PwmL
        {
            get { return _pwmL; }
            set { _pwmL = value; OnPropertyChanged(); }
        }

        private int _pwmR;
        public int PwmR
        {
            get { return _pwmR; }
            set { _pwmR = value; OnPropertyChanged(); }
        }
    }
}
