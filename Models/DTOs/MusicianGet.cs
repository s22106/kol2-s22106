using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2_ko_s22106.Models.DTOs
{
    public class MusicianGet
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public List<TrackGet> Tracks { get; set; }
    }

    public class TrackGet
    {
        public string TrackName { get; set; }
        public float Duration { get; set; }
        public int IdMusicAlbum { get; set; }
    }
}