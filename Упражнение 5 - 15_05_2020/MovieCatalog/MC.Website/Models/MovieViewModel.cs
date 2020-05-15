namespace MC.Website.Models
{
    public class MovieViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Rating { get; set; }

        public GenreViewModel Genre { get; set; }

        public DirectorViewModel Director { get; set; }
    }
}
