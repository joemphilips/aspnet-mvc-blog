using Microsoft.EntityFrameworkCore;

namespace Blog.Models
{
  public class AppDbContext : DbContext
  {
    public DbSet<Post> Post { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Tag> Tag { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Post>()
        .HasOne(p => p.Category)
        .WithMany(c => c.Posts);

      builder.Entity<Post>()
        .Property(p => p.Title)
        .HasMaxLength(500)
        .IsRequired();

      builder.Entity<Post>()
        .Property(p => p.ShortDescription)
        .HasMaxLength(5000)
        .IsRequired();

      builder.Entity<Post>()
        .Property(p => p.Description)
        .HasMaxLength(5000)
        .IsRequired();

      builder.Entity<Post>()
        .Property(p => p.Meta)
        .HasMaxLength(1000)
        .IsRequired();

      builder.Entity<Post>()
        .Property(p => p.UrlSlug)
        .HasMaxLength(50)
        .IsRequired();

      builder.Entity<Post>()
        .Property(p => p.Published)
        .IsRequired();

      builder.Entity<Category>()
        .Property(c => c.Name)
        .HasMaxLength(50)
        .IsRequired();


      builder.Entity<Category>()
        .Property(c => c.UrlSlug)
        .HasMaxLength(200)
        .IsRequired();

      builder.Entity<Category>()
        .Property(c => c.Description)
        .HasMaxLength(200);

      builder.Entity<Category>()
        .HasMany(c => c.Posts)
        .WithOne(p => p.Category);

      builder.Entity<Tag>()
        .Property(t => t.Name)
        .HasMaxLength(50)
        .IsRequired();

      builder.Entity<Tag>()
        .Property(t => t.UrlSlug)
        .HasMaxLength(200)
        .IsRequired();

      builder.Entity<Tag>()
        .Property(t => t.Description)
        .HasMaxLength(200)
        .IsRequired();

      builder.Entity<PostTagMap>()
        .HasKey(pt => new { pt.PostId, pt.TagId });

      builder.Entity<PostTagMap>()
        .HasOne(pt => pt.Post)
        .WithMany(p => p.PostTagMaps)
        .HasForeignKey(pt => pt.PostId);

      builder.Entity<PostTagMap>()
        .HasOne(pt => pt.Tag)
        .WithMany(t => t.PostTagMap)
        .HasForeignKey(pt => pt.TagId);
    }
  }
}