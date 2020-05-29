namespace MC.Business.DTOs
{
    public class DirectorDto : BaseDto, IValidateable
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(FirstName) && FirstName.Length < 50
                && !string.IsNullOrWhiteSpace(LastName) && FirstName.Length < 50;
        }
    }
}
