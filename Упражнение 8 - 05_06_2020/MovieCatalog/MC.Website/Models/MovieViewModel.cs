using System.ComponentModel;

namespace MC.Website.Models
{
    public class MovieViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Rating { get; set; }

        [DisplayName("Genre")]
        public int GenreId { get; set; }

        public GenreViewModel Genre { get; set; }

        [DisplayName("Director")]
        public int DirectorId { get; set; }

        public DirectorViewModel Director { get; set; }
    }
}
