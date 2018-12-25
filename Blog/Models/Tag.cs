using System.Collections.Generic;

namespace Blog.Models
{
  public class Tag
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string UrlSlug { get; set; }
    public string Description { get; set; }

    public IList<PostTagMap> PostTagMap { get; set; }
  }
}