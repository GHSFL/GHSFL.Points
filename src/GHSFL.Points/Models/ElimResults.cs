namespace GHSFL.Points.Models;

public class ElimResults
{
    // The DE round (128, 64, 32, etc)
    public int Round { get; set; }
    // Comp1ID in FT xml
    public long FotrId { get; set; }
    // Comp2ID in FT xml
    public long FotlId { get; set; }
    // Score1 in FT xml
    public int FotrScore { get; set; }
    // Score2 in FT xml
    public int FotlScore { get; set; }
    // Whether a BYE was used
    public bool Bye => FotrId == 0 || FotlId == 0;
    // The ID of the winner
    public long WinnerId => FotlScore > FotrScore ? FotlId : FotrId;
    
    /// <summary>
    /// The name of FotL
    /// </summary>
    public string FotlName { get; set; }
    
    /// <summary>
    /// The name of FotR
    /// </summary>
    public string FotrName { get; set; }

    /// <summary>
    /// ToString override. Returns the score of the bout.
    /// </summary>
    /// <returns>A string representation of the bout score.</returns>
    public override string ToString()
    {
        if (FotlName == "BYE BYE" || FotrName == "BYE BYE")
        {
            return "BYE";
        }
        
        var winnerScore = FotlId == WinnerId ? FotlScore : FotrScore;
        var winnerName = FotlId == WinnerId ? FotlName : FotrName;
        
        var otherScore = FotlId == WinnerId ? FotrScore : FotlScore;

        return $"Winner: {winnerName}. Score: {winnerScore} - {otherScore}";
    }

    /// <remarks>
    /// Is the .Replace in the bottom two methods stupid? Yes.
    /// Should I just fix it on the data side? Yes.
    /// Is that a problem for another day? Yes.
    /// </remarks>
    public string GetScoreForFencer(long fencerId)
    { 
        return (fencerId == FotlId ? $"{FotlName} - {FotlScore}" : $"{FotrName} - {FotrScore}").Replace("BYE BYE", "BYE");
    }

    public string GetScoreForOtherFencer(long fencerId)
    {
        var id = fencerId == FotlId ? FotrId : FotlId;
        return (id == FotlId ? $"{FotlScore} - {FotlName}" : $"{FotrScore} - {FotrName}").Replace("BYE BYE", "BYE");
    }
}