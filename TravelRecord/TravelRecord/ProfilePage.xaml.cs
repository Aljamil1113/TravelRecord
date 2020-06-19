using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TravelRecord.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecord
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProfilePage : ContentPage
	{
		public ProfilePage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

			using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
				var postTable = Post.Read();

				var categoriesCount = Post.PostCategories(postTable);

				categoriesListView.ItemsSource = categoriesCount;

				postCountLabel.Text = postTable.Count.ToString();
            }
        }
    }
}