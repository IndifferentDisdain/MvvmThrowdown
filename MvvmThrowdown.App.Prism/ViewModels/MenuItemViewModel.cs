using System.Windows.Input;
using Prism.Windows.Mvvm;

namespace MvvmThrowdown.App.Prism.ViewModels
{
    public class MenuItemViewModel
    {
        public string DisplayName { get; set; }

        public string FontIcon { get; set; }

        public ICommand Command { get; set; }

        public override string ToString()
        {
            return DisplayName;
        }
    }
}
