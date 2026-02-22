namespace Utilities;
using System;
using System.Text.Json;

internal static class ConfigurationUtility
{
    public static async Task<string> GetAdminSecretKeyAsync()
    {
        string jsonPath = "C:\\Users\\aksha\\Downloads\\Project-Connection\\DatabaseConnection\\Utilities\\ConfigurationKeys.json";
        if (!File.Exists(jsonPath)) throw new FileNotFoundException("Config file missing!");

        using var stream = File.OpenRead(jsonPath);
        var config = await JsonSerializer.DeserializeAsync<JsonElement>(stream);
        
        // Navigates: AdminConfig -> ActualKey
        return config.GetProperty("AdminConfig").GetProperty("ActualKey").GetString();
    }
}