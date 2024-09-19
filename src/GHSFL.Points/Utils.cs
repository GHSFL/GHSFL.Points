using System.Data;
using System.Net;
using System.Text.Json;
using GHSFL.Points.Models;

namespace GHSFL.Points;

public class Utils
{
    public static async Task<SeasonInfo> GetPointsFromFile(HttpClient http)
    {
        try
        {
            var rawJson = await http.GetStringAsync("sample-data/info.json");
            var info = JsonSerializer.Deserialize<SeasonInfo>(rawJson);

            if (info is null)
            {
                throw new DataException("Could not parse info.json");
            }

            return info;
        }
        catch (HttpRequestException)
        {
            throw new DataException("Could not find info.json");
        }    
    }
}