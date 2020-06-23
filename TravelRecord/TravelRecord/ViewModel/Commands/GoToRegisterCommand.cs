using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TravelRecord.ViewModel.Commands
{
    public class GoToRegisterCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public MainVM ViewModel;

        public GoToRegisterCommand(MainVM viewModel)
        {
            ViewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ViewModel.NavigateToRegister();
        }
    }
}
