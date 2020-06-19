using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TravelRecord.ViewModel.Commands
{
    public class NavigationCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public HomeVM HomeViewModel { get; set; }

        public NavigationCommand(HomeVM homeVM)
        {
            HomeViewModel = homeVM;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            HomeViewModel.Navigate();
        }
    }
}
