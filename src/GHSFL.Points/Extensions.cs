using GHSFL.Points.Models;

namespace GHSFL.Points;

public static class Extensions
{
    public static void AddOrUpdate(this List<SchoolInfo> schoolInfo, string club, int points)
    {
        var entry = schoolInfo.FirstOrDefault(x => x.Club == club);
        if (entry is null)
        {
            schoolInfo.Add(new SchoolInfo
            {
                Club = club,
                Points = points
            });
        }
        else
        {
            entry.Points += points;
        }
    }
}