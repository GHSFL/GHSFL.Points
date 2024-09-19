namespace GHSFL.Points.Models;

public class SeasonInfo
{
    /// <summary>
    /// The late time the data has been updated.
    /// </summary>
    public DateTime LastUpdated { get; set; }
    
    /// <summary>
    /// The number of rounds in the season.
    /// </summary>
    public int NumRounds { get; set; }

    /// <summary>
    /// The list of fencers.
    /// </summary>
    public List<FencerInfo> FencerPoints { get; set; } = new();
}