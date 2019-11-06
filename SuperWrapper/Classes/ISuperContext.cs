using System.Windows.Input;

namespace SuperWrapper.Classes
{
    public interface ISuperContext
    {
        ICommand ClickCommand { get; set; }
        bool ContextSelected { get; set; }
    }
}