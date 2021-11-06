using System.ComponentModel.DataAnnotations;

namespace GaleriaDavinci.Web.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}
