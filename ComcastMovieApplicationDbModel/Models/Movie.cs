using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComcastMovieApplicationDbModel.Models
{
    public class Movie
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(1000)]
        [Index("Idx_Movie_Title")]
        [Required]
        public string Title { get; set; }

        [Required]
        [Index("Idx_Movie_YearOfRelease")]
        public int YearOfRelease { get; set; }

        [Required]
        public int RunningTime { get; set; }

        [MaxLength(1000)]
        [Required]
        [Index("Idx_Movie_Genre")]
        public string Genre { get; set; }

    }
}
