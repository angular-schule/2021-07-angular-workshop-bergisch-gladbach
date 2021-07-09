using ON.Tools.ClientGenerator.Angular;
using ON.Tools.TMGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schulung.Tooling
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("1) Generate Transport Models");
      Console.WriteLine("2) Generate TypeScript");
      var key = Console.ReadKey(false);
      Console.WriteLine();

      switch (key.Key)
      {
        case ConsoleKey.D1:
          GenerateServer();
          break;
        case ConsoleKey.D2:
          GenerateClient(@"..\..\..\Schulung.Client\src\app\generated", "http://schulung.local.oevermann.local/generator/angular");
          break;
      }
    }

    private static void GenerateClient(string directoryPath, string url)
    {
      AngularGenerator.GenerateClient(directoryPath, url, new AngularGeneratorOptions { AngularVersion = 12, UseDateObjectInForm = true });
    }

    private static void GenerateServer()
    {
      var tmPath = @"..\..\..\Schulung.Server\TMModels.cs";
      if (!ON.IO.GeneratorHelper.CheckWriteable(tmPath))
      {
        ON.IO.GeneratorHelper.CheckOut(tmPath);
      }
      var gen = new Generator()
        .AddDefaultUsings()
        .AddUsing("Schulung.Core")
        .AddUsing("Schulung.Core.Database")
        .AddUsing("Schulung.Server.TransportModels")
        .AddUsing("ON.Data.EF")
        .AddUsing("ON.Data.Common")
        .WithGlobalIdProperty<int>("Id");
      gen.UseDataclassForLoading = true;
      gen.WriteUsings();

      var classDefinitions = ClassDefinition.GetClassDefinitionsFromAssembly();
      gen.Write(classDefinitions, "Schulung.Server");
      ON.IO.GeneratorHelper.WriteToFile(tmPath, gen.ToString());

      new Generator()
      .WriteTransportModels<int>(classDefinitions, "Id", "Schulung.Server", @"..\..\..\Schulung.Server\TransportModels\Generated\{0}.cs");
    }
  }
}
