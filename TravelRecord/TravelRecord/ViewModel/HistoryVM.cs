using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<bool> UpdatePosts()
        {
            try
            {
                Posts.Clear();
                var posts = Post.Read();
                foreach (var post in posts)
                {
                    Posts.Add(post);
                }

                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
        }

        public async void DeletePost(Post postToDelete)
        {
            await Post.DeletePost(postToDelete);
        }
    }
}
