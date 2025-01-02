using GHSFL.Points.Models;

namespace GHSFL.Points;

public static class Extensions
{
    public static string GetOpponentName(this ElimResults elim, long fencerId)
    {
        return elim.FotlId == fencerId ? elim.FotrName : elim.FotlName;
    }
    
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

    public static int GetQualified(this List<FencerInfo> fencerInfo, string gender)
    {
        return fencerInfo
            .Where(x => x.Gender == gender)
            .Count(x => x.QualifiedForIndividualChamps);
    }
}