using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace GaleriaDavinci.Domain.Models
{
    public class ApplicationUser : IdentityUser, IAuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public virtual ICollection<ArtPiece> ArtPieces { get; set; }


        public ApplicationUser(string email, string firstName, string lastName)
        {
            Email = email;
            UserName = email;
            FirstName = firstName;
            LastName = lastName;
        }

        public ApplicationUser()
        {
        }
    }
}
