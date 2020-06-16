using Newtonsoft.Json.Serialization;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecord.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecord
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
        }

        private void buttonRegister_Clicked(object sender, EventArgs e)
        {
            if(passwordEntry.Text == confirmPassword.Text)
            {

                User user = new User()
                {
                    Email = emailEntry.Text,
                    Password = passwordEntry.Text
                };

                using(SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<User>();
                    int rows = conn.Insert(user);

                    if (rows > 0)
                        DisplayAlert("Success", "You are successfully registered", "Ok");
                    else
                        DisplayAlert("Failure", "You are failed to register", "Ok");
                }

            }
            else
            {
                DisplayAlert("Error", "Password doesn't match", "Ok");
            }
        }
    }
}