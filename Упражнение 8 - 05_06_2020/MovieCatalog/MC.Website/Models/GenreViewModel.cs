using System.ComponentModel.DataAnnotations;

namespace MC.Website.Models
{
    public class GenreViewModel
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }
    }
}
