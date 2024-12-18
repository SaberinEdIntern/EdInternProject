using System;

namespace music_manager_starter.Data.Models
{
    public class RatingEvent
    {
        public Guid Id {get;set;} 
        public byte OneToFive { get; set; }
        public Guid SongId {get; set; }

    }
}