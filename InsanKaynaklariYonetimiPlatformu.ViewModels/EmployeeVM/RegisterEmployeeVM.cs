using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.ViewModels.EmployeeVM
{
    public class RegisterEmployeeVM
    {
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} boş geçilemez")]
        [Display(Name = "Lütfen şifre oluşturun")]
        [DataType(DataType.Password)]
        [StringLength(8, ErrorMessage = "Şifre 8 karakterli olmalıdır.")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} boş geçilemez")]
        [Display(Name = "Şifrenizi doğrulayın")]
        [StringLength(8, ErrorMessage = "Şifre 8 karakterli olmalıdır.")]
        [DataType(DataType.Password)]
        public string AgainPassword { get; set; }
    }
}
