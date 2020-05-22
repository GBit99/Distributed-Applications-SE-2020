﻿using System.Collections.Generic;

namespace MC.Models.Entities
{
    public class Director : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
