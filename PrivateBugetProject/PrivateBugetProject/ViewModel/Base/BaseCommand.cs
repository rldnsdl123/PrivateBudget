using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PrivateBugetProject
{
    public class BaseCommand : ICommand
    {
        Action mAction;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            mAction();
        }

        public BaseCommand(Action method)
        {
            mAction = method;
        }
    }
}
