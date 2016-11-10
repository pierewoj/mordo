using System.Collections.Generic;

namespace Mordo.Desktop.Models
{
    public class Controller : Model
    {
        public List<decimal> PropReadings { get; }
        public List<decimal> IntegralReadings { get; }
        public List<decimal> DiffReadings { get; }

        private decimal _kp;
        public decimal Kp
        {
            get { return _kp; }
            set { _kp = value; OnPropertyChanged(); }
        }

        private decimal _ti;
        public decimal Ti
        {
            get { return _ti; }
            set { _ti = value; OnPropertyChanged(); }
        }

        private decimal _td;
        public decimal Td
        {
            get { return _td; }
            set { _td = value; OnPropertyChanged(); }
        }

        private bool _isDiffEnabled;
        public bool IsDiffEnabled
        {
            get { return _isDiffEnabled; }
            set { _isDiffEnabled = value; OnPropertyChanged(); }
        }

        private bool _isIntegralEnabled;
        public bool IsIntegralEnabled
        {
            get { return _isIntegralEnabled; }
            set { _isIntegralEnabled = value; OnPropertyChanged(); }
        }

        private bool _isPropEnabled;
        public bool IsPropEnabled
        {
            get { return _isPropEnabled; }
            set { _isPropEnabled = value; OnPropertyChanged(); }
        }

        private int _integralMax;
        public int IntegralMax
        {
            get { return _integralMax; }
            set { _integralMax = value; OnPropertyChanged(); }
        }

        private int _diffInterval;
        public int DiffInterval
        {
            get { return _diffInterval; }
            set { _diffInterval = value; OnPropertyChanged(); }
        }

        public string Name { get; }
        private readonly int _maxReadings;

        public Controller(string name, int maxReadings)
        {
            Name = name;
            _maxReadings = maxReadings;

            PropReadings = new List<decimal>();
            IntegralReadings = new List<decimal>();
            DiffReadings = new List<decimal>();
        }

        public void AddReadings(decimal prop, decimal integral, decimal diff)
        {
            AddReading(PropReadings, prop);
            AddReading(IntegralReadings, integral);
            AddReading(DiffReadings, diff);
        }

        private void AddReading<T>(IList<T> list, T value)
        {
            while (list.Count >= _maxReadings)
            {
                list.RemoveAt(0);
            }
            list.Add(value);
        }
    }
}
