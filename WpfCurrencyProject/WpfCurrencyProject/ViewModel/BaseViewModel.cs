using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfCurrencyProject.ViewModel
{
    public abstract class BaseViewModel : DependencyObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        protected virtual void RaisePropertyChangedEvent([CallerMemberName]string propertyName = null) 
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public class BasicCommand : ICommand
    {
        private Action commandAction;

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public BasicCommand(Action action)
        {
            commandAction = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            commandAction();
        }
    }
}
