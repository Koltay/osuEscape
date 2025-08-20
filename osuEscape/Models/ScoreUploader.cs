using System;
using System.Net.Http;

namespace osuEscape.Models
{
    public class ScoreUploader : IDisposable
    {
        private readonly HttpClient _client = new();
        private readonly int _beatmapLastNoteOffset = int.MinValue;
        public int BeatmapLastNoteOffset => _beatmapLastNoteOffset;

        // Dispose pattern implementation
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _client.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}