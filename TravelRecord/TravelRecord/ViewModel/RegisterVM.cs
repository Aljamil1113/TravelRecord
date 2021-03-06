﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TravelRecord.Model;
using TravelRecord.ViewModel.Commands;

namespace TravelRecord.ViewModel
{
    public class RegisterVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private User user;
        public User User 
        { 
            get
            {
                return user;
            }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                User = new User
                {
                    Email = this.Email,
                    Password = this.Password,
                    ConfirmPassword = this.ConfirmPassword
                };
                OnPropertyChanged("Email");
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                User = new User
                {
                    Email = this.Email,
                    Password = this.Password,
                    ConfirmPassword = this.ConfirmPassword
                };
                OnPropertyChanged("Password");
            }
        }

        private string confirmPassword;
        public string ConfirmPassword 
        { 
            get { return confirmPassword; }
            set
            {
                confirmPassword = value;
                User = new User
                {
                    Email = this.Email,
                    Password = this.Password,
                    ConfirmPassword = this.ConfirmPassword
                };
                OnPropertyChanged("ConfirmPassword");
            }
        }

        public RegisterCommand RegisterCommand { get; set; }

        public RegisterVM()
        {
            User = new User();
            RegisterCommand = new RegisterCommand(this);
        }

        public async void Register()
        {
            if (User.Password == User.ConfirmPassword)
            {
                User.Register(User);
                await App.Current.MainPage.DisplayAlert("Successfull", "You successfully registered!", "Ok");
                await App.Current.MainPage.Navigation.PushAsync(new MainPage());
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Password doesn't match", "Ok");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
