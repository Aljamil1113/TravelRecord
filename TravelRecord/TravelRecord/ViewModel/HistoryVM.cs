using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TravelRecord.Model;

namespace TravelRecord.ViewModel
{
    public class HistoryVM
    {
        public ObservableCollection<Post> Posts { get; set; }

        public HistoryVM()
        {
            Posts = new ObservableCollection<Post>();
        }

        public void UpdatePosts()
        {
            Posts.Clear();
            var posts = Post.Read();
            foreach (var post in posts)
            {
                Posts.Add(post);
            }
        }
    }
}
