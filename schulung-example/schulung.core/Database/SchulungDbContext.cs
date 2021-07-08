using ON.Data.EF;
using schulung.core;
using Schulung.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schulung.Core.Database
{
  public class SchulungDbContext : AOnDbContext
  {
    public DbSet<BookContainer> Books { get; set; }
    public DbSet<AuthorContainer> Authors { get; set; }

    public SchulungDbContext() : base(Globals.ConnectionString) { }

    public SchulungDbContext(string connectionString) : base(connectionString)
    {
      Configuration.ProxyCreationEnabled = false;
    }
    protected override DateTime Now => DateTime.UtcNow;
    public static SchulungDbContext Create()
    {
      var context = new SchulungDbContext();

#if DEBUG
      context.Database.Log = (s) => Debug.WriteLine(s);
#endif
      return context;
    }
  }
}
