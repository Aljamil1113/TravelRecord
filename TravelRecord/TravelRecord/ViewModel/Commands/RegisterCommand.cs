using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TravelRecord.Model;

namespace TravelRecord.ViewModel.Commands
{
    public class RegisterCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public RegisterVM RegisterVM { get; set; }

        public RegisterCommand(RegisterVM registerVM)
        {
            RegisterVM = registerVM;
        }

        public bool CanExecute(object parameter)
        {
            var user = (User)parameter;
            if(user != null)
            {
                if(!string.IsNullOrEmpty(user.Email) && !string.IsNullOrEmpty(user.Password) && !string.IsNullOrEmpty(user.ConfirmPassword))
                {
                    if(user.Password == user.ConfirmPassword)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            RegisterVM.Register();
        }
    }
}
