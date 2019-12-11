using Microsoft.EntityFrameworkCore;
using dotnetapi.Models;

namespace dotnetapi.Data
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(){}
    public AppDbContext(DbContextOptions<AppDbContext> options)
      : base (options)
    {}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      optionsBuilder.UseMySQL("server=localhost;port=3306;userid=default;password=secret;database=default;");
    }

    public DbSet<User> users { get; set; }
    public DbSet<Thread> discussion_threads { get; set; }
    public DbSet<Post> discussion_posts { get; set; }
  }
}