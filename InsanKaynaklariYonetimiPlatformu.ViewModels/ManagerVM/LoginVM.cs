using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM
{
    public class LoginVM
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} boş geçilemez")]
        [Display(Name = " Mail Adresi", Prompt = "isimsoyisim@firmaadi.com")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} boş geçilemez")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Beni Hatırla")]
        public bool IsRemember { get; set; }
        public bool ForgetPassword { get; set; }

    }
}
