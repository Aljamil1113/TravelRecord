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
				var postTable = conn.Table<Post>().Where(p => p.UserId == App.user.Id).ToList();

				//var categories = (from p in postTable
				//				  orderby p.CategoryId
				//				  select p.CategoryName).Distinct().ToList();

				var categories = postTable.OrderBy(p => p.CategoryId).Select(p => p.CategoryName).Distinct().ToList();

				Dictionary<string, int> categoriesCount = new Dictionary<string, int>();

                foreach (var category in categories)
                {
					//var countCategory = (from post in postTable
					//					 where post.CategoryName == category
					//					 select post).ToList().Count;

					var countCategory = postTable.Where(p => p.CategoryName == category).ToList().Count;

					categoriesCount.Add(category, countCategory);
                }

				categoriesListView.ItemsSource = categoriesCount;

				postCountLabel.Text = postTable.Count.ToString();
            }
        }
    }
}