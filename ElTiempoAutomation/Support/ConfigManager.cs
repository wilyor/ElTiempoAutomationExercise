using Newtonsoft.Json.Linq;
using System.IO;

public static class ConfigManager
{
    private static JObject _config;

    static ConfigManager()
    {
        var configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "specflow.json");
        _config = JObject.Parse(File.ReadAllText(configPath));
    }

    public static string GetDefaultBrowser()
    {
        return _config["drivers"]?["defaultBrowser"]?.ToString() ?? "chrome";
    }

    public static string? GetUrl()
    {
        return _config["DefaultUrl"]?.ToString();
    }

}
