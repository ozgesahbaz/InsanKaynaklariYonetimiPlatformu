using InsanKaynaklariYonetimiPlatformu.Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.ViewModels.AdminVM
{
    public class ActiveCompanyVM
    {

        [Display(Name = "FirmaID")]

        public int CompanyId { get; set; }

        [Display(Name = "YoneticiID")]

        public int ManagerID { get; set; }
        [Display(Name = "Firma Adı")]

        public string CompanyName { get; set; }
        [Display(Name = "Firma Mail Uzanrtısı")]

        public string Mailextension { get; set; }
        [Display(Name = "Yönetici İsim Soyisim")]
        public string ManagerFullName { get; set; }
        [Display(Name = "Yönetici Mail Adresi")]

        public string ManagerMail { get; set; }

        [Display(Name = "Kayıt Türü")]

        public MembershipType membershipType { get; set; }

        [Display(Name = "Kayıt Tarihi")]

        public DateTime RegisterDate { get; set; }

        [Display(Name = "Kayıt Bitiş Tarihi")]

        public DateTime FinishedDate { get; set; }

    }
}

