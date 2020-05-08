using System.Collections.Generic;

namespace MC.Models.Entities
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
