using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2_ko_s22106.Models
{
    public class MusicLabel
    {
        public int IdMusicLabel { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
    }
}