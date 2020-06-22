using Plugin.Geolocator;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
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
	public partial class NewTravelPage : ContentPage
	{
		Post post;
		public NewTravelPage ()
		{
			InitializeComponent ();
			post = new Post();
			containerStack.BindingContext = post;
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
				var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Plugin.Permissions.Abstractions.Permission.Location);

				if(status != PermissionStatus.Granted)
                {
					if(await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    {
						await DisplayAlert("Need permission", "We will have to access your location", "Ok");
					}

					var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);

					if (results.ContainsKey(Permission.Location))
						status = results[Permission.Location];
				}

				if(status == PermissionStatus.Granted)
                {
					var locator = CrossGeolocator.Current;
					var position = await locator.GetPositionAsync();

					var venues = await Venue.GetVenues(position.Latitude, position.Longitude);

					venueListView.ItemsSource = venues;
				}

                else
                {
					await DisplayAlert("No permission", "You didn't granted permission to access you location", "Ok");
                }
				
			}
            catch (Exception)
            {
                throw;
            }          
        }
        private async void ToolbarItem_Clicked(object sender, EventArgs e)
		{
            try
            {
				var selectedVenue = venueListView.SelectedItem as Venue;
				var firstCategory = selectedVenue.categories.FirstOrDefault();



					post.CategoryId = firstCategory.id;
					post.CategoryName = firstCategory.name;
					post.Address = selectedVenue.location.address;
					post.Distance = selectedVenue.location.distance;
					post.Latitude = selectedVenue.location.lat;
					post.Longitude = selectedVenue.location.lng;
					post.VenueName = selectedVenue.name;
					post.UserId = App.user.Id;
				

			    Post.InsertPost(post);

				await DisplayAlert("Successfull", "Experience successfully created!", "Ok");

            }
            catch (NullReferenceException ne)
            {
				await DisplayAlert("Failure", "Experience failed to be inserted", "Ok");
			}
			catch (Exception)
            {
				await DisplayAlert("Failure", "Experience failed to be inserted", "Ok");
			}

		}
	}
}