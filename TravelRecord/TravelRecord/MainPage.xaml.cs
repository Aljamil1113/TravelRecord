using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TravelRecord
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Login_Clicked(object sender, EventArgs e)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(emailEntry.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(passwordEnrry.Text);

            if(isEmailEmpty || isPasswordEmpty == true)
            {

            }

            else
            {
                Navigation.PushAsync(new HomePage());
            }
        }
    }
}
