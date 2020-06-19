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
        User user;
        public Register()
        {
            InitializeComponent();
            user = new User();
            containerStackLayout.BindingContext = user;
        }

        private void buttonRegister_Clicked(object sender, EventArgs e)
        {
            if(passwordEntry.Text == confirmPassword.Text)
            {
               User.Register(user);
               DisplayAlert("Successfull", "You successfully registered!", "Ok");
            }
            else
            {
                DisplayAlert("Error", "Password doesn't match", "Ok");
            }
        }
    }
}