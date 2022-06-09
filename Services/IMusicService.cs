using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kol2_ko_s22106.Models;
using kol2_ko_s22106.Models.DTOs;

namespace kol2_ko_s22106.Services
{
    public interface IMusicService
    {

        public IQueryable<Musician> GetMusicianById(int id);
        public Task<List<MusicianGet>> GetTracksByMusician(int idMusician);
        public Task DeleteMusician(int idMusician);
        public Task<bool> CheckMusicianTracks(int idMusician);

    }
}