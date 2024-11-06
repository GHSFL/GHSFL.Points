namespace GHSFL.Points.Models;

public class PoolsForFencer
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public List<PoolResults> Pools { get; set; } = new();

    public void AddPool(PoolResults pool)
    {
        Pools.Add(pool);
    }
}