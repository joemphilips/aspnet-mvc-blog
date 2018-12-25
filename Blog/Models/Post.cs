using System;
using System.Collections.Generic;

namespace Blog.Models
{
  public class Post
  {
    public int Id { get; set; }
    public string Title { get; set; }

    public string ShortDescription { get; set; }
    public string Description { get; set; }

    public string Meta { get; set; }

    public string UrlSlug { get; set; }

    public bool Published { get; set; }

    public DateTime PostedOn { get; set; }

    public DateTime? Modified { get; set; }

    public Category Category { get; set; }

    public IList<PostTagMap> PostTagMaps { get; set; }


    # region DDD style update methods
    public void AddTag(string tagName, AppDbContext context = null)
    {
      if (context == null)
        throw new ArgumentNullException(nameof(context));

      if (PostTagMaps == null)
        throw new InvalidOperationException("Could not add a new tag");

      if (context.Entry(this).IsKeySet)
      {
        var tag = new Tag() { Name = tagName };
        context.Add(new PostTagMap() { Tag = tag, Post = this });
      }
      else
      {
        var tag = new Tag() { Name = tagName };
        context.Add(new PostTagMap() { Tag = tag, Post = this });
      }
    }

    #endregion
  }
}