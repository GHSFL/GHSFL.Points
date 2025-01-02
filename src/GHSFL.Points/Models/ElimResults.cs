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
        if (FotlName == "BYE" || FotrName == "BYE")
        {
            return "BYE";
        }
        
        var winnerScore = FotlId == WinnerId ? FotlScore : FotrScore;
        var winnerName = FotlId == WinnerId ? FotlName : FotrName;
        
        var otherScore = FotlId == WinnerId ? FotrScore : FotlScore;

        return $"{winnerName}: {winnerScore} - {otherScore}";
    }
}