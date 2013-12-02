using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace MyApp
{
  /// <summary>
  /// Interaction logic for PowerButton.xaml
  /// </summary>
  public partial class PowerButton
  {
    /// <summary>
    /// The IsChecked dependency property
    /// </summary>
    public static readonly DependencyProperty IsCheckedProperty = DependencyProperty.Register(
      "IsChecked", typeof(bool), typeof(PowerButton), new PropertyMetadata(false, IsCheckedChangedHandler));

    private static void IsCheckedChangedHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      var powerCheckBox = d as PowerButton;
      if (powerCheckBox == null)
      {
        return;
      }

      powerCheckBox.UpdateIconColor();
    }

    /// <summary>
    /// Gets or sets a value indicating if power is on or off.
    /// </summary>
    public bool IsChecked
    {
      get
      {
        return (bool)GetValue(IsCheckedProperty);
      }

      set
      {
        SetValue(IsCheckedProperty, value);
      }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PowerButton"/> class.
    /// </summary>
    public PowerButton()
    {
      InitializeComponent();
      UpdateIconColor();
    }

    private void UpdateIconColor()
    {
      _icon.Fill = IsChecked ? Brushes.DarkOliveGreen : Brushes.DarkRed;
    }

    private void MouseClickHandler(object sender, MouseButtonEventArgs e)
    {
      IsChecked = !IsChecked;
    }

    protected override System.Windows.Automation.Peers.AutomationPeer OnCreateAutomationPeer()
    {
      return new PowerButtonAutomationPeer(this);
    }
  }
}
