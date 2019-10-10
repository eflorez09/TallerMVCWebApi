using System.ComponentModel.DataAnnotations;

namespace TallerMVCWebApi.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "Usuario es Obligatorio")]
        [MaxLength(100)]
        [EmailAddress]
        public string UserName { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Contraseña es Obligatoria")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}