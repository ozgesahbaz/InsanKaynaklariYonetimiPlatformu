using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.ViewModels.EmployeeVM
{
    public class EmployeePasswordVM
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} boş geçilemez")]
        [Display(Name = "Güncel şifrenizi giriniz")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} boş geçilemez")]
        [Display(Name = "Yeni şifrenizi giriniz")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} boş geçilemez")]
        [Display(Name = "Yeni şifrenizi tekrar giriniz")]
        [DataType(DataType.Password)]
        public string AgainNewPassword { get; set; }
    }
}
