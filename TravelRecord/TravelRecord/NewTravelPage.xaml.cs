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
		public NewTravelPage ()
		{
			InitializeComponent ();
		}

		private void ToolbarItem_Clicked(object sender, EventArgs e)
		{
			Post post = new Post()
			{
				Experience = ExperienceEntry.Text
			};

			using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
			{
				conn.CreateTable<Post>();
				int rows = conn.Insert(post);

				if (rows > 0)
					DisplayAlert("Success", "Experience successfully inserted", "Ok");
				else
					DisplayAlert("Failure", "Experience failed to be inserted", "Ok");
			}
				
		}
	}
}