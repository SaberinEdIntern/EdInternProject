using System;

namespace music_manager_starter.Data.Models
{
    public class RatingEvent
    {
        public Guid Id {get;set;} 

        // Use a byte for memory efficiency since rating values can only be integers 1-5
        public byte OneToFive { get; set; }
        public Guid SongId {get; set; }

    }
}