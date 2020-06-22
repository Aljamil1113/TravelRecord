using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecord.Model;
using TravelRecord.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecord
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HistoryPage : ContentPage
	{
		HistoryVM viewModel;
		public HistoryPage ()
		{
			InitializeComponent ();

			viewModel = new HistoryVM();
			BindingContext = viewModel;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			viewModel.UpdatePosts();
		}

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
			var post = (Post)((MenuItem)sender).CommandParameter;
		    viewModel.DeletePost(post);

			await viewModel.UpdatePosts();
        }

        private async void postListView_Refreshing(object sender, EventArgs e)
        {
			await viewModel.UpdatePosts();
			postListView.IsRefreshing = false;
        }
    }
}