namespace Mordo.Desktop.Models
{
    public class RobotState : Model
    {
        private int _positionX;

        public int PositionX
        {
            get { return _positionX; }
            set { _positionX = value;  OnPropertyChanged();}
        }

        public int PositionY { get; set; }
        public int Angle { get; set; }
    }
}
