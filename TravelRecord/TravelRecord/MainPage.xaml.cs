using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecord.Model;
using Xamarin.Forms;

namespace TravelRecord
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var assembly = typeof(MainPage);

            iconImage.Source = ImageSource.FromResource("TravelRecord.Assets.Images.plane.jpg", assembly);
        }

        private void Login_Clicked(object sender, EventArgs e)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(emailEntry.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(passwordEnrry.Text);

            if(isEmailEmpty || isPasswordEmpty == true)
            {
                DisplayAlert("Empty", "Email or Password are empty!", "Ok");
            }

            using(SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var userTable = conn.Table<User>();

                var user = userTable.Where(u => u.Email == emailEntry.Text && u.Password == passwordEnrry.Text).FirstOrDefault();

                if(user != null)
                {
                    App.user = user;
                    Navigation.PushAsync(new HomePage());
                }

                else
                {
                    DisplayAlert("Error", "Email or Password does not match!", "Ok");
                }
            }       
        }

        private void registerButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Register());
        }
    }
}
