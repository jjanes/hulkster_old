using Microsoft.EntityFrameworkCore;


public class BotContext : DbContext
{
  public DbSet<Bot> Bots { get; set; }

  public string DbPath { get; }

  public BotContext()
  {
    var folder = Environment.SpecialFolder.LocalApplicationData;
    var path = Environment.GetFolderPath(folder);
    DbPath = System.IO.Path.Join(path, "blogging.db");
    Console.WriteLine(DbPath.ToString());
  }

  // The following configures EF to create a Sqlite database file in the
  // special "local" folder for your platform.
  protected override void OnConfiguring(DbContextOptionsBuilder options)
      => options.UseSqlite($"Data Source={DbPath}");
}


public class Bot
{
  public int BotId { get; set; }
  public string Name { get; set; }
  public string ApiKey { get; set; }

}





