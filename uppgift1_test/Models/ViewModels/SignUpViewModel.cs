using System.ComponentModel.DataAnnotations;

namespace uppgift1_test.Models.ViewModels
{
    public class SignUpViewModel
    {
        [Display(Name = "Förnamn")]
        [Required(ErrorMessage = "Du måste ange ett Förnamn")]
        [StringLength(100, ErrorMessage = "Ditt förnamn är för kort", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Display(Name = "Efternamn")]
        [Required(ErrorMessage = "Du måste ange ett Efternamn")]
        [StringLength(100, ErrorMessage = "Ditt Efternamn är för kort", MinimumLength = 2)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Du måste ange en Epost")]
        [Display(Name = "Epost")]
        public string Email { get; set; }

        [Display(Name = "Lösenord")]
        [Required(ErrorMessage = "Du måste ange ett Lösenord")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Ditt Lösenord är för kort", MinimumLength = 6)]
        public string Password { get; set; }

        [Display(Name = "Bekräfta Lösenord")]
        [Required(ErrorMessage = "Du måste ange ett Lösenord")]
        [Compare(nameof(Password), ErrorMessage = "Lösenordet stämmer inte överens")]
        public string ConfPassword { get; set; }

        [Display(Name = "Adress")]
        [Required(ErrorMessage = "Du måste ange en Adress")]
        public string StreetName { get; set; }

        [Display(Name = "Postnummer")]
        [Required(ErrorMessage = "Du måste ange ett Postnummer")]
        [StringLength(100, ErrorMessage = "Ditt Postnummer är för kort", MinimumLength = 5)]
        public string PostalCode { get; set; }

        [Display(Name = "Stad")]
        [Required(ErrorMessage = "Du måste ange en Stad")]
        public string City { get; set; }
    }
}
