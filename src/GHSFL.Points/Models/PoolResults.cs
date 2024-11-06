namespace GHSFL.Points.Models;

public class PoolResults
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ClubName { get; set; }
    public long FencerId { get; set; }
    public int Victories { get; set; }
    public int Matches { get; set; }
    public int Scored { get; set; }
    public int Received { get; set; }
    public int Indicator => Scored - Received;
    public int Defeats => Matches - Victories;
    public double Vm => Victories / (double)Matches;
}