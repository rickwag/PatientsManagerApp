using MaterialDesignThemes.Wpf;
using System.Windows;

namespace PatientsManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ShadowAssist.SetShadowDepth(this, ShadowDepth.Depth0);
        }
    }
}
