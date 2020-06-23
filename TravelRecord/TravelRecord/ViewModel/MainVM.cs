using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TravelRecord.Model;
using TravelRecord.ViewModel.Commands;

namespace TravelRecord.ViewModel
{
    public class MainVM : INotifyPropertyChanged
    {
        public LoginCommand LoginCommand { get; set; }

        public GoToRegisterCommand ToRegister { get; set; }

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
                    Password = this.Password
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
                    Password = this.Password
                };
                OnPropertyChanged("Password");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainVM()
        {
            User = new User();
            LoginCommand = new LoginCommand(this);
            ToRegister = new GoToRegisterCommand(this);
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public async void Login()
        {
            bool canLogIn =  User.Login(User.Email, User.Password);

            if (canLogIn)
            {
                await App.Current.MainPage.Navigation.PushAsync(new HomePage());
            }

            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Email or Password does not match or not exist", "Ok");
            }
        }

        public async void NavigateToRegister()
        {
            await App.Current.MainPage.Navigation.PushAsync(new Register());
        }
    }
}
