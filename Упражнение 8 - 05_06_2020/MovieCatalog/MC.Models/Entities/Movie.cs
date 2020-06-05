namespace MC.Models.Entities
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }

        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }

        public int DirectorId { get; set; }

        public virtual Director Director { get; set; }

        public int Rating { get; set; }
    }
}
