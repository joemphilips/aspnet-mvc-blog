using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Models;

namespace Blog.Repository
{
  public interface IBlogRepository
  {
    Task<IList<Post>> Posts(int pageNo, int pageSize);

    Task<int> TotalPosts();
  }
}