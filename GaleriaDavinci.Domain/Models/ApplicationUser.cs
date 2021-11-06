using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace GaleriaDavinci.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<ArtPiece> ArtPieces { get; set; }

        public ApplicationUser(string email, string firstName, string lastName)
        {
            Email = email;
            UserName = email;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
