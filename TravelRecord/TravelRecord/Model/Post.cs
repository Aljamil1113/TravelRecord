using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelRecord.Model
{
    public class Post : INotifyPropertyChanged
    {
        private int id;
        public int Id {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            } 
        }

        private string experience;
        public string Experience { 
            get { 
                return experience;  
            }
            set { experience = value; 
                OnPropertyChanged("Experience"); 
            }

        }

        private string venueName;
        public string VenueName 
        {
            get { 
                return venueName;  
            }
            set { 
                venueName = value; 
                OnPropertyChanged("VenueName"); 
            }
        }

        private string categoryId;
        public string CategoryId 
        { 
            get
            {
                return categoryId;
            }
            set
            {
                categoryId = value;
                OnPropertyChanged("CategoryId");
            }
        }

        private string categoryName;
        public string CategoryName 
        {
            get
            {
                return categoryName;
            }
            set
            {
                categoryName = value;
                OnPropertyChanged("CategoryName");
            }
        }

        private string address;
        public string Address 
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
                OnPropertyChanged("Address");
            } 
        }

        private double latitude;
        public double Latitude 
        {
            get
            {
                return latitude;
            }
            set
            {
                latitude = value;
                OnPropertyChanged("Latitude");
            }
        }

        private double longitude;
        public double Longitude 
        {
            get
            {
                return longitude;
            }
            set
            {
                longitude = value;
                OnPropertyChanged("Longitude");
            }
        }

        private int distance;
        public int Distance 
        {
            get 
            {
                return distance;
            }
            set
            {
                distance = value;
                OnPropertyChanged("Distance");
            } 
        }

        private int userId;
        public int UserId 
        {
            get 
            {
                return userId;
            }
            set
            {
                userId = value;
                OnPropertyChanged("UserId");
            } 
        }

        private DateTimeOffset createdat;
        public DateTimeOffset CREATEDAT 
        {
            get
            {
                return createdat;
            }
            set
            {
                createdat = value;
                OnPropertyChanged("CREATEDAT");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static void InsertPost(Post post)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                conn.Insert(post);
            }
        }

        public static async Task<bool> DeletePost(Post post)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<Post>();
                    conn.Delete(post);                 
                }
                return true;
            }
            catch(Exception)
            {
                return false;
            }
           
        }

        public static List<Post> Read()
        {
            var posts = new List<Post>(); ;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                var post = conn.Table<Post>().Where(p => p.UserId == App.user.Id).ToList();

                posts.AddRange(post);
            }

            return posts;
        }

        public static Dictionary<string, int> PostCategories(List<Post> posts)
        {
           
                //var categories = (from p in postTable
                //				  orderby p.CategoryId
                //				  select p.CategoryName).Distinct().ToList();

                var categories = posts.OrderBy(p => p.CategoryId).Select(p => p.CategoryName).Distinct().ToList();

                Dictionary<string, int> categoriesCount = new Dictionary<string, int>();

                foreach (var category in categories)
                {
                    //var countCategory = (from post in postTable
                    //					 where post.CategoryName == category
                    //					 select post).ToList().Count;

                    var countCategory = posts.Where(p => p.CategoryName == category).ToList().Count;

                    categoriesCount.Add(category, countCategory);
                }

                return categoriesCount;
            }
        
        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }

    }
