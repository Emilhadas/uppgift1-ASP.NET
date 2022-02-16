using System.ComponentModel.DataAnnotations;

namespace uppgift1_test.Models.ViewModels
{
    public class SignInViewModel
    {
        [Required(ErrorMessage = "Du måste ange en Epost")]
        [Display(Name = "Epost")]
        public string Email { get; set; }

        [Display(Name = "Lösenord")]
        [Required(ErrorMessage = "Du måste ange ett Lösenord")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Ditt Lösenord är för kort", MinimumLength = 6)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
