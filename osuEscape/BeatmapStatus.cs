using System;

namespace osuEscape
{
    [Flags]
    public enum BeatmapStatus
    {
        // some status missing
        Qualified = 0,
        NotSubmitted = 1,
        Pending = 2,
        Ranked = 4,
        Approved = 5,
        Loved = 7
    }
}
