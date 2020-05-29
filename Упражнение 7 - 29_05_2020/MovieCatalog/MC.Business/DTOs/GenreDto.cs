using System.ComponentModel.DataAnnotations;

namespace MC.Business.DTOs
{
    public class GenreDto : BaseDto, IValidateable
    {
        public string Name { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Name) && Name.Length < 50;
        }
    }
}
