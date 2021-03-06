﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TravelRecord.Model;

namespace TravelRecord.ViewModel.Commands
{
    public class LoginCommand : ICommand
    {
        public MainVM mainVM { get; set; }

        public LoginCommand(MainVM ViewModel)
        {
            mainVM = ViewModel;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            var user = (User)parameter;

            if (user == null)
            {
                return false;
            }
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
                return false;
           
            return true;
        }

        public void Execute(object parameter)
        {
            mainVM.Login();
        }
    }
}
