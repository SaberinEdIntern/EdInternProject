using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using music_manager_starter.Data;
using music_manager_starter.Data.Models;
using Serilog; 

namespace music_manager_starter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly DataDbContext _context;

        public SongsController(DataDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongs()
        {
            // Directly using Serilog to log
            Log.Information("Fetching all songs from the database.");
            var songs = await _context.Songs
                .Include(s => s.Ratings)
                .ToListAsync();

            Log.Information("Successfully fetched {SongCount} songs from the database.", songs.Count);
            return Ok(songs);
        }

        [HttpPost]
        public async Task<ActionResult<Song>> PostSong(Song song)
        {
            if (song == null)
            {
                // Serilog 
                Log.Warning("Received null song in PostSong request.");
                return BadRequest("Song cannot be null.");
            }

            Log.Information("Adding new song: {SongTitle} by {SongArtist}.", song.Title, song.Artist);
            _context.Songs.Add(song);
            await _context.SaveChangesAsync();
            Log.Information("Successfully added song with ID: {SongId}.", song.Id);

            return Ok();
        }

        [HttpPost("{songId}/ratings")]
        public async Task<ActionResult> PostRating(Guid songId, [FromBody] byte ratingValue)
        {
            Log.Information("Received rating {Rating} for song with ID: {SongId}.", ratingValue, songId);
            var song = await _context.Songs
                .FirstOrDefaultAsync(s => s.Id == songId);

            if (song == null)
            {
                Log.Warning("Song with ID {SongId} not found.", songId);
                return NotFound("Song not found.");
            }

            var ratingEvent = new RatingEvent
            {
                Id = Guid.NewGuid(),
                SongId = songId,
                OneToFive = ratingValue
            };

            _context.RatingEvents.Add(ratingEvent);
            await _context.SaveChangesAsync();
            Log.Information("Successfully added rating for song with ID: {SongId}.", songId);

            return Ok();
        }
    }
}
