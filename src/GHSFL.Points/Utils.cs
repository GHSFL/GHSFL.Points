using System.Data;
using System.Text.Json;
using GHSFL.Points.Models;
using Exception = System.Exception;

namespace GHSFL.Points;

public static class Utils
{
    /// <summary>
    /// Gets data from the info file.
    /// </summary>
    /// <param name="http">HttpClient to use.</param>
    /// <returns>The season info object used to populate the table.</returns>
    /// <exception cref="DataException">If we ran into any issues getting the data.</exception>
    public static async Task<SeasonInfo> GetFencerDataFromFile(HttpClient http)
    {
        try
        {
            var rawJson = await http.GetStringAsync("sample-data/fencer-info.json");
            var info = JsonSerializer.Deserialize<SeasonInfo>(rawJson);

            if (info is null)
            {
                throw new DataException("Could not parse fencer-info.json");
            }

            return info;
        }
        catch (HttpRequestException)
        {
            throw new DataException("Could not find fencer-info.json");
        }    
    }

    public static async Task<Dictionary<long, PoolsForFencer>> GetPoolDataFromFile(HttpClient http)
    {
        try
        {
            var rawJson = await http.GetStringAsync("sample-data/pools-info.json");
            var info = JsonSerializer.Deserialize<Dictionary<long, PoolsForFencer>>(rawJson);
            if (info is null)
            {
                throw new DataException("Could not parse pools-info.json");
            }

            return info;
        }
        catch (HttpRequestException)
        {
            throw new DataException("Could not find pools-info.json");
        }  
    }
}