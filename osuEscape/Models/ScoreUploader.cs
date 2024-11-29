// FormManager.cs
using System.Net.Http;
// ScoreUploader.cs
public class ScoreUploader
{
    private readonly HttpClient _client = new();
    private readonly int _beatmapLastNoteOffset = int.MinValue;
    public int BeatmapLastNoteOffset => _beatmapLastNoteOffset;
}
