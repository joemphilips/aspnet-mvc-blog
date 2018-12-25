using System.Threading.Tasks;
using Blog.Extensions.Queryable;
using Blog.Models;
using Blog.Models.ViewModels;
using Blog.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
  public class BlogController : Controller
  {
    private readonly AppDbContext _context;

    BlogController(AppDbContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Posts(int p = 1)
    {
      var posts = await _context.Post.TakeForPagesFull(p, 10);
      var totalPosts = await _context.Post.Total();
      var listViewModel = new BlogPostListViewModel(posts, totalPosts);
      return View("List", listViewModel);
    }
  }
}