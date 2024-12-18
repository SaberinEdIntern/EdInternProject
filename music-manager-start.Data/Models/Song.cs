﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music_manager_starter.Data.Models
{
    public sealed class Song
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Artist { get; set; }
        public required string Album { get; set; }
        public required string Genre { get; set; }
        public List<RatingEvent> Ratings { get; set; } = new List<RatingEvent>();
        public double AverageRating => Ratings.Count == 0 ? 0 : Ratings.Average(r => r.OneToFive);
    }

}
