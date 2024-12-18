using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using music_manager_starter.Data;
using music_manager_starter.Data.Models;
using Serilog;  
using Microsoft.Extensions.Logging;  
namespace music_manager_starter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly DataDbContext _context;
        private readonly ILogger<SongsController> _logger; 

        public SongsController(DataDbContext context, ILogger<SongsController> logger)
        {
            _context = context;
            _logger = logger;  // Store logger
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongs()
        {
            _logger.LogInformation("Fetching all songs from the database.");
            var songs = await _context.Songs
                .Include(s => s.Ratings)
                .ToListAsync();
            _logger.LogInformation("Successfully fetched {SongCount} songs from the database.", songs.Count);
            return Ok(songs);
        }

        [HttpPost]
        public async Task<ActionResult<Song>> PostSong(Song song)
        {
            if (song == null)
            {
                _logger.LogWarning("Received null song in PostSong request.");
                return BadRequest("Song cannot be null.");
            }

            _logger.LogInformation("Adding new song: {SongTitle} by {SongArtist}.", song.Title, song.Artist);
            _context.Songs.Add(song);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Successfully added song with ID: {SongId}.", song.Id);

            return Ok();
        }

        [HttpPost("{songId}/ratings")]
        public async Task<ActionResult> PostRating(Guid songId, [FromBody] byte ratingValue)
        {
            _logger.LogInformation("Received rating {Rating} for song with ID: {SongId}.", ratingValue, songId);
            var song = await _context.Songs
                .FirstOrDefaultAsync(s => s.Id == songId);

            if (song == null)
            {
                _logger.LogWarning("Song with ID {SongId} not found.", songId);
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
            _logger.LogInformation("Successfully added rating for song with ID: {SongId}.", songId);

            return Ok();
        }
    }
}
