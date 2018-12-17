namespace Blog.Models
{
  public class AppDbContext : DbContext
  {
    public DbSet<Post> Post { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Tag> Tag { get; set; }
  }
}