using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecord.Model;
using TravelRecord.ViewModel;
using Xamarin.Forms;

namespace TravelRecord
{
    public partial class MainPage : ContentPage
    {

        MainVM mainVM;
        public MainPage()
        {
            InitializeComponent();

            mainVM = new MainVM();
            BindingContext = mainVM;

            var assembly = typeof(MainPage);
            iconImage.Source = ImageSource.FromResource("TravelRecord.Assets.Images.plane.jpg", assembly);
        }
    }
}
