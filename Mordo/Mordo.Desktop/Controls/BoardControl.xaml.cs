using Mordo.Desktop.Models;
using System.Windows;
using System.Windows.Controls;

namespace Mordo.Desktop.Controls
{
    /// <summary>
    /// Interaction logic for BoardControl.xaml
    /// </summary>
    public partial class BoardControl : UserControl
    {
        public RobotState RobotState
        {
            get { return (RobotState)GetValue(RobotStateProperty); }
            set { SetValue(RobotStateProperty, value); }
        }

        public static readonly DependencyProperty RobotStateProperty =
            DependencyProperty.Register("RobotState", typeof(RobotState),
              typeof(BoardControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public BoardControl()
        {
            InitializeComponent();
            Root.DataContext = this;
        }
    }
}
