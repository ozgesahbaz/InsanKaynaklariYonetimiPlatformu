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
    public class AddEmployeesPermissionVM
    {
        public int ManagerID { get; set; }
        public int? EmployeeID { get; set; }
        public List<Employee> Employees { get; set; }
        [Display(Name ="Başlama Tarihi")]
        [DataType(DataType.Date)]

        public DateTime StartDate { get; set; }
        [Display(Name = "Bitiş Tarihi")]
        [DataType(DataType.Date)]


        public DateTime FinishDate { get; set; }
        public PermissionType PermissionType { get; set; }
    }
}
