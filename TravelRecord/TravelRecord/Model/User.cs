using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace TravelRecord.Model
{
    public class User : INotifyPropertyChanged
    {
        private int id;
        public int Id {
            get { return id; }
            set 
            { 
                id = value; 
                OnPropertyChanged("Id"); 
            } 
            
        }

        private string email;
        public string Email {
            get { return email; }
            set 
            {
                email = value;
                OnPropertyChanged("Email");
            } 
        }

        private string password;
        public string Password 
        {
            get { return password;  }
            set { password = value; OnPropertyChanged("Password");  } 
        }

        private string confirmPassword;
        public string ConfirmPassword 
        {
            get 
            { 
                return confirmPassword; 
            }
            set
            {
                confirmPassword = value;
                OnPropertyChanged("ConfirmPassword");
            } 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public static bool Login(string email, string password)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(email);
            bool isPasswordEmpty = string.IsNullOrEmpty(password);

            if(isEmailEmpty || isPasswordEmpty == true)
            {
                return false;
            }   

            using(SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var userTable = conn.Table<User>();

                var user =  userTable.Where(u => u.Email == email && u.Password == password).FirstOrDefault();

                if(user != null)
                {
                    App.user = user;
                    return true;
                }

                else
                {
                    return false;
                }       
            }
          }

          public static void Register(User user)
          {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<User>();
                conn.Insert(user);
            }
        }
     }
}
