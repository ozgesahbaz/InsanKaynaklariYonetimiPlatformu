using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.ViewModels
{
    public class ManagerRegisterVM
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} boş geçilemez")]
        [Display(Name = "Firma Adı", Prompt = "Bilge Adam")]
        public string CompanyName { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} boş geçilemez")]
        [Display(Name = "Firma Mail Adresi", Prompt = "firmaadi@firmaadi.com")]
        [DataType(DataType.EmailAddress)]        
        public string CompanyMail { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} boş geçilemez")]
        [Display(Name = "Yönetici İsim Soyisim")]
        public string ManagerFullName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} boş geçilemez")]
        [Display(Name = "Yönetici Mail Adresi", Prompt = "isimsoyisim@firmaadi.com")]
        [DataType(DataType.EmailAddress)]
        public string ManagerMail { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} boş geçilemez")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string ManagerPassword { get; set; }
      
    }
}
