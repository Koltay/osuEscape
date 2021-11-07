using System;
using System.Collections.Generic;
using System.Text;

namespace osuEscape
{
    public class Beatmap
    {
        // api v1
        public int approved { get; set; } // 4 = loved, 3 = qualified, 2 = approved, 1 = ranked, 0 = pending, -1 = WIP, -2 = graveyard
        public string submit_date { get; set; } // date submitted, in UTC
        public string approved_date { get; set; } // date ranked, in UTC
        public string last_update { get; set; } // last update date, in UTC. May be after approved_date if map was unranked and reranked.
        public string artist { get; set; }
        public int beatmap_id { get; set; } // beatmap_id is per difficulty
        public int beatmapset_id { get; set; } // beatmapset_id groups difficulties into a set
        public int bpm { get; set; }
        public string creator { get; set; }
        public int creator_id { get; set; }
        public double difficultyrating { get; set; }
        public double diff_aim { get; set; }
        public double diff_speed { get; set; }
        public double diff_size { get; set; }
        public double diff_overall { get; set; }
        public double diff_approach { get; set; }
        public double diff_drain { get; set; }
        public int hit_length { get; set; }
        public string source { get; set; }
        public int genre_id { get; set; }                  // 0 = any, 1 = unspecified, 2 = video game, 3 = anime, 4 = rock, 5 = pop, 6 = other, 7 = novelty, 9 = hip hop, 10 = electronic, 11 = metal, 12 = classical, 13 = folk, 14 = jazz (note that there's no 8)
        public int language_id { get; set; }              // 0 = any, 1 = unspecified, 2 = english, 3 = japanese, 4 = chinese, 5 = instrumental, 6 = korean, 7 = french, 8 = german, 9 = swedish, 10 = spanish, 11 = italian, 12 = russian, 13 = polish, 14 = other
        public string title { get; set; }      // song name
        public int total_length { get; set; }                // seconds from first note to last note including breaks
        public string version { get; set; }           // difficulty name
        public string file_md5 { get; set; }
        public int mode { get; set; }                  // game mode,
        public string tags { get; set; } // Beatmap tags separated by spaces.
        public int favourite_count { get; set; }                // Number of times the beatmap was favourited. (americans: notice the ou!)
        public double rating { get; set; }
        public int playcount { get; set; }               // Number of times the beatmap was played
        public int passcount { get; set; }               // Number of times the beatmap was passed, completed (the user didn't fail or retry)
        public int count_normal { get; set; }
        public int count_slider { get; set; }
        public int count_spinner { get; set; }
        public int max_combo { get; set; }  // The maximum combo a user can reach playing this beatmap.
        public int storyboard { get; set; }                // If this beatmap has a storyboard
        public int video { get; set; }                  // If this beatmap has a video
        public int download_unavailable { get; set; }                  // If the download for this beatmap is unavailable (old map, etc.)
        public int audio_unavailable { get; set; }
    }
}
