using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.ViewModels
{
    public class ManagerLoginVM
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} boş geçilemez")]
        [Display(Name = "Yönetici Mail Adresi", Prompt = "isimsoyisim@firmaadi.com")]
        [DataType(DataType.EmailAddress)]
        public string ManagerEmail { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} boş geçilemez")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string ManagerPassword { get; set; }
        [Display(Name = "Beni Hatırla")]
        public bool IsRemember { get; set; }

    }
}
