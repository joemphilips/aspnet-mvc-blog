using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Extensions.Queryable
{
  public static class QueryablePostExtension
  {
    public static Task<List<Post>> TakeForPages(this DbSet<Post> queryable, int pageNo, int pageSize)
        => queryable
            .Where(p => p.Published)
            .OrderByDescending(p => p.PostedOn)
            .Skip(pageNo * pageSize)
            .Take(pageSize)
            .Include(p => p.Category)
            .ToListAsync();
    public static async Task<List<Post>> TakeForPagesFull(this DbSet<Post> queryable, int pageNo, int pageSize)
    {
      var posts = await TakeForPages(queryable, pageNo, pageSize);
      var postIds = posts.Select(p => p.Id).ToList();
      return await queryable
         .Where(p => postIds.Contains(p.Id))
         .OrderByDescending(p => p.PostedOn)
         .Include(p => p.PostTagMaps)
         .ThenInclude(p => p.Tag)
         .ToListAsync();
    }

    public static async Task<int> Total(this DbSet<Post> queryable)
      => await queryable.Where(p => p.Published).CountAsync();
  }
}