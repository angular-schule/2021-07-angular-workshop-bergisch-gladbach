using ON.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schulung.core
{
  public static class Globals
  {
    public static readonly string Modul = "schulung";
    public static Config Config => ConfigurationManager.GetConfig(Modul);
    public static string ConnectionString => Config.GetConnectionString();
  }
}
