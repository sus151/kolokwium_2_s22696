using kolokwium.DataAccess;
using kolokwium.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium.Services
{
    public class MusicianService : IMusicianService
    {
        private readonly DBContext _context;

        public MusicianService(DBContext context)
        {
            _context = context;
        }
        public async Task DeleteMusician(int id)
        {
            var musician = await _context.Musicians.Where(e => e.IdMusician == id).FirstOrDefaultAsync();
            if (musician == null)
            {
                throw new Exception("NotFound");
            }
            var tracks = await _context.MusicianTracks
                .Where(e => e.IdMusician == id)
                .Select(e => e.Track)
                .Select(e => e.IdMusicAlbum)
                .Where(e => e != null)
                .ToListAsync();
            if (tracks.Count != 0)
            {
                throw new Exception("BadRequest");
            }
            var musicianTracksToDelete = await _context.MusicianTracks
                .Where(e => e.IdMusician == id)
                .ToListAsync();
            for (int i = 0; i < musicianTracksToDelete.Count; i++)
            {
                _context.MusicianTracks.Remove(musicianTracksToDelete[i]);
            }
            _context.Musicians.Remove(musician);
            await _context.SaveChangesAsync();
            
        }

        public async Task<MusicianGet> GetMusician(int id)
        {
            var musician = await _context.Musicians.Where(e => e.IdMusician == id).FirstOrDefaultAsync();
            if (musician == null)
            {
                throw new Exception("Nie ma artysty o podanym id");
            }
            List<TrackGet> tracks = await _context.MusicianTracks
                .Where(e => e.IdMusician == id)
                .Select(e => e.Track)
                .Select(e => new TrackGet
                {
                    IdTrack = e.IdTrack,
                    TrackName = e.TrackName,
                    Duration = e.Duration,
                    IdMusicAlbum = e.IdMusicAlbum
                })
                .OrderBy(e => e.Duration)
                .ToListAsync();


            return new MusicianGet
            {
                IdMusician = musician.IdMusician,
                FirstName = musician.FirstName,
                LastName = musician.LastName,
                NickName = musician.NickName,
                MusicianTracks = tracks
            };

        }
    }
}
