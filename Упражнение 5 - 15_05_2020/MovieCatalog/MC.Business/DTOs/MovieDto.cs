namespace MC.Business.DTOs
{
    public class MovieDto : BaseDto, IValidateable
    {
        public string Title { get; set; }

        public GenreDto Genre { get; set; }

        public DirectorDto Director { get; set; }

        public int Rating { get; set; }

        public bool IsValid()
        {
            throw new System.NotImplementedException();
        }
    }
}
