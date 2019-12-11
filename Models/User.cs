using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetapi.Models
{
  public class User
  {
    public int id { get; set; }
    public string email { get; set; }

    [Column("first_name")]
    public string firstName { get; set; }

    [Column("last_name")]
    public string lastName { get; set; }

    public List<Thread> Threads { get; set; }

    public List<Post> Posts { get; set; }
  }
}