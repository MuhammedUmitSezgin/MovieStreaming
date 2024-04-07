using System;

namespace MovieStreaming.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public int? ReleaseYear { get; set; }
    }
}
