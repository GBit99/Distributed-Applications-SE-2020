namespace MC.Business.DTOs
{
    public class DirectorDto : BaseDto, IValidateable
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsValid()
        {
            throw new System.NotImplementedException();
        }
    }
}
