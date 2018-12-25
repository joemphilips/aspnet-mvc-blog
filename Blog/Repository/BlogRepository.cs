using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repository
{
  public class BlogRepository : IBlogRepository
  {
    private AppDbContext _context;

    public BlogRepository(AppDbContext context)
    {
      _context = context;
    }
    public async Task<IList<Post>> Posts(int pageNo, int pageSize)
    {
      var posts = await _context
        .Post
        .Where(p => p.Published)
        .OrderByDescending(p => p.PostedOn)
        .Skip(pageNo * pageSize)
        .Take(pageSize)
        .Include(p => p.Category)
        .ToListAsync();

      var postIds = posts.Select(p => p.Id).ToList();

      return await _context.Post
        .Where(p => postIds.Contains(p.Id))
        .OrderByDescending(p => p.PostedOn)
        .Include(p => p.PostTagMaps)
        .ThenInclude(p => p.Tag)
        .ToListAsync();
    }

    public Task<int> TotalPosts() => _context.Post.Where(p => p.Published).CountAsync();
  }
}