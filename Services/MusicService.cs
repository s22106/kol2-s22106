using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kol2_ko_s22106.Models;
using kol2_ko_s22106.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace kol2_ko_s22106.Services
{
    public class MusicService : IMusicService
    {
        private readonly MusicDbContext _context;

        public MusicService(MusicDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckMusicianTracks(int idMusician)
        {
            return await _context.MusicianTracks
            .Include(e => e.Musician)
            .Where(e => e.IdMusician == idMusician)
            .Include(e => e.Track)
            .AnyAsync(e => e.Track.IdMusicAlbum == 1);
        }

        public async Task DeleteMusician(int IdMusician)
        {
            var musician = await _context.Musicians.Where(e => e.IdMusician == IdMusician)
                .FirstOrDefaultAsync();

        }

        public IQueryable<Musician> GetMusicianById(int id)
        {
            return _context.Musicians.Where(e => e.IdMusician == id);
        }

        public async Task<List<MusicianGet>> GetTracksByMusician(int idMusician)
        {
            return await _context.MusicianTracks.Include(e => e.Track)
            .Include(e => e.Musician)
            .Where(e => e.IdMusician == idMusician)
                .Select(e => new MusicianGet
                {
                    FirstName = e.Musician.FirstName,
                    LastName = e.Musician.LastName,
                    NickName = e.Musician.Nickname,
                    Tracks = _context.Tracks.Where(t => t.IdTrack == e.IdTrack)
                                .Select(t => new TrackGet
                                {
                                    TrackName = t.TrackName,
                                    Duration = t.Duration,
                                    IdMusicAlbum = t.IdMusicAlbum
                                }).OrderBy(t => t.Duration).ToList()
                }).ToListAsync();
        }
    }
}