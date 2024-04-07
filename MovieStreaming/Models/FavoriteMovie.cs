using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MovieStreaming.Models
{
    public class FavoriteMovie
    {
        [Key]
        public int FavoriteID { get; set; }
        public int? UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
        public int? MovieId { get; set; }
        public Movie? Movie { get; set; }
    }
}
