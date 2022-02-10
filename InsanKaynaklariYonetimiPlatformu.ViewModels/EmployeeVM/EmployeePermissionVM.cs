using InsanKaynaklariYonetimiPlatformu.Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariYonetimiPlatformu.ViewModels.EmployeeVM
{
    public class EmployeePermissionVM
    {
        public int PermissionID { get; set; }
        [DataType(DataType.Date)]

        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]

        public DateTime FinishDate { get; set; }
      
        public PermissionType PermissionType { get; set; }
        [Required(ErrorMessage = "İzin tipi boş geçilemez")]
        public bool? isAproved { get; set; }
    }
}
