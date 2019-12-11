using System.Collections.Generic;
using System.Linq;
using GraphQL;
using Microsoft.EntityFrameworkCore;
using dotnetapi.Models;

namespace dotnetapi.Data
{
  public class Query
  {
    [GraphQLMetadata("threads")]
    public IEnumerable<Thread> GetThreads()
    {
      using(var db = new AppDbContext())
      {
        return db.discussion_threads
          .Include(t => t.Posts)
            .ThenInclude(t => t.User)
          .ToList();
      }
    }

    [GraphQLMetadata("thread")]
    public Thread GetThread(int id)
    {
      using(var db = new AppDbContext())
      {
        return db.discussion_threads
          .Include(t => t.Posts)
            .ThenInclude(t => t.User)
          .Include(t => t.User)
          .SingleOrDefault(t => t.id == id);
      }
    }

    [GraphQLMetadata("posts")]
    public IEnumerable<Post> GetPosts()
    {
      using(var db = new AppDbContext())
      {
        return db.discussion_posts
          .Include(p => p.Thread)
            .ThenInclude(p => p.User)
          .ToList();
      }
    }

    [GraphQLMetadata("post")]
    public Post GetPost(int id)
    {
      using(var db = new AppDbContext())
      {
        return db.discussion_posts
          .Include(p => p.Thread)
            .ThenInclude(p => p.User)
          .Include(p => p.User)
          .SingleOrDefault(p => p.id == id);
      }
    }
  }
}