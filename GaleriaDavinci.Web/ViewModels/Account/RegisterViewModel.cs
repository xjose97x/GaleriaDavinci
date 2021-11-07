using System.ComponentModel.DataAnnotations;

namespace GaleriaDavinci.Web.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [Required]
        [MinLength(8)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
        
        [Required]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }
        
        [Required]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }
    }
}
