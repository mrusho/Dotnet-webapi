using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetapi.Models
{
  // Add in topics
  public class Thread
  {
    public int id { get; set; }
    public string subject { get; set; }
    public string content { get; set; }

    [Column("author_id")]
    public int UserId { get; set; }
    public User User { get; set; }
    public int replies { get; set; }
    [Column("abuse_status")]
    public int abuseStatus { get; set; }

    [Column("date_created")]
    public string dateCreated { get; set; }

    [Column("date_edited")]
    public string dateEdited { get; set; }
    public List<Post> Posts { get; set; }
  }

  // Add in posts
  public class Post
  {
    public int id { get; set; }

    [Column("thread_id")]
    public int ThreadId { get; set; }
    public Thread Thread { get; set; }

    [Column("category_id")]
    public int categoryId { get; set; }
    public string content { get; set; }

    [Column("author_id")]
    public int UserId { get; set; }
    public User User { get; set; }

    [Column("abuse_status")]
    public int abuseStatus { get; set; }

    [Column("date_created")]
    public string dateCreated { get; set; }

    [Column("date_edited")]
    public string dateEdited { get; set; }
  }
}