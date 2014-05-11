using System.Collections.Specialized;
using System.Configuration;

namespace RoboCode.Runner
{
  public class Configuration
  {
    private static readonly NameValueCollection _settings;

    static Configuration()
    {
      _settings = ConfigurationManager.AppSettings;
    }

    public static string Path
    {
      get
      {
        return _settings["robocode:path"];
      }
    }

    public static int Rounds
    {
      get
      {
        int rounds;
        if (!int.TryParse(_settings["robocode:rounds"], out rounds))
        {
          rounds = 10;
        }

        return rounds;
      }
    }

    public static bool GuiVisible
    {
      get
      {
        bool guiVisible;
        if (!bool.TryParse(_settings["robocode:gui"], out guiVisible))
        {
          guiVisible = false;
        }

        return guiVisible;
      }
    }

    public static int Width
    {
      get
      {
        int width;
        if (!int.TryParse(_settings["robocode:width"], out width))
        {
          width = 800;
        }

        return width;
      }
    }

    public static int Height
    {
      get
      {
        int height;
        if (!int.TryParse(_settings["robocode:height"], out height))
        {
          height = 600;
        }

        return height;
      }
    }

    public static string Robots
    {
      get
      {
        return _settings["robocode:robots"];
      }
    }
  }
}
