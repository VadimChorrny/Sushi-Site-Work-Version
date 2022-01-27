using System.ComponentModel.DataAnnotations;

namespace SushiSite.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Рік народження")]
        public int Year { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не співпадають")]
        [DataType(DataType.Password)]
        [Display(Name = "Підтвердіть пароль пароль")]
        public string PasswordConfirm { get; set; }
    }
}
