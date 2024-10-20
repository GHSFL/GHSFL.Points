namespace GHSFL.Points.Models;

public class FencerInfo
{
    /// <summary>
    /// The firstname of the fencer.
    /// </summary>
    public required string Firstname { get; set; }
    
    /// <summary>
    /// The lastname of the fencer.
    /// </summary>
    public required string Lastname { get; set; }
    
    /// <summary>
    /// The gender of the fencer.
    /// </summary>
    public string Gender { get; set; }
    
    /// <summary>
    /// The club the fencer belongs to.
    /// </summary>
    public required string Club { get; set; }

    /// <summary>
    /// The number of tournaments this fencer has attended.
    /// </summary>
    public int TournamentsAttended => PointsPerRound.Count;

    /// <summary>
    /// Whether this fencer is qualified for the individual championships.
    /// </summary>
    public bool QualifiedForIndividualChamps => TotalPoints > 0 && PointsPerRound.Count > 2; 

    /// <summary>
    /// The total points the fencer has.
    /// </summary>
    public int TotalPoints { get; set; } = 0;

    /// <summary>
    /// Represents how many points this fencer has earned on each round.
    /// </summary>
    public Dictionary<int, int> PointsPerRound { get; set; } = new();
}