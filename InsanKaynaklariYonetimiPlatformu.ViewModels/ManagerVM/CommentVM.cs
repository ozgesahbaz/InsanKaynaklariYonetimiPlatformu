using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM
{
    public class CommentVM
    {
        public int CommentID { get; set; }
        public int ManagerID { get; set; }
        [Display(Name = "Yorum Yazın")]
        public string Comment { get; set; }
        [Display(Name = "İsim Soyisim")]

        public string ManagerFullName { get; set; }
        [Display(Name = "Şirket Adı")]

        public string CompanyName { get; set; }

        public string ManagerPhoto { get; set; }
    }
}
