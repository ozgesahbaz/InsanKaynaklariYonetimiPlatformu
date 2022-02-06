using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM
{
    public class ManagersDebitVM
    {
        public int ID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} boş geçilemez")]
        [Display(Name = "Zimmet Adı")]
        public string DebitName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} boş geçilemez")]
        [Display(Name = "Veriliş Tarihi")]
        [DataType(DataType.Date)]
        public DateTime StartedDate { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} boş geçilemez")]
        [Display(Name = "Detay")]
        public string Details { get; set; }
        public bool? IsAproved { get; set; }
    }
}
