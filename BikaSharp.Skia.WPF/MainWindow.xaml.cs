
namespace BikaSharp.WPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : System.Windows.Window
    {
		public MainWindow()
		{
			InitializeComponent();

			root.Content = new global::Uno.UI.Skia.Platform.WpfHost(Dispatcher, () => new BikaSharp.App());
		}
	}
}
