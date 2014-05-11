using System;
using System.IO;
using System.Reflection;
using RoboCode.Runner.FrameworkExtensions;

namespace RoboCode.Runner
{
  class Program
  {
    static void Main(string[] args)
    {
      // TODO: Check if Roslyn could help here. Unfortunately the scripting APIs are currently not available:
      // http://roslyn.codeplex.com/wikipage?title=FAQ&referringTitle=Home#What happened to the REPL and hosting scripting APIs

      var rootPath = Configuration.Path;
      var libsPath = Path.Combine(rootPath, "libs");
      var assemblyPath = Path.Combine(libsPath, "robocode.control.dll");

      // Assembly
      var assembly =
        Assembly.LoadFrom(assemblyPath);

      // Types
      var robocodeEngineType =
        assembly.GetType("Robocode.Control.RobocodeEngine");

      var battlefieldSpecificationType =
        assembly.GetType("Robocode.Control.BattlefieldSpecification");

      var battleSpecificationType =
        assembly.GetType("Robocode.Control.BattleSpecification");

      // Events
      var battleMessageEvent =
        robocodeEngineType.GetEvent("BattleMessage");

      var battleErrorEvent =
        robocodeEngineType.GetEvent("BattleError");

      var battleCompletedEvent =
        robocodeEngineType.GetEvent("BattleCompleted");

      // Put all the things together
      dynamic robocodeEngine =
        Activator.CreateInstance(robocodeEngineType, rootPath);

      robocodeEngine.Visible = Configuration.GuiVisible;

      // Attach some event listener
      battleMessageEvent.AddEventHandler(
        robocodeEngine,
        battleMessageEvent.ConvertDelegate(
          new Action<dynamic>(x =>
          {
            var oldColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            Console.WriteLine(x.Message);

            Console.ForegroundColor = oldColor;
          })));

      battleErrorEvent.AddEventHandler(
        robocodeEngine,
        battleErrorEvent.ConvertDelegate(
          new Action<dynamic>(x =>
          {
            var oldColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("Error: {0}", x.Error);

            Console.ForegroundColor = oldColor;
          })));

      battleCompletedEvent.AddEventHandler(
        robocodeEngine,
        battleCompletedEvent.ConvertDelegate(new Action<dynamic>(x =>
        {
          Console.WriteLine();
          Console.WriteLine("--- Finished! ---");
          Console.WriteLine();

          foreach (var result in x.SortedResults)
          {
            Console.WriteLine("{0}: {1}", result.TeamLeaderName, result.Score);
          }
        })));

      var selectedRobots =
        robocodeEngine.GetLocalRepository(Configuration.Robots);

      var battlefieldSpecification =
        Activator.CreateInstance(
          battlefieldSpecificationType,
          Configuration.Width,
          Configuration.Height);

      var battleSpecification =
        Activator.CreateInstance(
          battleSpecificationType,
          Configuration.Rounds,
          battlefieldSpecification,
          selectedRobots);

      robocodeEngine.RunBattle(battleSpecification, true);

      robocodeEngine.Close();

      Console.WriteLine();
      Console.WriteLine("Press any key to continue...");
      Console.ReadLine();
    }
  }
}
