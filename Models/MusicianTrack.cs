using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2_ko_s22106.Models
{
    public class MusicianTrack
    {
        public int IdTrack { get; set; }
        public int IdMusician { get; set; }
        public virtual Musician Musician { get; set; }
        public virtual Track Track { get; set; }
    }
}