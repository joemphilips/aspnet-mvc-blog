using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Repository;

namespace Blog.Models.ViewModels
{
  public class BlogPostListViewModel
  {
    public BlogPostListViewModel(IList<Post> posts, int totalPosts)
    {
      Posts = posts;
      TotalPosts = totalPosts;
    }

    public IList<Post> Posts { get; }
    public int TotalPosts { get; }
  }
}