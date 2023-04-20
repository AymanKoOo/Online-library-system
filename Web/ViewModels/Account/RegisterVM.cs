using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.Account
{
    public class RegisterVM
    {
        [Required]
        [StringLength(10,ErrorMessage ="Max length is 10 Charcter",MinimumLength = 4)]
        public string UserName { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]   
        public string Password { get; set; }

        [Required]
        [Compare("Password",ErrorMessage = "The password and confirmation password not match")]
        public string ConfirmPasswod { get; set; }
    }
}
