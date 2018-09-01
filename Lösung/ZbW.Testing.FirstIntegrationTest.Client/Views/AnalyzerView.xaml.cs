namespace ZbW.Testing.FirstIntegrationTest.Client.Views
{
    using System.Windows.Controls;

    using ZbW.Testing.FirstIntegrationTest.Client.Providers;
    using ZbW.Testing.FirstIntegrationTest.Client.ViewModels;

    /// <summary>
    /// Interaction logic for AnalyzerView.xaml
    /// </summary>
    public partial class AnalyzerView : UserControl
    {
        public AnalyzerView()
        {
            DataContext = new AnalyzerViewModel(new IronOcrProvider());
            InitializeComponent();
        }
    }
}