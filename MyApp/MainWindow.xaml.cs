
namespace MyApp
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow
  {
    public MainWindow()
    {
      InitializeComponent();
      ViewModel = new MainViewModel();
    }

    public MainViewModel ViewModel
    {
      get
      {
        return DataContext as MainViewModel;
      }

      set
      {
        DataContext = value;
      }
    }
  }
}
