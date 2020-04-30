namespace MC.Business.DTOs
{
    public class MovieDto : BaseDto
    {
        public string Title { get; set; }

        public GenreDto Genre { get; set; }

        public DirectorDto Director { get; set; }

        public int Rating { get; set; }
    }
}
