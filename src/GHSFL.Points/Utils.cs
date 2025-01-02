using System.Data;
using System.Text.Json;

namespace GHSFL.Points;

public static class Utils
{
    public static async Task<T> GetData<T>(HttpClient http, string path)
    {
        try
        {
            var rawJson = await http.GetStringAsync(path);
            var info = JsonSerializer.Deserialize<T>(rawJson);
            if (info is null)
            {
                throw new DataException($"Could not parse {path}");
            }

            return info;
        }
        catch (HttpRequestException)
        {
            throw new DataException($"Could not find {path}");
        }  
    }
}