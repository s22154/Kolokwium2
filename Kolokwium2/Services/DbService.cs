using System.Linq;
using System.Threading.Tasks;
using Kolokwium2.Models;
using Kolokwium2.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Services
{
    public class DbService : IDbService
    {
        private readonly MasterContext _context;

        public DbService(MasterContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckMusicianExists(int idMusician)
        {
            return await _context.Musicians.AnyAsync(m => m.IdMusician.Equals(idMusician));
        }

        public async Task<SomeKindOfMusician> GetMusician(int idMusician)
        {
            return await _context.Musicians
                .Include(m => m.Musician_Tracks)
                .Select(m => new SomeKindOfMusician
                {
                    FirstName = m.FirstName,
                    LastName = m.LastName,
                    Nickname = m.Nickname,
                    Tracks = m.Musician_Tracks.Select(mt => new SomeKindOfTrack
                    {
                        TrackName = mt.Track.TrackName,
                        Duration = mt.Track.Duration
                    }).OrderBy(mt => mt.Duration)
                })
                .SingleOrDefaultAsync();
        }

        public async Task<bool> CheckMusicianHasTracksNotOnAlbum(int idMusician)
        {
            var tracks = _context.Musician_Tracks.Where(mt => mt.IdMusician.Equals(idMusician)).Select(e => e.IdTrack)
                .Intersect(_context.Tracks.Where(t=> t.IdMusicAlbum.Equals(null)).Select(t => t.IdTrack));
            return await tracks.AnyAsync();
        }

        public async Task<Musician> DeleteMusician(int idMusician)
        {
            var musician = _context.Musicians.SingleOrDefaultAsync(m => m.IdMusician.Equals(idMusician));
            _context.Remove(musician);
            await _context.SaveChangesAsync();
            return await musician;
        }
    }
}