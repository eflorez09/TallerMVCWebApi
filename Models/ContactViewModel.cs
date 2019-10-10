using System.ComponentModel.DataAnnotations;

namespace TallerMVCWebApi.Models
{
    public class ContactViewModel
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Nombre es Obligatorio")]
        [MaxLength(200)]
        public string Name { get; set; }

        [Display(Name = "Correo Electrónico")]
        [Required(ErrorMessage = "Correo Electrónico es Obligatorio")]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Teléfono")]
        [MaxLength(10)]
        [Phone]
        public string Phone { get; set; }

        [Display(Name = "Mensaje")]
        [Required(ErrorMessage = "Mensaje es Obligatorio")]
        [MaxLength(500)]
        public string Message { get; set; }
    }
}