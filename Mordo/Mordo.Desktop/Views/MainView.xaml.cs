using System.Windows;
using Mordo.Desktop.Initialize;
using Mordo.Desktop.ViewModels;
using Ninject;

namespace Mordo.Desktop.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            this.DataContext = Kernel.Default.Get<MainViewModel>();
            InitializeComponent();
        }
    }
}
