using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

using MyApp.Annotations;
using MyApp.Common;

namespace MyApp
{
  public class MainViewModel : INotifyPropertyChanged
  {
    private int _counter;

    public int Counter
    {
      get
      {
        return _counter;
      }

      set
      {
        if (_counter != value)
        {
          _counter = value;
          OnPropertyChanged();
        }
      }
    }

    private bool _isEnabled;

    public bool IsEnabled
    {
      get
      {
        return _isEnabled;
      }

      set
      {
        if (_isEnabled != value)
        {
          _isEnabled = value;
          OnPropertyChanged();
          _increaseCommand.RaiseCanExecuteChanged();
        }
      }
    }

    private readonly DelegateCommand _increaseCommand;

    public ICommand IncreaseCommand
    {
      get
      {
        return _increaseCommand;
      }
    }

    public MainViewModel()
    {
      _increaseCommand = new DelegateCommand(() => Counter++, () => IsEnabled);
      IsEnabled = true;
    }

    #region    PropertyChanged

    public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChangedEventHandler handler = PropertyChanged;
      if (handler != null)
      {
        handler(this, new PropertyChangedEventArgs(propertyName));
      }
    }

    #endregion PropertyChanged
  }
}