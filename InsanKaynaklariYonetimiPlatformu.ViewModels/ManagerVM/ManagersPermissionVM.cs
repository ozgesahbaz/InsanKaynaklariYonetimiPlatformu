using InsanKaynaklariYonetimiPlatformu.Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.ViewModels.ManagerVM
{
    public class ManagersPermissionVM
    {
        public int ID { get; set; }
        [Display(Name = "Başlangıç Tarihi")]

        [DataType(DataType.Date)]

        public DateTime StartDate { get; set; }
        [Display(Name = "Bitiş Tarihi")]
        [DataType(DataType.Date)]

        public DateTime FinishDate { get; set; }
        public PermissionType PermissionType { get; set; }
        public bool IsAproved { get; set; }
    }
}
