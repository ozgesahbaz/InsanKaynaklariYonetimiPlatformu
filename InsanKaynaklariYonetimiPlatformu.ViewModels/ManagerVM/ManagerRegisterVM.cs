using InsanKaynaklariYonetimiPlatformu.Entity.Entities;
using InsanKaynaklariYonetimiPlatformu.Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM
{
    public class ManagerRegisterVM
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} boş geçilemez")]
        [Display(Name = "Firma Adı", Prompt = "Bilge Adam")]
        public string CompanyName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} boş geçilemez")]
        [Display(Name = "Firma Adresi", Prompt = "Firma Adresi")]
        [StringLength(300, ErrorMessage ="Adres uzunluğu en fazla 300 en az 50  karakter olabilir", MinimumLength =  50) ]
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} boş geçilemez")]
        [Display(Name = "Yönetici İsim Soyisim")]
        public string ManagerFullName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} boş geçilemez")]
        [Display(Name = "Yönetici Mail Adresi", Prompt = "isimsoyisim@firmaadi.com")]
        [DataType(DataType.EmailAddress)]
        public string ManagerMail { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} boş geçilemez")]
        [StringLength(8, ErrorMessage = "parolanız 8 karakter olmalıdır", MinimumLength = 8)]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string ManagerPassword { get; set; }
        //[Required(AllowEmptyStrings = false, ErrorMessage = "{0} boş geçilemez")]
        [Display(Name = "Üyelik Tipi")]
        public MembershipType Membership { get; set; }

    }

    //public class MemberShipVM
    //{
    //    public int MembershipId { get; set; }
    //    public MembershipType MembershipType { get; set; }
    //}
}
