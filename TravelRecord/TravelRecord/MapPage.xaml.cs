using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecord
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
		public MapPage ()
		{
			InitializeComponent();
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();

			var locator = CrossGeolocator.Current;
			locator.PositionChanged += Locator_PositionChanged;
			await locator.StartListeningAsync(TimeSpan.Zero, 100, true);

			var position = await locator.GetPositionAsync();

			var center = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);
			var span = new Xamarin.Forms.Maps.MapSpan(center, 2, 2);

			locationsMap.MoveToRegion(span);
        }

        private void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
			var center = new Xamarin.Forms.Maps.Position(e.Position.Latitude, e.Position.Longitude);
			var span = new Xamarin.Forms.Maps.MapSpan(center, 2, 2);
			locationsMap.MoveToRegion(span);
		}
    }
}