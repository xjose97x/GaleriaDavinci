using System.ComponentModel.DataAnnotations;

namespace GaleriaDavinci.Web.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
    }
}
