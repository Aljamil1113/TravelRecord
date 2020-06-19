using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecord.Model;
using TravelRecord.ViewModel.Commands;
using Xamarin.Forms;

namespace TravelRecord
{
    public partial class MainPage : ContentPage
    {

        MainVM mainVM;
        public MainPage()
        {
            InitializeComponent();

            var assembly = typeof(MainPage);

            mainVM = new MainVM();
            BindingContext = mainVM;
            iconImage.Source = ImageSource.FromResource("TravelRecord.Assets.Images.plane.jpg", assembly);
        }


        //private void Login_Clicked(object sender, EventArgs e)
        //{
        //    bool canLogIn = User.Login(emailEntry.Text, passwordEnrry.Text);

        //    if (canLogIn)
        //    {
        //        Navigation.PushAsync(new HomePage());
        //    }

        //    else
        //    {
        //        DisplayAlert("Error", "Email or Password does not match or not exist", "Ok");
        //    }
        //}

        private void registerButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Register());
        }
    }
}
