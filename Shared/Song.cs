using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using music_manager_starter.Data.Models; 

namespace music_manager_starter.Shared
{
    public sealed class Song
    {
        public Guid Id {get;set;} 
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Genre { get; set; }

        public List<RatingEvent> Ratings {get; set;} = new List<RatingEvent>();
        public double AverageRating => Ratings.Count == 0 ? 0 : Ratings.Average(r => r.OneToFive);

        
    }

}
