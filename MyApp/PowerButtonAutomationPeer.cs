using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;

using MyApp.Annotations;

namespace MyApp
{
  public class PowerButtonAutomationPeer : UserControlAutomationPeer, IToggleProvider
  {
    private readonly PowerButton _owner;

    public PowerButtonAutomationPeer([NotNull] PowerButton owner)
      : base(owner)
    {
      _owner = owner;
    }

    public void Toggle()
    {
      _owner.IsChecked = !_owner.IsChecked;
    }

    public ToggleState ToggleState
    {
      get
      {
        return _owner.IsChecked ? ToggleState.On : ToggleState.Off;
      }
    }

    protected override string GetClassNameCore()
    {
      return "PowerButton";
    }

    protected override AutomationControlType GetAutomationControlTypeCore()
    {
      return AutomationControlType.Custom;
    }

    public override object GetPattern(PatternInterface patternInterface)
    {
      if (patternInterface == PatternInterface.Toggle)
      {
        return this;
      }

      return base.GetPattern(patternInterface);
    }
  }
}