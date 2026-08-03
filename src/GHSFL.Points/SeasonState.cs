namespace GHSFL.Points;

/// <summary>
/// Tracks which season's data is currently selected and notifies subscribers when it changes.
/// </summary>
public class SeasonState
{
    /// <summary>
    /// The value representing the current, live season (data served straight from wwwroot/data).
    /// </summary>
    /// <remarks>
    /// This must be non-empty: MudSelect treats an empty string as "no value" and won't float its
    /// label out of the way, which causes the label and selected text to overlap.
    /// </remarks>
    public const string CurrentSeason = "current";

    /// <summary>
    /// The currently selected season. <see cref="CurrentSeason"/> means the live season.
    /// </summary>
    public string SelectedSeason { get; private set; } = CurrentSeason;

    /// <summary>
    /// Raised whenever <see cref="SelectedSeason"/> changes.
    /// </summary>
    public event Action? OnChange;

    /// <summary>
    /// Selects a season and notifies subscribers if it actually changed.
    /// </summary>
    public void SetSeason(string season)
    {
        if (SelectedSeason == season)
        {
            return;
        }

        SelectedSeason = season;
        OnChange?.Invoke();
    }

    /// <summary>
    /// Builds the data path for a file within the currently selected season.
    /// </summary>
    public string GetDataPath(string fileName)
    {
        return SelectedSeason == CurrentSeason
            ? $"data/{fileName}"
            : $"data/{SelectedSeason}/{fileName}";
    }
}
