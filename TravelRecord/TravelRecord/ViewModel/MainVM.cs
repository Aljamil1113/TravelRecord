using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TravelRecord.Model;

namespace TravelRecord.ViewModel.Commands
{
    public class MainVM : INotifyPropertyChanged
    {
        public LoginCommand loginCommand { get; set; }

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
                user = new User
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
                user = new User
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
            loginCommand = new LoginCommand(this);
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public async void Login()
        {
            bool canLogIn =  User.Login(user.Email, user.Password);

            if (canLogIn)
            {
                await App.Current.MainPage.Navigation.PushAsync(new HomePage());
            }

            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Email or Password does not match or not exist", "Ok");
            }
        }
    }
}
